using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SwqlStudio.Autocomplete;
using SwqlStudio.Metadata;
using SwqlStudio.Properties;

namespace SwqlStudio
{
    public interface ILexerDataSource
    {
        string Text { get; }
    }
    internal sealed class LexerService : IDisposable
    {
        /// <summary>
        /// Namespace is, for our usage, SwisEntity with ColumnNames of the internal namespaces and classes
        /// NavigationProperty is the link to next entity with given name
        /// 
        /// ColumnNames nor NavigationProperties can contain dots
        /// </summary>
        private class SwisEntity
        {
            public HashSet<string> ColumnNames { get; } = new HashSet<string>();
            // contains references - 
            public Dictionary<string, string> NavigationProperties { get; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        }

        private readonly ILexerDataSource _lexerDataSource;
        private static List<string> BasicAutoCompletionKeywords { get; }

        private readonly Dictionary<string, SwisEntity> _swisEntities = new Dictionary<string, SwisEntity>(StringComparer.OrdinalIgnoreCase);

        // splits the string by '.', and yield returns all of the values as path
        // so a.b.c ->
        // returns ("", a),
        //         ("a", "b"),
        //         ("a.b", "c")
        private static IEnumerable<Tuple<string, string>> ParsePaths(string s)
        {
            if (s.Length == 0)
                yield break;

            int i = -1;
            while (i < s.Length)
            {
                var j = s.IndexOf('.', i + 1);
                if (j == -1)
                    j = s.Length;

                var l = s.Substring(0, Math.Max(i, 0));
                var r = s.Substring(i + 1, j - i - 1);

                yield return Tuple.Create(l, r);

                i = j;
            }
        }


        private void RefreshMetadata(IMetadataProvider provider)
        {
            lock (((ICollection)_swisEntities).SyncRoot)
            {
                _swisEntities.Clear();

                _swisEntities[""] = new SwisEntity(); // always required

                // create set of swisentities for namespaces (for autocomplete, there is no difference between namespace and entity).
                // orion.npm creates namespace orion, with column / navigationproperty 'npm', pointing to orion.npm namespace
                // and orion.npm namespace
                // we can have overlap between namespace and entity, and that is something we can live with right now.
                foreach (var ns in provider.Tables.Select(x => x.Namespace).Distinct())
                {
                    if (!_swisEntities.ContainsKey(ns))
                        _swisEntities.Add(ns, new SwisEntity());

                    foreach (var partPortion in ParsePaths(ns))
                    {
                        SwisEntity swisEntity;

                        if (!_swisEntities.TryGetValue(partPortion.Item1, out swisEntity))
                            _swisEntities[partPortion.Item1] = swisEntity = new SwisEntity();

                        swisEntity.ColumnNames.Add(partPortion.Item2);
                        swisEntity.NavigationProperties[partPortion.Item2] = string.IsNullOrEmpty(partPortion.Item1) ? partPortion.Item2 : partPortion.Item1 + "." + partPortion.Item2;
                    }
                }

                foreach (var entity in provider.Tables)
                {
                    var namespaceSwisEntity = _swisEntities[entity.Namespace];

                    var entityName = GetNamespaceAndNameForEntity(entity.FullName).Item2;
                    namespaceSwisEntity.ColumnNames.Add(entityName);
                    namespaceSwisEntity.NavigationProperties[entityName] = entity.FullName;


                    SwisEntity swisEntity;
                    if (!_swisEntities.TryGetValue(entity.FullName, out swisEntity))
                        _swisEntities[entity.FullName] = swisEntity = new SwisEntity();
                    
                    foreach (var column in entity.Properties)
                    {
                        swisEntity.ColumnNames.Add(column.Name);
                        if (column.IsNavigable)
                        {
                            swisEntity.NavigationProperties[column.Name] = column.Type;
                        }
                    }
                }
            }
        }

        // returns namespace + name for given entity
        // from a.b.c.d creates (a.b.c, d)
        private static Tuple<string, string> GetNamespaceAndNameForEntity(string entityFullName)
        {
            var lastDot = entityFullName.LastIndexOf('.');
            if (lastDot == -1)
                return Tuple.Create("", entityFullName);
            return Tuple.Create(entityFullName.Substring(0, lastDot), entityFullName.Substring(lastDot + 1));
        }

        private void OnProviderEntitiesRefreshed(object sender, EventArgs args)
        {
            RefreshMetadata((IMetadataProvider) sender);
        }

        private Action Unsubscribe;

        public void SetMetadata(IMetadataProvider provider)
        {
            Unsubscribe?.Invoke();
            Unsubscribe = () => provider.EntitiesRefreshed -= OnProviderEntitiesRefreshed;
            provider.EntitiesRefreshed += OnProviderEntitiesRefreshed;
            RefreshMetadata(provider);
        }

        static LexerService()
        {
            BasicAutoCompletionKeywords =
                LexerKeywords.SelectMany(x => x.Item2).Select(x => x.ToUpper()).OrderBy(x => x).ToList();
        }

        public LexerService(ILexerDataSource lexerDataSource)
        {
            _lexerDataSource = lexerDataSource;
        }

        public static IEnumerable<Tuple<int, IEnumerable<string>>> LexerKeywords
        {
            get
            {
                yield return new Tuple<int, IEnumerable<string>>(0,
                    @"all any and as asc between class desc distinct exists false full group having in inner into is isa from join left like not null or outer right select set some true union where end when then else case on top return xml raw auto with limitation rows to order by desc totalrows noplancache queryplan querystats"
                        .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries));
                // User Keywords 1 - scalar functions
                yield return new Tuple<int, IEnumerable<string>>(4,
                    @"toutc tolocal getdate getutcdate datetime isnull tostring escapeswisurivalue splitstringtoarray floor round ceiling yeardiff monthdiff weekdiff daydiff hourdiff minutediff seconddiff milliseconddiff year quarterofyear dayofyear month week day hour minute second millisecond uriequals arraycontains datetrunc changetimezone toupper tolower concat substring adddate addyear addmonth addweek addday addhour addminute addsecond addmillisecond arraylength arrayvalueat"
                        .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries));
                // User Keywords 2 - aggregate functions
                yield return new Tuple<int, IEnumerable<string>>(5,
                    @"min max avg count sum"
                        .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries));
            }
        }

        public IEnumerable<string> GetAutoCompletionKeywords(int textPos)
        {
            var state = DetectAutoCompletion(_lexerDataSource.Text, textPos);

            if (state.Type.HasFlag(ExpectedCaretPositionType.Column) ||
                state.Type.HasFlag(ExpectedCaretPositionType.Entity))
            {
                lock (((ICollection)_swisEntities).SyncRoot)
                {
                    foreach (var v in FollowNavigationProperties(state.ProposedEntity ?? ""))
                        yield return v;
                }
            }

            if (state.Type.HasFlag(ExpectedCaretPositionType.Keyword))
                foreach (var k in BasicAutoCompletionKeywords)
                    yield return k;
        }

        /// <summary>
        /// follows the entity, and suggests navigation properties values.
        /// example: Orion.Node.Volumes.Statistics.
        ///     looks up if Orion is navigatoin property on "" namespace. it is, follows
        ///     looks up if Orion.Node is navigation property on Orion namespace. it is, follows
        ///     looks up if Orion.Node.Volumes is navigation property (it is), so it follows up in Orion.Volumes
        ///     looks up if Orion.Volumes is navigation property (it is), so follows up in Orion.VolumesStatistics
        ///     ..
        ///     and iterates given entity
        /// </summary>
        /// <param name="proposedEntity"></param>
        /// <returns></returns>
        private IEnumerable<string> FollowNavigationProperties(string proposedEntity)
        {
            // we haven't got properly filled entities. 
            if (!_swisEntities.ContainsKey(""))
                return Enumerable.Empty<string>();

            var ns = _swisEntities[""];

            foreach (var dot in ParsePaths(proposedEntity))
            {
                if (ns.NavigationProperties.ContainsKey(dot.Item2) && _swisEntities.ContainsKey(ns.NavigationProperties[dot.Item2]))
                {
                    ns = _swisEntities[ns.NavigationProperties[dot.Item2]];
                }
                else
                {
                    return Enumerable.Empty<string>();
                }
            }

            return ns.ColumnNames;
        }

        private static ExpectedCaretPosition DetectAutoCompletion(string text, int textPos)
        {
            if (Settings.Default.AutocompleteEnabled)
                return new AutocompleteProvider(text).ParseFor(textPos);
            else
                return new ExpectedCaretPosition(ExpectedCaretPositionType.Keyword, null);
        }

        public void Dispose()
        {
            Unsubscribe?.Invoke();
            Unsubscribe = null;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SwqlStudio.Intellisense;

namespace SwqlStudio
{
    public interface ILexerDataSource
    {
        string Text { get; }
    }
    internal class LexerService
    {
        private readonly ILexerDataSource _lexerDataSource;
        private static List<string> BasicAutoCompletionKeywords { get; }

        private readonly Dictionary<string, HashSet<string>> _columnNames = new Dictionary<string, HashSet<string>>(StringComparer.OrdinalIgnoreCase);

        // splits the string by '.', and adds all of the values
        // so a.b.c ->
        // columnnames[a].add(b)
        // columnnames[a.b].add(c)
        private void ApplyToColumnNames(string s)
        {
            int i = -1;
            while (i < s.Length)
            {
                var j = s.IndexOf('.', i + 1);
                if (j == -1)
                    j = s.Length;

                var l = s.Substring(0, Math.Max(i, 0));
                var r = s.Substring(i + 1, j - i - 1);

                if (!_columnNames.ContainsKey(l))
                    _columnNames.Add(l, new HashSet<string>());

                _columnNames[l].Add(r);
                
                i = j;
            }
        }

        private void RefreshMetadata(IMetadataProvider provider)
        {
            lock (((ICollection)_columnNames).SyncRoot)
            {
                _columnNames.Clear();

                foreach (var entity in provider.Tables)
                {
                    ApplyToColumnNames(entity.FullName);

                    foreach (var column in entity.Properties)
                    {
                        ApplyToColumnNames(entity.FullName + "." + column.Name);
                    }
                }
            }
        }

        public void SetMetadata(IMetadataProvider provider)
        {
            provider.EntitiesRefreshed += (sender, args) =>
            {
                RefreshMetadata(provider);
            };
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

        /// <summary>
        /// lexer can be disabled in case of troubles
        /// </summary>
        public static bool Enabled { get; set; }

        public IEnumerable<string> GetAutoCompletionKeywords(int textPos)
        {
            var state = DetectAutoCompletion(_lexerDataSource.Text, textPos);

            if (state.Type.HasFlag(ExpectedCaretPositionType.Column) ||
                state.Type.HasFlag(ExpectedCaretPositionType.Entity))
            {
                lock (((ICollection) _columnNames).SyncRoot)
                {
                    HashSet<string> variants;
                    if (_columnNames.TryGetValue(state.ProposedEntity ?? "", out variants))
                    {
                        foreach (var v in variants)
                            yield return v;
                    }
                }
            }

            if (state.Type.HasFlag(ExpectedCaretPositionType.Keyword))
                foreach (var k in BasicAutoCompletionKeywords)
                    yield return k;
        }

        private ExpectedCaretPosition DetectAutoCompletion(string text, int textPos)
        {
            if (Enabled)
                return new IntellisenseProvider(text).ParseFor(textPos);
            else
                return new ExpectedCaretPosition(ExpectedCaretPositionType.Keyword, null);
        }

    }
}

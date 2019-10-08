using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SwqlStudio.Metadata
{
    class SwisMetaDataProvider : IMetadataProvider
    {
        private readonly ConnectionInfo info;

        private Dictionary<string, Entity> entities = new Dictionary<string, Entity>();

        public SwisMetaDataProvider(ConnectionInfo info)
        {
            this.info = info;
            Name = info.Title;
            _capabilities = new Lazy<Capability>(GetCapabilities);
        }

        private readonly Lazy<Capability> _capabilities;
        private Capability Capabilities => _capabilities.Value;

        private readonly IEnumerable<string> _metadataDefaultAttributes = new[]
        {
            "Entity.FullName", "Entity.Namespace", "Entity.BaseType",
            "(Entity.Type ISA 'System.Indication') AS IsIndication",
            "Entity.Properties.Name", "Entity.Properties.Type", "Entity.Properties.IsNavigable",
            "Entity.Properties.IsInherited", "Entity.Properties.IsKey", "Entity.Verbs.EntityName", "Entity.Verbs.Name",
            "Entity.IsAbstract"
        };

        private IEnumerable<string> AccessControlMetadataAttributes => Capabilities.HasFlag(Capability.AccessControl)
            ? new[] {"Entity.CanCreate", "Entity.CanDelete", "Entity.CanInvoke", "Entity.CanRead", "Entity.CanUpdate"}
            : new string[0];

        private IEnumerable<string> DocumentationMetadataAttributes => Capabilities.HasFlag(Capability.Documentation)
            ? new[] { "Entity.Summary", "Entity.Properties.Summary", "Entity.Verbs.Summary" }
            : new string[0];

        private IEnumerable<string> ObsoleteMetadataAttributes => Capabilities.HasFlag(Capability.Obsolete)
            ? new[] { "Entity.IsObsolete", "Entity.ObsolescenceReason", "Entity.Properties.IsObsolete", "Entity.Properties.ObsolescenceReason",
                      "Entity.Verbs.IsObsolete", "Entity.Verbs.ObsolescenceReason" }
            : new string[0];

        private IEnumerable<string> MetadataAttributes => _metadataDefaultAttributes
            .Concat(AccessControlMetadataAttributes).Concat(DocumentationMetadataAttributes).Concat(ObsoleteMetadataAttributes);

        public void Refresh()
        {
            string query = $"SELECT {string.Join(",", MetadataAttributes)} FROM Metadata.Entity";

            entities = info.Query<Entity>(query).ToDictionary(entity => entity.FullName);

            foreach (var entity in entities.Values)
            {
                if (entity.BaseType != null && entities.TryGetValue(entity.BaseType, out var baseEntity))
                    entity.BaseEntity = baseEntity;
            }

            EntitiesRefreshed?.Invoke(this, new EventArgs());
        }

        [Flags]
        public enum Capability
        {
            None = 0,
            AccessControl = 1,
            Documentation = 2,
            Obsolete = 4,
        }

        public Capability GetCapabilities()
        {
            const string query = @"SELECT Name
FROM Metadata.Property
WHERE EntityName='Metadata.Entity' AND Name IN ('CanCreate', 'Summary', 'IsObsolete')";

            Capability cap = Capability.None;
            DataTable dt = info.Query(query);
            foreach (DataRow row in dt.Rows)
            {
                if ((string) row["Name"] == "CanCreate")
                    cap |= Capability.AccessControl;
                else if ((string) row["Name"] == "Summary")
                    cap |= Capability.Documentation;
                else if ((string) row["Name"] == "IsObsolete")
                    cap |= Capability.Obsolete;
            }

            return cap;
        }

        public IEnumerable<VerbArgument> GetVerbArguments(Verb verb)
        {
            return info.Query<VerbArgument>(
                string.Format(
                    "SELECT VerbArgument.Name, VerbArgument.Type, VerbArgument.Position " +
                    (XmlTemplateSupported ? ", VerbArgument.XmlTemplate " : "") +
                    (_capabilities.Value.HasFlag(Capability.Documentation) ? ", VerbArgument.Summary " : "") +
                    "FROM Metadata.VerbArgument WHERE VerbArgument.EntityName='{0}' AND VerbArgument.VerbName='{1}' " +
                    "ORDER BY VerbArgument.Position",
                    verb.EntityName, verb.Name));
        }

        protected bool XmlTemplateSupported
        {
            get { return entities["Metadata.VerbArgument"].Properties.Any(p => p.Name == "XmlTemplate"); }
        }

        public ConnectionInfo ConnectionInfo
        {
            get { return info; }
        }

        public string Name { get; private set; }

        public IEnumerable<Entity> Tables
        {
            get
            {
                if (entities == null)
                    Refresh();

                return entities.Values.OrderBy(t => t.FullName);
            }
        }

        /// <inheritdoc />
        public event EventHandler EntitiesRefreshed;
    }
}

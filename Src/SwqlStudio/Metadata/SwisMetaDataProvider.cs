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

        public void Refresh()
        {

            const string queryTemplate =
                @"SELECT Entity.FullName, Entity.Namespace, Entity.BaseType, (Entity.Type ISA 'System.Indication') AS IsIndication,
	Entity.Properties.Name, Entity.Properties.Type, Entity.Properties.IsNavigable, Entity.Properties.IsInherited, Entity.Properties.IsKey,
	Entity.Verbs.EntityName, Entity.Verbs.Name, Entity.IsAbstract{0}{1}
FROM Metadata.Entity";
            const string crudFragment =
                ", Entity.CanCreate, Entity.CanDelete, Entity.CanInvoke, Entity.CanRead, Entity.CanUpdate";
            const string docFragment = ", Entity.Summary, Entity.Properties.Summary, Entity.Verbs.Summary";

            var capabilities = _capabilities.Value;
            string query = string.Format(queryTemplate, capabilities.HasFlag(Capability.AccessControl) ? crudFragment : string.Empty,
                capabilities.HasFlag(Capability.Documentation) ? docFragment : string.Empty);

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
        }

        public Capability GetCapabilities()
        {
            const string query = @"SELECT Name
FROM Metadata.Property
WHERE EntityName='Metadata.Entity' AND Name IN ('CanCreate', 'Summary')";

            Capability cap = Capability.None;
            DataTable dt = info.Query(query);
            foreach (DataRow row in dt.Rows)
            {
                if ((string)row["Name"] == "CanCreate")
                    cap |= Capability.AccessControl;
                else if ((string)row["Name"] == "Summary")
                    cap |= Capability.Documentation;
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using SwqlStudio.Metadata;

namespace SwqlStudio
{
    class SwisMetaDataProvider : IMetadataProvider
    {
        private readonly ConnectionInfo info;

        private Dictionary<string, Entity> entities = new Dictionary<string, Entity>();
        
        public SwisMetaDataProvider(ConnectionInfo info)
        {
            this.info = info;
            Name = info.Title;
        }

        public void Refresh()
        {

            const string queryTemplate =
                @"SELECT Entity.FullName, Entity.Namespace, Entity.BaseType, (Entity.Type ISA 'System.Indication') AS IsIndication,
	Entity.Properties.Name, Entity.Properties.Type, Entity.Properties.IsNavigable, Entity.Properties.IsInherited, Entity.Properties.IsKey,
	Entity.Verbs.EntityName, Entity.Verbs.Name, Entity.IsAbstract{0}
FROM Metadata.Entity";
            const string crudFragment =
                ", Entity.CanCreate, Entity.CanDelete, Entity.CanInvoke, Entity.CanRead, Entity.CanUpdate";

            string query = string.Format(queryTemplate, SupportsAccessControl() ? crudFragment : string.Empty);

            entities = info.Query<Entity>(query).ToDictionary(entity => entity.FullName);

            foreach (var entity in entities.Values)
            {
                Entity baseEntity;
                if (entity.BaseType != null && entities.TryGetValue(entity.BaseType, out baseEntity))
                    entity.BaseEntity = baseEntity;
            }

            EntitiesRefreshed?.Invoke(this, new EventArgs());
        }

        public bool SupportsAccessControl()
        {
            const string query = @"SELECT Name
FROM Metadata.Property
WHERE EntityName='Metadata.Entity' AND Name='CanCreate'";

            DataTable dt = info.Query(query);
            return dt != null && dt.Rows.Count == 1;
        }

        public IEnumerable<VerbArgument> GetVerbArguments(Verb verb)
        {
            return info.Query<VerbArgument>(
                string.Format(
                    "SELECT VerbArgument.Name, VerbArgument.Type, VerbArgument.Position " +
                    (XmlTemplateSupported ? ", VerbArgument.XmlTemplate " : "") +
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

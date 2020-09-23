using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace SolarWinds.InformationService.InformationServiceClient
{
    public class EntityClassGraph : IEnumerable<EntityMetadata>
    {

        private readonly Dictionary<string, EntityMetadata> _entities = new Dictionary<string, EntityMetadata>();

        public EntityClassGraph(InformationServiceConnection connection)
        {
            string query = "SELECT FullName, BaseType FROM Metadata.Entity";
            using (var command = new InformationServiceCommand(query, connection))
            using (InformationServiceDataReader dataReader = command.ExecuteReader())
            {
                //Enumerate the rows.
                LoadRows(dataReader);
            }
        }

        /// <summary>
        /// Added for unit tests.
        /// </summary>
        /// <param name="dbDataReader"></param>
        internal EntityClassGraph(DbDataReader dbDataReader)
        {
            LoadRows(dbDataReader);
        }



        public bool TryGetEntity(string fullName, out EntityMetadata entity)
        {
            return _entities.TryGetValue(fullName, out entity);
        }

        public IEnumerable<EntityMetadata> DescendantsOf(string fullName)
        {
            EntityMetadata entity;
            if (!TryGetEntity(fullName, out entity))
            {
                throw new ArgumentException("There is no entity with a full name of " + fullName, nameof(fullName));
            }

            return entity.Descendants;
        }

        /// <summary>
        /// Gets the root entity of this tree.  Assumes that there is only one root.
        /// </summary>
        public EntityMetadata Root
        {
            get
            {
                if (_entities.Count == 0)
                    return null;

                return _entities.First().Value.RootBaseClass;
            }
        }


        IEnumerator<EntityMetadata> IEnumerable<EntityMetadata>.GetEnumerator()
        {
            return _entities.Values.GetEnumerator();
        }


        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _entities.Values.GetEnumerator();
        }

        private void LoadRows(DbDataReader dataReader)
        {
            while (dataReader.Read())
            {
                LoadEntity(dataReader);
            }
        }


        private void LoadEntity(DbDataReader dataReader)
        {
            string fullName = dataReader.GetString(0);
            string baseType = dataReader.GetString(1);


            //Try to find the entity
            EntityMetadata entity;
            if (!_entities.TryGetValue(fullName, out entity))
            {
                //Create new instance of the entity
                entity = new EntityMetadata(fullName);

                _entities.Add(fullName, entity);
            }

            //This entity is at the top of the class hierarchy.
            if (string.IsNullOrEmpty(baseType))
                return;

            //Try to find the base entity
            EntityMetadata baseEntity = null;
            if (!_entities.TryGetValue(baseType, out baseEntity))
            {
                //Create new instance of the base entity
                if (!string.IsNullOrEmpty(baseType))
                {
                    baseEntity = new EntityMetadata(baseType);
                    _entities.Add(baseType, baseEntity);
                }
            }

            //Make the parent/child two-way relationship between the two.
            baseEntity.AddClassRelationships(entity);

        }

    }
}

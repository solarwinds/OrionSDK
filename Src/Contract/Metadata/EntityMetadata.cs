using System.Collections.Generic;

namespace SolarWinds.InformationService.InformationServiceClient
{
    public class EntityMetadata
    {
        private List<EntityMetadata> _DerivedClasses = new List<EntityMetadata>();

        public EntityMetadata(string fullName)
        {
            FullName = fullName;
        }

        public string FullName { get; internal set; }
        public EntityMetadata BaseClass { get; private set; }
        public IEnumerable<EntityMetadata> DerivedClasses { get { return _DerivedClasses; } }

        /// <summary>
        /// Enumerates all decendants of this class in pre-fix order.  (i.e. children, grandchildren, and so on.) 
        /// </summary>
        public IEnumerable<EntityMetadata> Descendants
        {
            get
            {
                foreach (EntityMetadata child in DerivedClasses)
                {
                    yield return child;
                    foreach (EntityMetadata descendant in child.Descendants)
                    {
                        yield return descendant;
                    }
                }
            }
        }

        public bool IsDescendantOf(string baseClass)
        {
            EntityMetadata currentBaseClass = BaseClass;
            while (currentBaseClass != null)
            {
                if (string.Compare(currentBaseClass.FullName, baseClass) == 0)
                    return true;

                currentBaseClass = currentBaseClass.BaseClass;
            }

            return false;
        }

        /// <summary>
        /// Gets the highest base class ancestor of this class.
        /// </summary>
        public EntityMetadata RootBaseClass
        {
            get
            {
                EntityMetadata currentClass = this;
                for (; currentClass.BaseClass != null; currentClass = currentClass.BaseClass)
                {

                }

                return currentClass;
            }
        }

        internal void AddClassRelationships(EntityMetadata derivedClass)
        {
            _DerivedClasses.Add(derivedClass);
            derivedClass.BaseClass = this;
        }

    }
}

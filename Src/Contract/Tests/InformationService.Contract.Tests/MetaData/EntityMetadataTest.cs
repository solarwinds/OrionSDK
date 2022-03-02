using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using SolarWinds.InformationService.InformationServiceClient;

namespace SolarWinds.InformationService.Contract2
{
    [TestFixture]
    internal class EntityMetadataTest
    {
        [Test]
        public void EntityMetadata_ctor()
        {
            string fullName = "CalebHunter";
            EntityMetadata entityMetadata = new EntityMetadata(fullName);

            Assert.AreEqual(fullName, entityMetadata.FullName);
        }

        [Test]
        public void EntityMetadata_BaseClass()
        {
            EntityMetadata parent = new EntityMetadata("Karen");
            EntityMetadata child = new EntityMetadata("Rachel");

            parent.AddClassRelationships(child);

            Assert.AreSame(parent, child.BaseClass);
        }


        [Test]
        public void EntityMetadata_Descendants()
        {
            EntityMetadata grandparent = new EntityMetadata("Harry");
            EntityMetadata parent = new EntityMetadata("David");
            EntityMetadata child = new EntityMetadata("Morgen");

            grandparent.AddClassRelationships(parent);
            parent.AddClassRelationships(child);

            List<EntityMetadata> descendants = grandparent.Descendants.ToList();

            Assert.True(descendants.Contains(parent), "Grandparent is missing parent");
            Assert.True(descendants.Contains(child), "Grandparent is missing child");
            Assert.False(descendants.Contains(grandparent), "Grandparent is not a descendant of himself");
        }

        [Test]
        public void EntityMetadata_IsDescendantOf()
        {
            EntityMetadata grandparent = new EntityMetadata("Jay");
            EntityMetadata parent = new EntityMetadata("Karen");
            EntityMetadata child = new EntityMetadata("Katy");

            grandparent.AddClassRelationships(parent);
            parent.AddClassRelationships(child);

            Assert.True(parent.IsDescendantOf(grandparent.FullName));
            Assert.True(child.IsDescendantOf(grandparent.FullName));
            Assert.False(grandparent.IsDescendantOf(parent.FullName));
            Assert.False(parent.IsDescendantOf(child.FullName));
            Assert.False(grandparent.IsDescendantOf(child.FullName));
        }

        [Test]
        public void EntityMetadata_RootBaseClass()
        {
            EntityMetadata grandparent = new EntityMetadata("Raymond");
            EntityMetadata parent = new EntityMetadata("Harry");
            EntityMetadata child = new EntityMetadata("David");

            grandparent.AddClassRelationships(parent);
            parent.AddClassRelationships(child);

            Assert.AreSame(grandparent, child.RootBaseClass);
            Assert.AreSame(grandparent, parent.RootBaseClass);
            Assert.AreSame(grandparent, grandparent.RootBaseClass, "The grandparent is his own root base class");
        }

    }
}

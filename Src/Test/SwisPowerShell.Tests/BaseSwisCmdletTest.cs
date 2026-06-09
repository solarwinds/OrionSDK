using System.Collections;
using NUnit.Framework;
using SolarWinds.InformationService.Contract2;

namespace SwisPowerShell.Tests
{
    [TestFixture]
    public class BaseSwisCmdletTest
    {
        [Test]
        public void PropertyBagFromDictionary_Hashtable_Converted()
        {
            var x = new Hashtable { ["key"] = "value" };

            var converted = BaseSwisCmdlet.PropertyBagFromDictionary(x);

            Assert.That(converted, Is.TypeOf<PropertyBag>());
            Assert.That(((PropertyBag)converted)["key"], Is.EqualTo("value"));
        }

        [Test]
        public void PropertyBagFromDictionary_HashtableOfHashtable_Converted()
        {
            var x = new Hashtable
            {
                ["key"] = "value",
                ["subtable"] = new Hashtable
                {
                    ["subkey"] = "subvalue"
                }
            };

            var converted = BaseSwisCmdlet.PropertyBagFromDictionary(x);

            Assert.That(converted, Is.TypeOf<PropertyBag>());
            var bag = (PropertyBag)converted;
            Assert.That(bag["key"], Is.EqualTo("value"));
            var subtableObj = bag["subtable"];
            Assert.That(subtableObj, Is.TypeOf<PropertyBag>());
            var subtable = (PropertyBag)subtableObj;
            Assert.That(subtable["subkey"], Is.EqualTo("subvalue"));
        }

        [Test]
        public void PropertyBagFromDictionary_ListOfHashtable_Converted()
        {
            var x = new object[]
            {
                new Hashtable
                {
                    ["key"] = "value",
                }
            };

            var converted = BaseSwisCmdlet.PropertyBagFromDictionary(x);

            Assert.That(converted, Is.TypeOf<PropertyBag[]>());
            var list = (PropertyBag[])converted;
            Assert.That(list, Has.Length.EqualTo(1));
            var bag = list[0];
            Assert.That(bag["key"], Is.EqualTo("value"));
        }
    }
}

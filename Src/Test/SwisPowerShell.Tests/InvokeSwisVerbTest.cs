using NUnit.Framework;
using SolarWinds.InformationService.Contract2;

namespace SwisPowerShell.Tests
{
    [TestFixture]
    public class InvokeSwisVerbTest
    {
        [Test]
        public void SerializeArgument_BagOfListOfBag_Works()
        {
            var bag = new PropertyBag
            {
                ["list"] = new object[]
                {
                    new PropertyBag
                    {
                        ["foo"] = "bar"
                    }
                }
            };

            var xml = InvokeSwisVerb.SerializeArgument(bag);

            Assert.That(xml.OuterXml, Is.EqualTo(
                @"<dictionary xmlns=""http://schemas.solarwinds.com/2007/08/informationservice/propertybag""><item><key>list</key><type>SolarWinds.InformationService.Contract2.PropertyBag[]</type><value>&lt;dictionary&gt;&lt;item xmlns=""http://schemas.solarwinds.com/2007/08/informationservice/propertybag""&gt;&lt;key&gt;foo&lt;/key&gt;&lt;type&gt;System.String&lt;/type&gt;&lt;value&gt;bar&lt;/value&gt;&lt;/item&gt;&lt;/dictionary&gt;</value></item></dictionary>"));


        }
    }
}

using System.Xml;

namespace SolarWinds.InformationService.Contract2.Bindings
{
    internal class ReaderQuotaHelper
    {
        public static void SetReaderQuotas(XmlDictionaryReaderQuotas readerQuotas)
        {
            readerQuotas.MaxStringContentLength = int.MaxValue;
            readerQuotas.MaxArrayLength = int.MaxValue;
            readerQuotas.MaxBytesPerRead = int.MaxValue;
            readerQuotas.MaxDepth = int.MaxValue;
        }
    }
}

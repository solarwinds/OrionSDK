namespace SwqlStudio
{
    internal class InfoServiceFactory
    {
        public static InfoServiceBase Create(string serverType, string username, string password)
        {
            switch (serverType.ToUpperInvariant())
            {
                case "ORION (V3)":
                    return new OrionInfoService(username, password);

                case "ORION (V3) AD":
                    return new OrionInfoServiceWindows(string.Empty, string.Empty);

                case "ORION (V3) CERTIFICATE":
                    return new OrionInfoServiceCertificate();

                case "ORION (V3) OVER HTTPS":
                    return new OrionHttpsInfoService(username, password);

                case "ORION (V3) OVER HTTPS LEGACY PRE-2023":
                    return new OrionLegacyHttpsInfoService(username, password);
            }

            return null;
        }
    }
}

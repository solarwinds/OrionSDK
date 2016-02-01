namespace SwqlStudio
{
    class InfoServiceFactory
    {
        public static InfoServiceBase Create(string serverType, string username, string password)
        {
            switch (serverType.ToUpperInvariant())
            {
                case "EOC":
                    return new EOCInfoService(username, password);

                case "ORION (V2)":
                    return new OrionInfoService(username, password);

                case "ORION (V2) AD":
                    return new OrionInfoServiceWindows(string.Empty, string.Empty);

                case "ORION (V2) CERTIFICATE":
                    return new OrionInfoServiceCertificate();

                case "ORION (V2) AD COMPRESSED":
                    return new OrionInfoServiceWindowsCompressed(username, password);

                case "ORION (V2) OVER HTTPS":
                    return new OrionHttpsInfoService(username, password);

                case "ORION (V2) COMPRESSED":
                    return new OrionInfoServiceCompressed(username, password);

                case "ORION (V3)":
                    return new OrionInfoService(username, password, isSwisV3: true);

                case "ORION (V3) AD":
                    return new OrionInfoServiceWindows(string.Empty, string.Empty, v3: true);

                case "ORION (V3) CERTIFICATE":
                    return new OrionInfoServiceCertificate(v3: true);

                case "ORION (V3) AD COMPRESSED":
                    return new OrionInfoServiceWindowsCompressed(username, password, v3: true);

                case "ORION (V3) OVER HTTPS":
                    return new OrionHttpsInfoService(username, password, v3: true);

                case "ORION (V3) COMPRESSED":
                    return new OrionInfoServiceCompressed(username, password, v3: true);

                case "NCM":
                    return new NCMInfoService(username, password);

                case "NCM (WINDOWS AUTHENTICATION)":
                    return new NCMWindowsAuthInfoService(username, password);

                case "NCM INTEGRATION":
                    return new NCMForwarderInfoService(username, password);

                case "JAVA OVER HTTP":
                    return new JavaHttpInfoService(username, password);
            }

            return null;
        }
    }
}

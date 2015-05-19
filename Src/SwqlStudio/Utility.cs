using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace SwqlStudio
{
    static class Utility
    {
        public static string GetFqdn()
        {
            string domainName = string.Empty;
            try
            {
                domainName = System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName;
            }
            catch
            {
            }
            string fqdn = "localhost";
            try
            {
                fqdn = Dns.GetHostName();
                if (!string.IsNullOrEmpty(domainName))
                {
                    if (!fqdn.ToLowerInvariant().EndsWith("." + domainName.ToLowerInvariant()))
                    {
                        fqdn += "." + domainName;
                    }
                }
            }
            catch
            {
            }
            return fqdn;
        }
    }
}

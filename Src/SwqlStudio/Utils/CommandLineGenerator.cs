using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using SolarWinds.InformationService.Contract2;

namespace SwqlStudio.Utils
{
    internal static class CommandLineGenerator
    {
        public const int LegacyRestPort = 17778;
        public const int RestPort = 17774;

        public static string GetQueryForCurlCmd(string query, ConnectionInfo connection, PropertyBag parameters)
        {
            return GetQueryForCurlCmdInternal(query, connection, parameters, RestPort);
        }

        public static string GetQueryForLegacyCurlCmd(string query, ConnectionInfo connection, PropertyBag parameters)
        {
            return GetQueryForCurlCmdInternal(query, connection, parameters, LegacyRestPort);
        }

        public static string GetQueryForCurlBash(string query, ConnectionInfo connection, PropertyBag parameters)
        {
            return GetQueryForCurlBashInternal(query, connection, parameters, RestPort);
        }
        public static string GetQueryForLegacyCurlBash(string query, ConnectionInfo connection, PropertyBag parameters)
        {
            return GetQueryForCurlBashInternal(query, connection, parameters, LegacyRestPort);
        }

        public static string GetQueryForPowerShellGetSwisData(string query, ConnectionInfo connection, PropertyBag parameters)
        {
            Func<string, string> q = QuoteForPowerShell;
            var paramsObjectString = GetParamsObjectInPowershellFormat(parameters);
            return $"Get-SwisData (Connect-Swis -Hostname {connection.Server} -Username {q(connection.UserName)} " +
                   $"-Password {q(connection.Password)}) -Query {q(CollapseWhitespace(query))} -Parameters {paramsObjectString}";
        }

        private static string GetQueryForCurlCmdInternal(string query, ConnectionInfo connection, PropertyBag parameters, int port)
        {
            string creds = QuoteForCmd($"{connection.UserName}:{connection.Password}");
            if (!parameters.Any())
            {
                return $"curl.exe -k -u {creds} {GetUrlForQuery(query, connection, port)}";
            }
            else
            {
                var escapedQuery = CollapseWhitespace(query);
                var postUrl = GetUrlForQuery(null, connection, port);
                var parametersSerialized = string.Join(
                ",",
                parameters.Select(x => string.Format("\"{0}\" : \"{1}\"", x.Key, x.Value.ToString())));

                var postData = $"{{ \"query\": \"{escapedQuery}\", \"parameters\": {{{parametersSerialized}}}".Replace("\"", "\\\"");

                return $"curl -X POST -d \"{postData}}}\" {postUrl} --insecure -u {creds} --header \"Content-Type:application/json\"";
            }
        }

        private static string GetQueryForCurlBashInternal(string query, ConnectionInfo connection, PropertyBag parameters, int port)
        {
            string creds = $"{connection.UserName}:{connection.Password}";
            var url = GetUrlForQuery(query, connection, port);
            Func<string, string> q = QuoteForBash;
            if (!parameters.Any())
            {
                return $"curl -k -u {QuoteForBash(creds)} {QuoteForBash(url)}";
            }
            else
            {
                return GetQueryForCurlCmdInternal(query, connection, parameters, port);
            }
        }

        private static string GetParamsObjectInPowershellFormat(PropertyBag parameters)
        {
            var parametersSerialized = string.Join(
                ";",
                parameters.Select(x => string.Format("{0}={1}", x.Key, QuoteForPowerShell(x.Value.ToString()))));

            return string.Format("@{{{0}}}", parametersSerialized.ToString());
        }

        private static string GetUrlForQuery(string query, ConnectionInfo connection, int port)
        {
            string queryEndpoint = $"https://{connection.Server}:{port}/SolarWinds/InformationService/v3/Json/Query";

            if (string.IsNullOrEmpty(query))
                return queryEndpoint;

            var encodedQuery = HttpUtility.UrlEncode(CollapseWhitespace(query));
            return $"{queryEndpoint}?query={encodedQuery}";
        }

        private static string CollapseWhitespace(string str)
        {
            return Regex.Replace(str.Trim(), @"\s+", " ");
        }

        /// <summary>
        /// Prepares a command line argument for the trip through CreateProcess, wrapping it in double quotes if necessary and dealing with escaping. Based on https://blogs.msdn.microsoft.com/twistylittlepassagesallalike/2011/04/23/everyone-quotes-command-line-arguments-the-wrong-way/
        /// </summary>
        /// <param name="arg">An unquoted command line parameter</param>
        /// <returns>The parameter ready for appending to the command line</returns>
        private static string QuoteForCmd(string arg)
        {
            if (arg.Length > 0 && arg.IndexOfAny(new[] { ' ', '\t', '\n', '\v', '"' }) == -1)
            {
                return arg;
            }

            var quoted = new StringBuilder();
            quoted.Append('"');
            int pendingBackslashes = 0;
            foreach (char c in arg)
            {
                if (c == '\\')
                {
                    ++pendingBackslashes;
                }
                else if (c == '"')
                {
                    quoted.Append('\\', pendingBackslashes * 2 + 1);
                    quoted.Append('"');
                    pendingBackslashes = 0;
                }
                else
                {
                    quoted.Append('\\', pendingBackslashes);
                    quoted.Append(c);
                    pendingBackslashes = 0;
                }
            }
            quoted.Append('\\', pendingBackslashes * 2);
            quoted.Append('"');

            return quoted.ToString();
        }

        private static string QuoteForBash(string arg)
        {
            if (arg.IndexOf('\'') == -1)
                return arg;

            var quoted = new StringBuilder("'");

            foreach (char c in arg)
            {
                if (c == '\'')
                    quoted.Append(@"'\''");
                else
                    quoted.Append(c);
            }

            quoted.Append('\'');
            return quoted.ToString();
        }

        private static string QuoteForPowerShell(string arg)
        {
            var quoted = new StringBuilder("'");

            foreach (char c in arg)
            {
                if (c == '\'')
                    quoted.Append("''");
                else
                    quoted.Append(c);
            }

            quoted.Append('\'');
            return quoted.ToString();
        }
    }
}

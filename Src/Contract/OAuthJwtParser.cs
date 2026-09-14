using System;
using System.Text;

namespace SolarWinds.InformationService.Contract2
{
    internal static class OAuthJwtParser
    {
        internal static string ExtractUsername(string jwt)
        {
            if (string.IsNullOrEmpty(jwt))
                return null;

            string[] parts = jwt.Split('.');
            if (parts.Length < 2)
                return null;

            try
            {
                string payload = parts[1].Replace('-', '+').Replace('_', '/');
                payload += new string('=', (4 - payload.Length % 4) % 4);
                string json = Encoding.UTF8.GetString(Convert.FromBase64String(payload));

                foreach (string claim in new[] { "preferred_username", "email", "sub" })
                {
                    string key = $"\"{claim}\":\"";
                    int start = json.IndexOf(key, StringComparison.Ordinal);
                    if (start < 0) continue;
                    start += key.Length;
                    int end = json.IndexOf('"', start);
                    if (end > start)
                        return json.Substring(start, end - start);
                }
            }
            catch { }

            return null;
        }
    }
}

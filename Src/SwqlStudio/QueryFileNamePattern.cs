using System;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

namespace SwqlStudio
{
    internal static class QueryFileNamePattern
    {
        internal const string DefaultPattern = "{timestamp:yyyy-MM-dd HH-mm} {entity}";

        private static readonly Regex TokenRegex = new Regex(
            @"\{timestamp(?::([^{}]+))?\}|\{entity\}", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        internal static string Format(string pattern, string entityName, DateTime timestamp)
        {
            if (string.IsNullOrWhiteSpace(pattern))
                throw new ArgumentException("A filename pattern is required.", nameof(pattern));

            var hasTimestamp = false;
            var fileName = TokenRegex.Replace(pattern, match =>
            {
                if (string.Equals(match.Value, "{entity}", StringComparison.OrdinalIgnoreCase))
                    return entityName ?? string.Empty;

                hasTimestamp = true;
                var format = match.Groups[1].Success ? match.Groups[1].Value : "yyyy-MM-dd HH-mm";
                return timestamp.ToString(format, CultureInfo.InvariantCulture);
            });

            if (!hasTimestamp || fileName.Contains("{") || fileName.Contains("}"))
                throw new ArgumentException("Use {timestamp:format} and {entity} placeholders.", nameof(pattern));

            fileName = Regex.Replace(fileName, @"\s+", " ").Trim();
            foreach (var invalidCharacter in Path.GetInvalidFileNameChars())
                fileName = fileName.Replace(invalidCharacter, '_');

            if (fileName.Length == 0)
                throw new ArgumentException("The filename pattern produced an empty name.", nameof(pattern));

            return fileName.EndsWith(".swql", StringComparison.OrdinalIgnoreCase)
                ? fileName
                : fileName + ".swql";
        }

        internal static bool TryFormat(string pattern, string entityName, DateTime timestamp, out string fileName)
        {
            try
            {
                fileName = Format(pattern, entityName, timestamp);
                return true;
            }
            catch (ArgumentException)
            {
                fileName = null;
                return false;
            }
            catch (FormatException)
            {
                fileName = null;
                return false;
            }
        }
    }
}
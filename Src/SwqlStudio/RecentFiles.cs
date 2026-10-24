using System;
using System.Collections.Generic;
using System.Linq;
using SwqlStudio.Properties;

namespace SwqlStudio
{
    internal static class RecentFiles
    {
        private const int MaxCount = 10;
        // '|' cannot appear in Windows paths, unlike ';'.
        private const char Separator = '|';

        public static string[] Items => Parse(Settings.Default.RecentFiles);

        public static void Add(string fileName)
        {
            Store(Add(Items, fileName, MaxCount));
        }

        public static void Remove(string fileName)
        {
            Store(Items.Where(i => !IsSameFile(i, fileName)));
        }

        public static void Clear()
        {
            Store(Enumerable.Empty<string>());
        }

        internal static string[] Add(IEnumerable<string> items, string fileName, int maxCount)
        {
            return new[] { fileName }
                .Concat(items.Where(i => !IsSameFile(i, fileName)))
                .Take(maxCount)
                .ToArray();
        }

        internal static string[] Parse(string packed)
        {
            return (packed ?? string.Empty).Split(new[] { Separator }, StringSplitOptions.RemoveEmptyEntries);
        }

        private static bool IsSameFile(string left, string right)
        {
            return string.Equals(left, right, StringComparison.OrdinalIgnoreCase);
        }

        private static void Store(IEnumerable<string> items)
        {
            Settings.Default.RecentFiles = string.Join(Separator.ToString(), items);
            Settings.Default.Save();
        }
    }
}

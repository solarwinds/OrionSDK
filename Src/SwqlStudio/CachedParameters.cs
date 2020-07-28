using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using SolarWinds.InformationService.Contract2;

namespace SwqlStudio
{
    internal class CachedParameters
    {
        private static readonly Regex queryParamRegEx = new Regex(@"\@([\w.$]+|""[^""]+""|'[^']+')(?(=\[(.*?)\]))", RegexOptions.Compiled);
        private static readonly Dictionary<string, object> lastKnownValues = new Dictionary<string, object>();
        private PropertyBag current = new PropertyBag();

        private static string unknownValue = string.Empty;

        internal void Put(PropertyBag toPreserve)
        {
            current = toPreserve;
            MarkLastKnownValues(toPreserve);
        }

        internal PropertyBag Get(string query)
        {
            var parsed = ParseText(query);
            UpdateFromCachedValues(parsed);
            Put(parsed);
            return parsed;
        }

        private static PropertyBag ParseText(string query)
        {
            var parsed = new PropertyBag();

            foreach (Match item in queryParamRegEx.Matches(query))
            {
                string paramName = item.Groups[1].Value;
                string paramValue = item.Groups[2].Success ? item.Groups[2].Value : unknownValue;
                parsed[paramName] = paramValue;
            }

            return parsed;
        }

        private void UpdateFromCachedValues(PropertyBag toUpdate)
        {
            UpdateFrom(toUpdate, lastKnownValues);
            UpdateFrom(toUpdate, current);
            MarkLastKnownValues(toUpdate);
            QuessRenamedParameter(toUpdate);
        }

        private void UpdateFrom(PropertyBag toUpdate, Dictionary<string, object> source)
        {
            foreach (var key in source.Keys.Where(toUpdate.ContainsKey))
            {
                // update from cache only in case value wasn't fetched from query already
                if (ReferenceEquals(toUpdate[key], unknownValue))
                {
                    toUpdate[key] = source[key];
                }
            }
        }

        private void MarkLastKnownValues(PropertyBag toUpdate)
        {
            foreach (var variable in toUpdate)
            {
                string lastKnownValue = variable.Value?.ToString();

                if (!String.IsNullOrEmpty(lastKnownValue))
                    lastKnownValues[variable.Key] = lastKnownValue;
            }
        }

        private void QuessRenamedParameter(PropertyBag toUpdate)
        {
            // we are able to identify only one renamed parameter using this simple concept
            var added = toUpdate.Keys.Except(current.Keys).ToList();
            var removed = current.Keys.Except(toUpdate.Keys).ToList();
            if (added.Count == 1 && removed.Count == 1)
            {
                toUpdate[added.First()] = current[removed.First()];
            }
        }
    }
}
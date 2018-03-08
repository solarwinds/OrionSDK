using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using SolarWinds.InformationService.Contract2;

namespace SwqlStudio
{
    internal class CachedParameters
    {
        private static readonly Regex queryParamRegEx = new Regex(@"\@([\w.$]+|""[^""]+""|'[^']+')", RegexOptions.Compiled);
        private static readonly Dictionary<string, string> lastKnownValues = new Dictionary<string, string>();
        private PropertyBag current = new PropertyBag();

        internal void Put(PropertyBag toPreserve)
        {
            this.current = toPreserve;
        }

        internal PropertyBag Get(string query)
        {
            var parsed = ParseText(query);
            UpdateFromCachedValues(parsed);
            this.Put(parsed);
            return parsed;
        }

        private static PropertyBag ParseText(string query)
        {
            var parsed = new PropertyBag();

            foreach (Match item in queryParamRegEx.Matches(query))
            {
                string paramName = item.Value.Substring(1);
                parsed[paramName] = string.Empty;
            }

            return parsed;
        }

        private void UpdateFromCachedValues(PropertyBag toUpdate)
        {
            UpdateFromLastKnown(toUpdate);
            UpdateWithCurrentValues(toUpdate);
            QuessRenamedParameter(toUpdate);
        }

        private void UpdateFromLastKnown(PropertyBag toUpdate)
        {
            foreach (string preservedKey in lastKnownValues.Keys.Where(toUpdate.ContainsKey))
            {
                toUpdate[preservedKey] = lastKnownValues[preservedKey];
            }
        }

        private void UpdateWithCurrentValues(PropertyBag toUpdate)
        {
            foreach (var variable in this.current)
            {
                if (toUpdate.ContainsKey(variable.Key))
                {
                    toUpdate[variable.Key] = variable.Value;
                }
                else
                {
                    string lastKnownValue = variable.Value?.ToString();
                        
                    if (!String.IsNullOrEmpty(lastKnownValue))
                        lastKnownValues[variable.Key] = lastKnownValue;
                }
            }
        }

        private void QuessRenamedParameter(PropertyBag toUpdate)
        {
            // we are able to identify only one renamed parameter using this simple concept
            var added = toUpdate.Keys.Except(this.current.Keys).ToList();
            var removed = this.current.Keys.Except(toUpdate.Keys).ToList();
            if (added.Count == 1 && removed.Count == 1)
            {
                toUpdate[added.First()] = this.current[removed.First()];
            }
        }
    }
}
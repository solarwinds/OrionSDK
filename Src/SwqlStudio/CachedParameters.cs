using System;
using System.Collections.Generic;
using System.Linq;
using SolarWinds.InformationService.Contract2;

namespace SwqlStudio
{
    internal class CachedParameters
    {
        private readonly Dictionary<string, string> lastKnownValues = new Dictionary<string, string>();

        internal void UpdateFromCachedValues(PropertyBag toUpdate, PropertyBag current)
        {
            UpdateFromLastKnown(toUpdate);
            UpdateWithCurrentValues(toUpdate, current);
            QuessRenamedParameter(toUpdate, current);
        }

        private void UpdateFromLastKnown(PropertyBag propertyBag)
        {
            foreach (string preservedKey in lastKnownValues.Keys.Where(propertyBag.ContainsKey))
            {
                propertyBag[preservedKey] = lastKnownValues[preservedKey];
            }
        }

        private void UpdateWithCurrentValues(PropertyBag toUpdate, PropertyBag current)
        {
            foreach (var variable in current)
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

        private void QuessRenamedParameter(PropertyBag propertyBag, PropertyBag currentVariables)
        {
            // we are able to identify only one renamed parameter using this simple concept
            var added = propertyBag.Keys.Except(currentVariables.Keys).ToList();
            var removed = currentVariables.Keys.Except(propertyBag.Keys).ToList();
            if (added.Count == 1 && removed.Count == 1)
            {
                propertyBag[added.First()] = currentVariables[removed.First()];
            }
        }
    }
}
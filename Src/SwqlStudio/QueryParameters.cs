using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using SolarWinds.InformationService.Contract2;
using WeifenLuo.WinFormsUI.Docking;

namespace SwqlStudio
{
    public partial class QueryParameters : DockContent
    {
        private readonly Dictionary<string, string> lastKnownValues = new Dictionary<string, string>();

        public bool AllowSetParameters { get; set; }

        public QueryParameters()
        {
            InitializeComponent();
            parametersGrid.DataSource = new BindingList<QueryVariable>();
            AllowSetParameters = true;
        }

        public PropertyBag Parameters
        {
            get
            {
                var bag = new PropertyBag();
                foreach (QueryVariable pair in GetBoundQueryVariables())
                    bag[pair.Key] = pair.Value;

                return bag;
            }

            set
            {
                if (!this.AllowSetParameters)
                    return;

                UpdateFromLastKnown(value);
                var currentVariables = GetBoundQueryVariables();
                UpdateWithCurrentValues(value, currentVariables);
                var pairs = value.Select(pair => new QueryVariable(pair.Key, pair.Value?.ToString()));
                QuessRenamedParameter(value);
                var ordered = pairs.OrderBy(p => p.Key).ToList();
                parametersGrid.DataSource = new BindingList<QueryVariable>(ordered) { AllowNew = true };
            }
        }

        private void QuessRenamedParameter(PropertyBag propertyBag)
        {
            // we are able to identify only one renamed parameter using this simple concept
            var currentVariables = Parameters;
            var added = propertyBag.Keys.Except(currentVariables.Keys).ToList();
            var removed = currentVariables.Keys.Except(propertyBag.Keys).ToList();
            if (added.Count == 1 && removed.Count == 1)
            {
                propertyBag[added.First()] = currentVariables[removed.First()];
            }
        }

        private IEnumerable<QueryVariable> GetBoundQueryVariables()
        {
            return ((BindingList<QueryVariable>)parametersGrid.DataSource)
                .Where(v => v.Key != null);
        }

        private void UpdateWithCurrentValues(PropertyBag propertyBag, IEnumerable<QueryVariable> currentVariables)
        {
            foreach (QueryVariable variable in currentVariables)
            {
                if (propertyBag.ContainsKey(variable.Key))
                {
                    propertyBag[variable.Key] = variable.Value;
                }
                else if (!string.IsNullOrEmpty(variable.Value))
                {
                    lastKnownValues[variable.Key] = variable.Value;
                }
            }
        }

        private void UpdateFromLastKnown(PropertyBag propertyBag)
        {
            foreach (string preservedKey in lastKnownValues.Keys.Where(propertyBag.ContainsKey))
            {
                propertyBag[preservedKey] = lastKnownValues[preservedKey];
            }
        }
    }
}

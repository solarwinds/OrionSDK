using System.ComponentModel;
using System.Linq;
using SolarWinds.InformationService.Contract2;
using WeifenLuo.WinFormsUI.Docking;

namespace SwqlStudio
{
    public partial class QueryParameters : DockContent
    {
        public QueryParameters()
        {
            InitializeComponent();
            parametersGrid.DataSource = new BindingList<QueryVariable>(); 
            Parameters = new PropertyBag();
        }

        public PropertyBag Parameters
        {
            get
            {
                var bag = new PropertyBag();
                foreach (QueryVariable pair in (BindingList<QueryVariable>)parametersGrid.DataSource)
                    bag[pair.Key] = pair.Value;

                return bag;
            }

            set
            {
                var currentVariables = (BindingList<QueryVariable>) parametersGrid.DataSource;
                UpdateWithCurrentValues(value, currentVariables);
                var pairs = value.Select(pair => new QueryVariable(pair.Key, pair.Value?.ToString()));
                parametersGrid.DataSource = new BindingList<QueryVariable>(pairs.ToList()) {AllowNew = true};
            }
        }

        private void UpdateWithCurrentValues(PropertyBag propertyBag, BindingList<QueryVariable> currentVariables)
        {
            foreach (QueryVariable variable in currentVariables)
            {
                if (variable.Key != null && propertyBag.ContainsKey(variable.Key))
                    propertyBag[variable.Key] = variable.Value;
            }
        }
    }
}

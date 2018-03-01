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

            private set
            {
                var pairs = value.Select(pair => new QueryVariable(pair.Key, pair.Value?.ToString()));
                parametersGrid.DataSource = new BindingList<QueryVariable>(pairs.ToList()) {AllowNew = true};
            }
        }
    }
}

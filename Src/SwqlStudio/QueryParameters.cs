using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using SolarWinds.InformationService.Contract2;

namespace SwqlStudio
{
    public partial class QueryParameters : Form
    {
        public QueryParameters(PropertyBag queryParameters)
        {
            InitializeComponent();
            Parameters = queryParameters;
        }

        public PropertyBag Parameters
        {
            get
            {
                var bag = new PropertyBag();
                foreach (Pair pair in (BindingList<Pair>)dataGridView1.DataSource)
                    bag[pair.Key] = pair.Value;

                return bag;
            }

            private set
            {
                var pairs = value.Select(pair => new Pair(pair.Key, pair.Value?.ToString()));
                dataGridView1.DataSource = new BindingList<Pair>(pairs.ToList()) {AllowNew = true};
            }
        }
    }

    public class Pair
    {
        public Pair()
        {
        }

        public Pair(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; set; }
        public string Value { get; set; }
    }
}

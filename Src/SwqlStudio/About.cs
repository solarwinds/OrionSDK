using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace SwqlStudio
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();

            var assembly = Assembly.GetEntryAssembly();
            var copyright = (AssemblyCopyrightAttribute)assembly.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), true).First();
            var version = assembly.GetName().Version;

            label1.Text = string.Format(label1.Text, version, copyright.Copyright);
        }
    }
}

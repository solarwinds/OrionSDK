using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using SwqlStudio.Utils;

namespace SwqlStudio
{
    public partial class About : Form
    {
        public About()
        {
            DpiHelper.FixFont(this);
            InitializeComponent();

            var assembly = Assembly.GetEntryAssembly();
            var copyright = (AssemblyCopyrightAttribute)assembly.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), true).First();
            var version = assembly.GetName().Version;

            label1.Text = string.Format(label1.Text, version, copyright.Copyright);
        }
    }
}

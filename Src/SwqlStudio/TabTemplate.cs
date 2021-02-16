using System.Windows.Forms;
using SwqlStudio.Utils;

namespace SwqlStudio
{
    public class TabTemplate : UserControl
    {
        private ConnectionInfo connection;

        public virtual ConnectionInfo ConnectionInfo
        {
            get { return connection; }
            set
            {
                if (AllowsChangeConnection)
                    connection = value;
            }
        }

        public virtual bool AllowsChangeConnection
        {
            get { return true; }
        }

        public TabTemplate()
        {
            DpiHelper.FixFont(this);
        }
    }
}

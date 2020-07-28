using System.Windows.Forms;

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
    }
}
using System.Windows.Forms;

namespace SwqlStudio
{
    public abstract class TabTemplate : UserControl
    {
        private ConnectionInfo connection;

        public virtual ConnectionInfo ConnectionInfo
        {
            get { return connection; }
            set
            {
                if (this.AllowsChangeConnection)
                    connection = value;
            }
        }

        public virtual bool AllowsChangeConnection
        {
            get { return true; }
        }
    }
}
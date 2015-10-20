using System;
using System.Windows.Forms;

namespace SwqlStudio
{
    public partial class NewConnection : Form
    {
        public NewConnection()
        {
            InitializeComponent();

            cmbServer.Items.AddRange(ConnectionHistory.PreviousServers);
            cmbServer.SelectedIndex = 0;

            cmbServerType.DisplayMember = "Type";
            cmbServerType.Items.AddRange(ConnectionInfo.AvailableServerTypes.ToArray());            
            cmbServerType.SelectedIndex = Math.Max(0, ConnectionInfo.AvailableServerTypes.FindIndex(s => s.Type.Equals(ConnectionHistory.PreviousServerType, StringComparison.OrdinalIgnoreCase)));
            cmbUserName.Items.AddRange(ConnectionHistory.PreviousUserNames);
            cmbUserName.SelectedIndex = 0;

            CheckIfUserCredentialsNecessary();
        }

        public ConnectionInfo ConnectionInfo
        {
            get
            {
                var ci = new ConnectionInfo(cmbServer.Text, cmbUserName.Text, tePassword.Text, cmbServerType.Text);
                return ci;
            }
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            ConnectionHistory.AddServer(cmbServer.Text);
            ConnectionHistory.AddUser(cmbUserName.Text);
            ConnectionHistory.PreviousServerType = (cmbServerType.SelectedItem as ServerType).Type;
        }

        private void cmbServerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckIfUserCredentialsNecessary();
        }

        private void CheckIfUserCredentialsNecessary()
        {
            bool requiresAuthentication = (cmbServerType.SelectedItem as ServerType).IsAuthenticationRequired;

            cmbUserName.Enabled = requiresAuthentication;
            tePassword.Enabled = requiresAuthentication;

            if (!requiresAuthentication)
            {
                cmbUserName.Text = string.Empty;
                tePassword.Text = string.Empty;
            }
            else
            {
                if (ConnectionHistory.PreviousUserNames.Length > 0)
                    cmbUserName.Text = ConnectionHistory.PreviousUserNames[0];
            }
        }
    }
}

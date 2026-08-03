using System;
using System.Threading;
using System.Windows.Forms;
using SwqlStudio.Utils;

namespace SwqlStudio
{
    internal partial class NewConnection : Form
    {
        private readonly OrionOAuthInfoService _oauthInfoService = new OrionOAuthInfoService();
        private string _authenticatedOAuthUsername = string.Empty;
        private CancellationTokenSource _oauthCts;

        public NewConnection()
        {
            DpiHelper.FixFont(this);
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

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _oauthCts?.Cancel();
            base.OnFormClosing(e);
        }

        public ConnectionInfo ConnectionInfo
        {
            get
            {
                if (IsOAuthSelected)
                    return new ConnectionInfo(cmbServer.Text, _authenticatedOAuthUsername, _oauthInfoService);

                return new ConnectionInfo(cmbServer.Text, cmbUserName.Text, tePassword.Text, cmbServerType.Text);
            }
        }

        private bool IsOAuthSelected =>
            (cmbServerType.SelectedItem as ServerType)?.Type.Equals("Orion (v3) OAuth", StringComparison.OrdinalIgnoreCase) == true;

        private async void connectButton_Click(object sender, EventArgs e)
        {
            if (!IsOAuthSelected)
            {
                SaveHistory();
                DialogResult = DialogResult.OK;
                return;
            }

            connectButton.Enabled = false;
            _oauthCts = new CancellationTokenSource();

            _oauthInfoService.InitTokenManager(cmbServer.Text);

            try
            {
                await _oauthInfoService.TokenManager.AcquireTokenAsync(_oauthCts.Token);
                _authenticatedOAuthUsername = _oauthInfoService.TokenManager.LastAccountUsername ?? string.Empty;
                SaveHistory();
                Win32.FlashUntilForeground(this);
                Activate();
                DialogResult = DialogResult.OK;
            }
            catch (OperationCanceledException)
            {
                DialogResult = DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                // User was in the browser during OAuth — bring the dialog back to attention.
                Win32.FlashUntilForeground(this);
                Activate();
                MessageBox.Show(this, "Authentication failed: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _oauthCts?.Dispose();
                _oauthCts = null;
                if (!IsDisposed)
                    connectButton.Enabled = true;
            }
        }

        private void SaveHistory()
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
            bool isOAuth = IsOAuthSelected;
            bool requiresCredentials = !isOAuth && (cmbServerType.SelectedItem as ServerType).IsAuthenticationRequired;

            // Show credential fields only for non-OAuth connections.
            bool showCredentials = !isOAuth;
            label3.Visible = showCredentials;
            label4.Visible = showCredentials;
            cmbUserName.Visible = showCredentials;
            tePassword.Visible = showCredentials;
            lblVersionNote.Visible = isOAuth;

            // Enable credential fields only when the selected type requires authentication.
            cmbUserName.Enabled = requiresCredentials;
            tePassword.Enabled = requiresCredentials;

            if (!requiresCredentials)
            {
                cmbUserName.Text = string.Empty;
                tePassword.Text = string.Empty;
            }
            else if (ConnectionHistory.PreviousUserNames.Length > 0)
            {
                cmbUserName.Text = ConnectionHistory.PreviousUserNames[0];
            }
        }
    }
}

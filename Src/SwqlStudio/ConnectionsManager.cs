using System;
using System.Windows.Forms;

namespace SwqlStudio
{
    internal class ConnectionsManager
    {
        private readonly IApplicationService applicationService;
        private readonly ServerList serverList;

        public ConnectionsManager(IApplicationService applicationService, ServerList serverList)
        {
            this.applicationService = applicationService;
            this.serverList = serverList;
        }

        public void CreateConnection()
        {
            ConnectionInfo connection = AskForNewConnection();
            if (connection != null)
                ResolveExistingConnection(connection);
        }

        internal ConnectionInfo ResolveConnection()
        {
            ConnectionInfo info = EnsureExistingConnection();
            if (info != null)
                return ResolveExistingConnection(info);

            return null;
        }

        private ConnectionInfo EnsureExistingConnection()
        {
            var selectedConnection = applicationService.SelectedConnection;
            if (selectedConnection != null)
                return selectedConnection;

            return AskForNewConnection();
        }

        private ConnectionInfo ResolveExistingConnection(ConnectionInfo info)
        {
            ConnectionInfo found;
            bool alreadyExists = serverList.TryGet(info.ServerType, info.Server, info.UserName, out found);
            if (alreadyExists)
                return found;

            info.Connect();
            info.ConnectionClosed += (sender, args) => serverList.Remove(info);
            serverList.Add(info);
            return info;
        }

        internal static ConnectionInfo AskForNewConnection()
        {
            using (var nc = new NewConnection())
            {
                if (nc.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        return nc.ConnectionInfo;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return AskForNewConnection(); // tail recursive retry. user can break out by hitting cancel.
                    }
                }
            }

            return null;
        }
    }
}

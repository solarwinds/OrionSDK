using System.Windows.Forms;

namespace SwqlStudio
{
    internal class ConnectionsManager
    {
        private readonly IApplicationService applicationService;
        private readonly ServerList serverList;
        private readonly QueriesDockPanel dockPanel;

        public ConnectionsManager(IApplicationService applicationService, ServerList serverList, QueriesDockPanel dockPanel)
        {
            this.applicationService = applicationService;
            this.serverList = serverList;
            this.dockPanel = dockPanel;
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
            var selectedConnection = this.applicationService.SelectedConnection;
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
            var provider = serverList.Add(info);

            info.ConnectionClosed += (sender, args) =>
            {
                // TODO remove all tabs holding this connection this.dockPanel.RemoveTab(queryTab.Parent as DockContent);
                serverList.Remove(info);
            };

            this.dockPanel.AddServer(provider, info);
            return info;
        }

        internal static ConnectionInfo AskForNewConnection()
        {
            using (var nc = new NewConnection())
            {
                if (nc.ShowDialog() == DialogResult.OK)
                {
                    return nc.ConnectionInfo;
                }
            }

            return null;
        }
    }
}
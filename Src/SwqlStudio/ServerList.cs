using System;
using System.Collections.Generic;
using System.Linq;

namespace SwqlStudio
{
    internal class ConnectionsEventArgs : EventArgs
    {
        internal ConnectionInfo Connection { get; private set; }

        public ConnectionsEventArgs(ConnectionInfo connection)
        {
            this.Connection = connection;
        }
    }

    internal class ServerList
    {
        internal delegate void ConnectionsEventHandler(object sender, ConnectionsEventArgs e);
        private readonly Dictionary<string, ConnectionInfo> connections = new Dictionary<string, ConnectionInfo>();

        private readonly Dictionary<ConnectionInfo, IMetadataProvider> metadataProviders =
            new Dictionary<ConnectionInfo, IMetadataProvider>();

        internal List<ConnectionInfo> Connections
        {
            get { return this.connections.Values.ToList(); }
        }

        public event EventHandler ConnectionsChanged;

        public event ConnectionsEventHandler ConnectionRemoved;

        public IMetadataProvider Add(ConnectionInfo connection)
        {
            string key = GetKey(connection);
            connections.Add(key, connection);
            var provider = new SwisMetaDataProvider(connection);
            metadataProviders[connection] = provider;
            ConnectionsChanged(this, EventArgs.Empty);
            return provider;
        }

        public void Remove(ConnectionInfo connection)
        {
            string key = GetKey(connection);
            connections.Remove(key);
            metadataProviders.Remove(connection);
            var e = new ConnectionsEventArgs(connection);
            ConnectionRemoved(this, e);
        }

        public bool Exists(ConnectionInfo connection)
        {
            string key = GetKey(connection);
            return connections.ContainsKey(key);
        }

        public bool TryGet(string serverType, string server, string username, out ConnectionInfo connection)
        {
            string key = GetKey(serverType, server, username);
            return connections.TryGetValue(key, out connection);
        }

        private string GetKey(ConnectionInfo connection)
        {
            return GetKey(connection.ServerType, connection.Server, connection.UserName);
        }

        private string GetKey(string serverType, string server, string username)
        {
            return String.Format("{0},{1},{2}", serverType, server, username);
        }

        public bool TryGetProvider(ConnectionInfo connection, out IMetadataProvider provider)
        {
            return metadataProviders.TryGetValue(connection, out provider);
        }
    }
}

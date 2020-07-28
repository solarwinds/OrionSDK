using System;

namespace SwqlStudio
{
    internal class ConnectionsEventArgs : EventArgs
    {
        internal ConnectionInfo Connection { get; private set; }

        public ConnectionsEventArgs(ConnectionInfo connection)
        {
            Connection = connection;
        }
    }
}
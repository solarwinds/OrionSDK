using System;
using System.Drawing;
using System.Windows.Forms;

namespace SwqlStudio
{
    internal class QueryStatusBar : StatusStrip
    {
        private const string NotAvailable = "N/A";

        internal const string Connected = "Connected";
        internal const string Disconnected = "Disconnected";
        internal const string Disconnecting = "Disconnecting...";

        private readonly ToolStripStatusLabel _connectionLabel;
        private readonly ToolStripStatusLabel _serverLabel;
        private readonly ToolStripStatusLabel _userLabel;
        private readonly ToolStripStatusLabel _queryTimeLabel;
        private readonly ToolStripStatusLabel _rowCountLabel;

        private ConnectionInfo _connection;
        private Font _boldFont;

        public QueryStatusBar()
        {
            SizingGrip = false;
            Stretch = true;
            DockPadding.All = 0;

            _connectionLabel = new ToolStripStatusLabel();
            _connectionLabel.Spring = true;

            _serverLabel = new ToolStripStatusLabel();
            _userLabel = new ToolStripStatusLabel();
            _queryTimeLabel = new ToolStripStatusLabel();
            _rowCountLabel = new ToolStripStatusLabel();

            foreach (var label in AllLabels)
            {
                label.BorderSides = ToolStripStatusLabelBorderSides.All;
                label.Alignment = ToolStripItemAlignment.Right;
                label.BorderStyle = Border3DStyle.SunkenOuter;
                label.Padding = new Padding(-1, 5, -1, 5);
                label.TextAlign = ContentAlignment.MiddleLeft;
            }

        }

        private ToolStripStatusLabel[] AllLabels
        {
            get
            {
                return new[] { _connectionLabel, _serverLabel, _userLabel, _userLabel, _queryTimeLabel, _rowCountLabel };
            }
        }

        public void Initialize(ConnectionInfo connection)
        {
            Items.AddRange(AllLabels);

            _connection = connection;
            ShowConnectionState();

            if (connection != null)
            {
                _serverLabel.Text = string.Format("Server: {0}", connection.Server);
                _userLabel.Text = string.Format("User: {0}", connection.UserName);
            }
            else
            {
                _serverLabel.Text = NotAvailable;
                _userLabel.Text = NotAvailable;
            }

            UpdateValues(0, TimeSpan.Zero);
        }

        /// <summary>Shows the connection state, which is the status bar's idle text.</summary>
        public void ShowConnectionState()
        {
            if (_connection == null)
                _connectionLabel.Text = NotAvailable;
            else
                _connectionLabel.Text = _connection.IsConnected ? Connected : Disconnected;

            ApplyConnectionLabelStyle();
        }

        // Same gold as the execute button while disconnected; bold keeps it distinguishable without colour.
        private void ApplyConnectionLabelStyle()
        {
            bool warn = _connectionLabel.Text == Disconnected;
            IsDisconnectedHighlighted = warn;

            if (warn)
            {
                _boldFont = _boldFont ?? new Font(Font, FontStyle.Bold);
                _connectionLabel.Font = _boldFont;

                if (!SystemInformation.HighContrast)
                {
                    _connectionLabel.BackColor = Color.Gold;
                    _connectionLabel.ForeColor = Color.Black;
                }
            }
            else
            {
                _connectionLabel.ResetFont();
                _connectionLabel.ResetBackColor();
                _connectionLabel.ResetForeColor();
            }
        }

        internal bool IsDisconnectedHighlighted { get; private set; }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Detach before disposing so the label never renders with a disposed font.
                _connectionLabel.ResetFont();
                _boldFont?.Dispose();
                _boldFont = null;
            }

            base.Dispose(disposing);
        }

        public void UpdateValues(int rowCount, TimeSpan queryTime, long? totalRows = null)
        {
            if (totalRows.HasValue)
                _rowCountLabel.Text = string.Format("{0} of {1} rows", rowCount, totalRows);
            else
                _rowCountLabel.Text = string.Format("{0} rows", rowCount);
            _queryTimeLabel.Text = string.Format("{0}", queryTime.ToString());
        }

        public void UpdateStatusLabel(string text)
        {
            _connectionLabel.Text = text;
            ApplyConnectionLabelStyle();
        }

        internal string ConnectionStatus => _connectionLabel.Text;
    }
}

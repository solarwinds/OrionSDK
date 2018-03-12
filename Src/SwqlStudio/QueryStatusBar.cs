using System;
using System.Drawing;
using System.Windows.Forms;

namespace SwqlStudio
{
    internal class QueryStatusBar : StatusStrip
    {
        private const string NotAvailable = "N/A";

        private readonly ToolStripStatusLabel _connectionLabel;
        private readonly ToolStripStatusLabel _serverLabel;
        private readonly ToolStripStatusLabel _userLabel;
        private readonly ToolStripStatusLabel _queryTimeLabel;
        private readonly ToolStripStatusLabel _rowCountLabel;

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
                return new[] {_connectionLabel, _serverLabel, _userLabel, _userLabel, _queryTimeLabel, _rowCountLabel};
            }
        }

        public void Initialize(ConnectionInfo connection)
        {
            Items.AddRange(AllLabels);

            if (connection != null)
            {
                _connectionLabel.Text = "Connected";
                _serverLabel.Text = String.Format("Server: {0}", connection.Server);
                _userLabel.Text = String.Format("User: {0}", connection.UserName);
            }
            else
            {
                _connectionLabel.Text = NotAvailable;
                _serverLabel.Text = NotAvailable;
                _userLabel.Text = NotAvailable;
            }

            UpdateValues(0, TimeSpan.Zero);
        }

        public void UpdateValues(int rowCount, TimeSpan queryTime, long? totalRows = null)
        {
            if (totalRows.HasValue)
                _rowCountLabel.Text = String.Format("{0} of {1} rows", rowCount, totalRows);
            else
                _rowCountLabel.Text = String.Format("{0} rows", rowCount);
            _queryTimeLabel.Text = String.Format("{0}", queryTime.ToString());
        }

        public void UpdateStatusLabel(string text)
        {
            _connectionLabel.Text = text;
        }
    }
}

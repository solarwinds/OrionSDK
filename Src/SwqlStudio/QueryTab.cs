using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using SolarWinds.InformationService.Contract2;
using SwqlStudio.Metadata;
using SwqlStudio.Playback;
using SwqlStudio.Properties;
using SwqlStudio.Subscriptions;

namespace SwqlStudio
{
    public sealed partial class QueryTab : TabTemplate, IConnectionTab
    {
        private readonly CachedParameters preserved = new CachedParameters();

        private string subscriptionId;

        private bool HasSubscription
        {
            get { return !String.IsNullOrEmpty(subscriptionId); }
        }

        public override bool AllowsChangeConnection => !HasSubscription;

        public override ConnectionInfo ConnectionInfo
        {
            set
            {
                base.ConnectionInfo = value;
                SetMetadataProvider();
                queryStatusBar1.Initialize(base.ConnectionInfo);
            }
        }

        [Flags]
        enum Tabs
        {
            Results = 1,
            QueryPlan = 2,
            RawXml = 4,
            Log = 8,
            Subscription = 16,
            ErrorMessages = 32,
            QueryStats = 64
        }

        private Font nullFont;
        private IApplicationService ApplicationService { get; }
        private SubscriptionManager SubscriptionManager { get; }
        private ServerList ServerList { get; }

        public QueryTab()
        {
            InitializeComponent();
            nullFont = new Font(dataGridView1.DefaultCellStyle.Font, dataGridView1.DefaultCellStyle.Font.Style | FontStyle.Italic);
            ShowTabs(Tabs.Results);
            Disposed += QueryTabDisposed;
            AddRunContextMenu();
        }

        internal QueryTab(IApplicationService applicationService, ServerList serverList, ConnectionInfo connectionInfo, SubscriptionManager subscriptionManager) : this()
        {
            ApplicationService = applicationService;
            ServerList = serverList;
            ConnectionInfo = connectionInfo;
            SubscriptionManager = subscriptionManager;
        }

        private void AddRunContextMenu()
        {
            ToolStripMenuItem runMenuItem = new ToolStripMenuItem();
            runMenuItem.Text = "Execute";
            runMenuItem.Image = Resources.Run_16x;
            runMenuItem.ShortcutKeys = Keys.F5;
            runMenuItem.Click += new EventHandler(RunQueryClick);
            Editor.ContextMenuStrip.Items.Insert(0, runMenuItem);
        }

        private void RunQueryClick(object sender, EventArgs e)
        {
            RunQuery();
        }

        void QueryTabDisposed(object sender, EventArgs e)
        {
            if (nullFont != null)
            {
                nullFont.Dispose();
                nullFont = null;
            }
            Unsubscribe();
        }

        private void Unsubscribe()
        {
            if (HasSubscription)
            {
                SubscriptionManager.Unsubscribe(ConnectionInfo, subscriptionId, SubscriptionIndicationReceived);
                subscriptionId = string.Empty;
            }
        }

        private void ShowTabs(Tabs tabsToShow)
        {
            tabControl1.TabPages.Clear();
            if ((tabsToShow & Tabs.Results) != 0)
                tabControl1.TabPages.Add(resultTab);
            if ((tabsToShow & Tabs.QueryPlan) != 0)
                tabControl1.TabPages.Add(queryPlanTab);
            if ((tabsToShow & Tabs.RawXml) != 0)
                tabControl1.TabPages.Add(rawXmlTab);
            if ((tabsToShow & Tabs.Log) != 0)
                tabControl1.TabPages.Add(logTab);
            if ((tabsToShow & Tabs.Subscription) != 0)
                tabControl1.TabPages.Add(notificationTab);
            if ((tabsToShow & Tabs.ErrorMessages) != 0)
                tabControl1.TabPages.Add(errorMessagesTab);
            if ((tabsToShow & Tabs.QueryStats) != 0)
                tabControl1.TabPages.Add(queryStatsTab);
        }

        public string QueryText
        {
            get { return sciTextEditorControl1.Text; }
            set { sciTextEditorControl1.Text = value; }
        }

        internal void MarkSaved()
        {
            sciTextEditorControl1.SetSavePoint();
        }


        internal SciTextEditorControl Editor { get { return sciTextEditorControl1; } }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null || DBNull.Value.Equals(e.Value))
            {
                e.Value = "NULL";
                e.CellStyle.ForeColor = SystemColors.GrayText;
                e.CellStyle.Font = nullFont;
            }
            else
            {
                StringBuilder str = FormatGridValue(e.Value);
                e.Value = str.ToString();
            }
        }

        private static StringBuilder FormatGridValue(object value)
        {
            var str = new StringBuilder();
            if (value == null)
                return str;

            var valueType = value.GetType();

            if (valueType.IsArray)
            {
                var enumerable = (IEnumerable)value;
                var enumerator = enumerable.GetEnumerator();

                str.Append("[");
                bool first = true;

                while (enumerator.MoveNext())
                {
                    if (!first)
                        str.Append(", ");
                    if (enumerator.Current != null)
                        str.Append(enumerator.Current);

                    first = false;
                }
                str.Append("]");
            }
            else if (valueType == typeof(DateTime))
            {
                str.AppendFormat("{0:yyyy'-'MM'-'dd HH':'mm':'ss'.'FFFFFFF}", value);
            }
            else
            {
                str.Append(value);
            }

            return str;
        }

        internal void CopySelectionToClipboard()
        {
            if (sciTextEditorControl1.Focused)
            {
                sciTextEditorControl1.Copy();
            }
            else if (dataGridView1.Focused)
            {
                CopyActiveGridCellToClipboard(dataGridView1);
            }
            else
            {
                // if none of previous cases worked, try to find active control and copy contents of it
                var activeControl = FindFocusedControl(this);
                HandleCopyEventForActiveControl(activeControl);
            }
        }

        private void HandleCopyEventForActiveControl(Control activeControl)
        {
            if (activeControl is TextBox)
            {
                ((TextBox)activeControl).Copy();
            }
        }

        private Control FindFocusedControl(Control control)
        {
            var container = control as IContainerControl;
            while (container != null)
            {
                control = container.ActiveControl;
                container = control as IContainerControl;
            }
            return control;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var visibleDataGridView =
                    tabControl1.SelectedTab == queryStatsTab ? dataGridView2 : dataGridView1;

            CopyActiveGridCellToClipboard(visibleDataGridView);
        }

        private void CopyActiveGridCellToClipboard(DataGridView visibleDataGridView)
        {
            if (visibleDataGridView.GetCellCount(DataGridViewElementStates.Selected) > 0)
            {
                Clipboard.SetDataObject(visibleDataGridView.GetClipboardContent());
            }
        }

        private void saveResultsAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dlg = new SaveFileDialog { Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*", DefaultExt = "csv" };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var visibleDataGridView =
                    tabControl1.SelectedTab == queryStatsTab ? dataGridView2 : dataGridView1;


                new DataGridExporter().ExportAsCsv(visibleDataGridView, dlg.FileName);
            }
        }

        public void RunPlayback()
        {
            try
            {
                ShowTabs(Tabs.Log);
                var openFileDialog1 = new OpenFileDialog
                {
                    InitialDirectory = "c:\\",
                    Filter = "log files (*.log)|*.log|All files (*.*)|*.*",
                    DefaultExt = "log",
                    FilterIndex = 2,
                    RestoreDirectory = true
                };


                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    var pbi = new PlaybackItem() { FileName = openFileDialog1.FileName, MultiThread = false, QueryTab = this };
                    ConnectionInfo info = ConnectionsManager.AskForNewConnection();
                    if (info == null)
                        return;

                    info.Connect();
                    pbi.ConnectionInfo = info;
                    PlaybackManager.StartPlayback(pbi);
                    logTextbox.Text = "Started Playback...\r\n";
                }
            }
            catch (Exception ex)
            {
                AppendLogTabLine("Error starting playback.\r\n");
                AppendLogTabLine(ex.ToString());
            }
        }

        private delegate void AppendLogDelegate(string s);
        public void AppendLogTabLine(string line)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new AppendLogDelegate(AppendLogTabLine), line);
            }
            else
            {
                logTextbox.AppendText(line + "\r\n");
            }
        }

        public void RunQuery()
        {
            var editor = sciTextEditorControl1;
            if (editor == null)
                return;

            string query = editor.GetSelectedOrAllText();
            if (String.IsNullOrEmpty(query) || query.Trim().Length == 0)
                return;

            ConnectionInfo connection = ConnectionInfo;
            if (connection == null)
                return; // should we try to connect?

            connection.QueryParameters = ApplicationService.QueryParameters;

            if (queryWorker.IsBusy)
                return;

            Unsubscribe();

            if (query.Trim().StartsWith("SUBSCRIBE", StringComparison.OrdinalIgnoreCase))
            {
                ShowTabs(Tabs.Subscription);
                subscriptionWorker.RunWorkerAsync(new QueryArguments(connection, query));
            }
            else
            {
                ShowTabs(Tabs.Results);
                queryStatusBar1.UpdateStatusLabel("Running query...");
                queryWorker.RunWorkerAsync(new QueryArguments(connection, query));
            }

            ApplicationService.RefreshSelectedConnections();
        }

        void SubscriptionIndicationReceived(IndicationEventArgs e)
        {
            if (!subscriptionTab1.IsDisposed)
                subscriptionTab1.BeginInvoke(new Action<IndicationEventArgs>(subscriptionTab1.AddIndication), e);
        }

        private static readonly string[] returnClauses = { "RETURN XML AUTO", "RETURN XML AUTO STRICT", "RETURN XML RAW" };

        private void queryWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            QueryArguments arguments = (QueryArguments)e.Argument;

            try
            {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();

                XmlDocument queryPlan;
                XmlDocument queryStats;
                if (returnClauses.Any(s => arguments.Query.Trim().EndsWith(s, StringComparison.OrdinalIgnoreCase)))
                {
                    List<ErrorMessage> errorMessages;
                    arguments.RawXmlResults = arguments.Connection.QueryXml(arguments.Query, out queryPlan, out errorMessages, out queryStats);
                    arguments.Errors = errorMessages;
                }
                else
                {
                    arguments.Results = arguments.Connection.Query(arguments.Query, out queryPlan, out queryStats);

                    if (arguments.Results.ExtendedProperties.Contains("Errors") && arguments.Results.ExtendedProperties["Errors"] != null)
                        arguments.Errors = (List<ErrorMessage>)arguments.Results.ExtendedProperties["Errors"];
                }
                arguments.QueryPlan = queryPlan;
                arguments.QueryStats = queryStats;
                arguments.Log = LogHeaderMessageInspector.LastReplyLog;

                stopWatch.Stop();
                arguments.QueryTime = stopWatch.Elapsed;

                e.Result = arguments;
            }
            catch (Exception ex)
            {
                e.Result = new QueryErrorResult { ErrorMessage = ex.Message, Log = LogHeaderMessageInspector.LastReplyLog };
            }
        }

        private void queryWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            QueryArguments arg = e.Result as QueryArguments;
            if (arg != null)
            {
                if (arg.RawXmlResults == null)
                {
                    DataGridView grid = dataGridView1;
                    if (grid != null)
                    {
                        DataTable table = arg.Results;

                        grid.AutoGenerateColumns = false;
                        grid.Columns.Clear();
                        foreach (DataColumn column in table.Columns)
                        {
                            var columnIndex = grid.Columns.Add(column.ColumnName, column.ColumnName);
                            grid.Columns[columnIndex].DataPropertyName = column.ColumnName;
                        }

                        grid.DataSource = arg.Results;
                        AutoResizeColumns(grid);
                    }

                    queryStatusBar1.UpdateValues(arg.Results.Rows.Count, arg.QueryTime, (long?)arg.Results.ExtendedProperties["TotalRows"]);
                    queryStatusBar1.UpdateStatusLabel("Ready");

                    RawXmlTabVisible = false;
                    ResultsTabVisible = true;
                }
                else
                {
                    rawXmlBrowser.XmlDocument = arg.RawXmlResults;
                    RawXmlTabVisible = true;
                    ResultsTabVisible = false;

                    queryStatusBar1.UpdateValues(0, arg.QueryTime);
                    queryStatusBar1.UpdateStatusLabel("Ready");
                }

                if (arg.Errors != null)
                {
                    XmlDocument document = new XmlDocument();

                    var errorXElement = new XElement("errors",
                        from error in arg.Errors
                        select new XElement("error",
                            new XElement("errorType", error.ErrorType),
                            new XElement("context", error.Context),
                            new XElement("message", error.Message)
                            ));

                    using (var xmlReader = errorXElement.CreateReader())
                    {
                        document.Load(xmlReader);
                    }
                    errorMessagesBrowser.XmlDocument = document;
                    ErrorMessageTabVisible = true;
                }
                else
                {
                    ErrorMessageTabVisible = false;
                }

                ShowQueryPlan(arg.QueryPlan);
                ShowQueryStats(arg.QueryStats);
                ShowLog(arg.Log);
            }
            else if (e.Result is QueryErrorResult)
            {
                var error = (QueryErrorResult)e.Result;
                queryStatusBar1.UpdateValues(0, TimeSpan.Zero);
                queryStatusBar1.UpdateStatusLabel("Error");
                RawXmlTabVisible = false;
                ResultsTabVisible = false;
                QueryPlanTabVisible = false;
                QueryStatsTabVisible = false;
                ShowLog(error.Log);
                MessageBox.Show(this, error.ErrorMessage, "SWQL Studio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private static void AutoResizeColumns(DataGridView grid)
        {
            const int maxSize = 200;
            const int widthFudgeFactor = 25;

            int[] preferredSizes = new int[grid.ColumnCount];
            int excessPreferredSize = 0;
            int totalCurrentColumnSize = 0;
            grid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            for (int i = 0; i < grid.ColumnCount; i++)
            {
                DataGridViewColumn column = grid.Columns[i];
                preferredSizes[i] = column.Width;
                if (column.Width > maxSize)
                {
                    excessPreferredSize += column.Width - maxSize;
                    column.Width = maxSize;
                }
                totalCurrentColumnSize += column.Width;
            }

            if (excessPreferredSize > 0)
            {
                // Some columns would like to be larger. Can we do this without incurring horizontal scroll?
                // Easiest to just always leave room for a vertical scroll bar
                int availableWidth = grid.DisplayRectangle.Width - totalCurrentColumnSize
                                     - SystemInformation.VerticalScrollBarWidth - widthFudgeFactor;
                if (availableWidth > 0)
                {
                    double grantRatio = Math.Min(1.0, (double)availableWidth / excessPreferredSize);
                    for (int i = 0; i < grid.ColumnCount; i++)
                    {
                        DataGridViewColumn column = grid.Columns[i];
                        if (column.Width != preferredSizes[i])
                        {
                            column.Width += (int)((preferredSizes[i] - column.Width) * grantRatio);
                        }
                    }
                }
            }
        }

        private void ShowLog(string lastReplyLog)
        {
            logTextbox.Text = lastReplyLog ?? string.Empty;
            LogTabVisible = !string.IsNullOrEmpty(lastReplyLog);
        }

        private void ShowQueryStats(XmlDocument queryStats)
        {
            if (queryStats != null)
            {
                QueryStatsTabVisible = true;
                dataGridView2.DataSource = ParseQueryStats(queryStats);

            }
            else
            {
                QueryStatsTabVisible = false;
                dataGridView2.DataSource = null;
            }
        }

        private DataTable ParseQueryStats(XmlDocument queryStats)
        {
            var rv = new DataTable();
            rv.Columns.Add("#");
            rv.Columns.Add("Type");
            rv.Columns.Add("Query");
            rv.Columns.Add("Duration", typeof(long));
            rv.Columns.Add("Rows", typeof(long));

            if (queryStats.DocumentElement == null) return rv;
            int i = 0;

            foreach (XmlElement childNode in
                queryStats.DocumentElement.ChildNodes
                .OfType<XmlElement>()
                .Where(x => x.Name == "query"))
            {
                var row = rv.NewRow();
                row[0] = ++i;
                row[1] = GetAttr(childNode.Attributes, "type");
                row[2] = childNode.ChildNodes.OfType<XmlElement>().Single().InnerText;
                row[3] = ConvertToInt64OrDbNull(GetAttr(childNode.Attributes, "elapsedMs"));
                row[4] = ConvertToInt64OrDbNull(GetAttr(childNode.Attributes, "rows"));

                rv.Rows.Add(row);
            }

            return rv;
        }

        private static object ConvertToInt64OrDbNull(object value)
        {
            if (value != null)
            {
                long parsed;
                if (long.TryParse(value.ToString(), out parsed))
                {
                    return parsed;
                }
            }
            return DBNull.Value;
        }

        private object GetAttr(XmlAttributeCollection attributes, string attrName)
        {
            return (from XmlAttribute obj in attributes where obj.Name == attrName select obj.Value).FirstOrDefault();
        }

        private void ShowQueryPlan(XmlDocument queryPlan)
        {
            if (queryPlan != null)
            {
                QueryPlanTabVisible = true;
                xmlBrowser1.XmlDocument = queryPlan;
            }
            else
            {
                QueryPlanTabVisible = false;
                xmlBrowser1.XmlDocument = null;
            }
        }

        private bool ResultsTabVisible
        {
            get { return tabControl1.TabPages.Contains(resultTab); }

            set
            {
                if (ResultsTabVisible && !value)
                    tabControl1.TabPages.Remove(resultTab);
                else if (!ResultsTabVisible && value)
                    tabControl1.TabPages.Add(resultTab);
            }
        }

        private bool ErrorMessageTabVisible
        {
            get { return tabControl1.TabPages.Contains(errorMessagesTab); }

            set
            {
                if (ErrorMessageTabVisible && !value)
                    tabControl1.TabPages.Remove(errorMessagesTab);
                else if (!ErrorMessageTabVisible && value)
                    tabControl1.TabPages.Add(errorMessagesTab);
            }
        }

        private bool QueryPlanTabVisible
        {
            get { return tabControl1.TabPages.Contains(queryPlanTab); }

            set
            {
                if (QueryPlanTabVisible && !value)
                    tabControl1.TabPages.Remove(queryPlanTab);
                else if (!QueryPlanTabVisible && value)
                    tabControl1.TabPages.Add(queryPlanTab);
            }
        }

        private bool QueryStatsTabVisible
        {
            get { return tabControl1.TabPages.Contains(queryStatsTab); }

            set
            {
                if (QueryStatsTabVisible && !value)
                    tabControl1.TabPages.Remove(queryStatsTab);
                else if (!QueryStatsTabVisible && value)
                    tabControl1.TabPages.Add(queryStatsTab);
            }
        }

        private bool RawXmlTabVisible
        {
            get { return tabControl1.TabPages.Contains(rawXmlTab); }

            set
            {
                if (RawXmlTabVisible && !value)
                    tabControl1.TabPages.Remove(rawXmlTab);
                else if (!RawXmlTabVisible && value)
                    tabControl1.TabPages.Add(rawXmlTab);
            }
        }

        private bool LogTabVisible
        {
            get { return tabControl1.TabPages.Contains(logTab); }

            set
            {
                if (LogTabVisible && !value)
                    tabControl1.TabPages.Remove(logTab);
                else if (!LogTabVisible && value)
                    tabControl1.TabPages.Add(logTab);
            }
        }

        internal string FileName
        {
            get { return sciTextEditorControl1.FileName; }
            set
            {
                sciTextEditorControl1.FileName = value;
                if (Parent != null)
                    Parent.Text = Path.GetFileName(value);
            }
        }

        public bool Modified
        {
            get { return sciTextEditorControl1.Modified; }
        }

        private class QueryArguments
        {
            public ConnectionInfo Connection { get; set; }
            public string Query { get; set; }
            public DataTable Results { get; set; }
            public XmlDocument QueryPlan { get; set; }
            public XmlDocument QueryStats { get; set; }
            public TimeSpan QueryTime { get; set; }
            public XmlDocument RawXmlResults { get; set; }
            public string Log { get; set; }
            public List<ErrorMessage> Errors { get; set; }

            public QueryArguments(ConnectionInfo connection, string query)
            {
                Connection = connection;
                Query = query;
            }
        }

        private class QueryErrorResult
        {
            public string ErrorMessage { get; set; }
            public string Log { get; set; }
        }

        private void subscriptionWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var arg = (QueryArguments)e.Argument;

            subscriptionWorker.ReportProgress(0, "Waiting for subscriber host to be opened...");


            subscriptionWorker.ReportProgress(0, "Starting subscription...");

            try
            {
                subscriptionId = SubscriptionManager
                    .CreateSubscription(ConnectionInfo, arg.Query, SubscriptionIndicationReceived);
                Invoke(new Action(() => ApplicationService.RefreshSelectedConnections()));
                subscriptionWorker.ReportProgress(0, "Waiting for notifications");
            }
            catch (Exception ex)
            {
                e.Result = new QueryErrorResult { ErrorMessage = ex.Message, Log = ex.ToString() };
            }
        }

        private void subscriptionWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            queryStatusBar1.UpdateStatusLabel(e.UserState.ToString());
        }

        private void subscriptionWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            var error = e.Result as QueryErrorResult;
            if (error != null)
            {
                queryStatusBar1.UpdateValues(0, TimeSpan.Zero);
                queryStatusBar1.UpdateStatusLabel("Error");

                ShowTabs(Tabs.Log);
                logTextbox.Text = error.Log;
                MessageBox.Show(this, error.ErrorMessage, "SWQL Studio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ConnectionInfo == null)
                return;

            var errors = new StringBuilder();
            var deletedRows = new List<DataGridViewRow>();
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                try
                {
                    var uri = (string)row.Cells["Uri"].Value;
                    ConnectionInfo.DoWithExceptionTranslation(() => ConnectionInfo.Proxy.Delete(uri));
                    deletedRows.Add(row);
                }
                catch (Exception ex)
                {
                    errors.AppendLine(ex.Message);
                }
            }

            deletedRows.ForEach(dataGridView1.Rows.Remove);

            if (errors.Length > 0)
                MessageBox.Show(this, errors.ToString(), "SWQL Studio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void gridContextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            deleteToolStripMenuItem.Enabled = dataGridView1.Columns.Contains("Uri") && dataGridView1.SelectedRows.Count > 0;
        }

        private void SetMetadataProvider()
        {
            IMetadataProvider provider;
            if (ServerList != null && ConnectionInfo != null && ServerList.TryGetProvider(ConnectionInfo, out provider))
            {
                sciTextEditorControl1.SetMetadata(provider);
            }
        }

        private void sciTextEditorControl1_TextChanged(object sender, EventArgs e)
        {
            delayTimer.Start();
        }

        private void delayTimer_Tick(object sender, EventArgs e)
        {
            delayTimer.Stop();

            if (Parent != null && Modified &&
                !string.IsNullOrEmpty(FileName) && !Parent.Text.EndsWith("*"))
                Parent.Text = Parent.Text + "*";

            PutParameters();
            ParseParameters();
        }

        internal void ParseParameters()
        {
            PropertyBag parsed = preserved.Get(QueryText);
            ApplicationService.QueryParameters = parsed;
        }

        internal void PutParameters()
        {
            PropertyBag current = ApplicationService.QueryParameters;
            preserved.Put(current);
        }

        internal void Paste()
        {
            sciTextEditorControl1.Paste();
        }

        internal void Cut()
        {
            sciTextEditorControl1.Cut();
        }

        internal void Undo()
        {
            sciTextEditorControl1.Undo();
        }

        internal void Redo()
        {
            sciTextEditorControl1.Redo();
        }

        private void logTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            // a bit ugly, but considering the fact that CTRL+A doesn't work
            // if TextBox is multiline...
            // https://msdn.microsoft.com/en-us/library/system.windows.forms.textboxbase.shortcutsenabled(v=vs.100).aspx
            if (e.Control && e.KeyCode == Keys.A)
            {
                if (sender != null)
                    ((TextBox)sender).SelectAll();
            }
        }

        internal void FindDialog()
        {
            findReplaceDialog.ShowFind();
        }

        internal void ReplaceDialog()
        {
            findReplaceDialog.ShowReplace();
        }

        public void HideFindReplaceDialog()
        {
            findReplaceDialog.Window.Hide();
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using ScintillaNET;
using SolarWinds.InformationService.Contract2;
using SwqlStudio.Playback;
using SwqlStudio.Properties;

namespace SwqlStudio
{
    public partial class QueryTab : UserControl, IConnectionTab
    {
        [Flags]
        enum Tabs
        {
            Results = 1,
            QueryPlan = 2,
            RawXml = 4,
            Log = 8,
            Subscription = 16,
            ErrorMessages = 32
        }

        public QueryTab()
        {
            InitializeComponent();
            ShowTabs(Tabs.Results);
            Disposed += QueryTabDisposed;
        }

        void QueryTabDisposed(object sender, EventArgs e)
        {
            if (subscription != null)
            {
                subscription.Dispose();
                subscription = null;
            }
        }

        private IApplicationService applicationService;
        public IApplicationService ApplicationService
        {
            get { return applicationService; }
            
            set 
            { 
                applicationService = value;
                applicationService.IndicationReceived += SubscriptionIndicationReceived;
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
        }

        public string QueryText
        {
            get { return sciTextEditorControl1.Text; }
            set { sciTextEditorControl1.Text = value; }
        }

        public bool IsDirty
        {
            get { return sciTextEditorControl1.Modified; }
            set
            {
                if (value == false)
                    sciTextEditorControl1.SetSavePoint();
                else
                    throw new ArgumentException("Can't set IsDirty to true, only false");
            }
        }

        private ConnectionInfo connectionInfo;
        
        public ConnectionInfo ConnectionInfo
        {
            get { return connectionInfo; }
            set
            {
                connectionInfo = value;
                queryStatusBar1.Initialize(connectionInfo.Server, connectionInfo.UserName);
            }
        }

        private Subscription subscription;

        internal SciTextEditorControl Editor { get { return sciTextEditorControl1; } }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
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

            if (value.GetType().IsArray)
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
                        str.Append(enumerator.Current.ToString());

                    first = false;
                }
                str.Append("]");
            }
            else
            {
                str.Append(value.ToString());
            }

            return str;
        }

        public void CopySelectionToClipboard()
        {
            if (sciTextEditorControl1.Focused)
            {
                sciTextEditorControl1.Copy();
            }
            else if (dataGridView1.Focused)
            {
                CopyActiveGridCellToClipboard();
            }
        }

        private void toolStripMenuItem2_Click(object sender, System.EventArgs e)
        {
            CopyActiveGridCellToClipboard();
        }

        private void CopyActiveGridCellToClipboard()
        {
            if (dataGridView1.CurrentCell != null && dataGridView1.CurrentCell.Value != null)
            {
                Clipboard.SetDataObject(FormatGridValue(dataGridView1.CurrentCell.Value).ToString(), true);
            }
        }

        private void saveResultsAsToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var dlg = new SaveFileDialog {Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*", DefaultExt = "csv"};

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                new DataGridExporter().ExportAsCsv(dataGridView1, dlg.FileName);
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
                    var pbi = new PlaybackItem() { FileName = openFileDialog1.FileName, MultiThread = false, QueryTab = this};
                    using (var nc = new NewConnection())
                    {
                        if (nc.ShowDialog(this) != DialogResult.OK)
                            return;

                        var info = nc.ConnectionInfo;
                        info.Connect();
                        pbi.ConnectionInfo = info;
                        PlaybackManager.StartPlayback(pbi);
                    }
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

            if (queryWorker.IsBusy)
                return;

            if (subscription != null)
            {
                subscription.Dispose();
                subscription = null;
            }

            if (query.Trim().StartsWith("SUBSCRIBE", StringComparison.OrdinalIgnoreCase))
            {
                ShowTabs(Tabs.Subscription);
                subscriptionWorker.RunWorkerAsync(new QueryArguments(connection, query));
            }
            else
            {
                queryStatusBar1.UpdateStatusLabel("Running query...");
                queryWorker.RunWorkerAsync(new QueryArguments(connection, query));
            }
        }

        void SubscriptionIndicationReceived(object sender, IndicationEventArgs e)
        {
            // hack. it would be better to get the actual subscription id and compare properly
            if (subscription != null && subscription.SubscriptionUri.Contains(e.SubscriptionID)) 
                subscriptionTab1.BeginInvoke(new Action<IndicationEventArgs>(subscriptionTab1.AddIndication), e);
        }

        private static readonly string[] returnClauses = new[] {"RETURN XML AUTO", "RETURN XML AUTO STRICT", "RETURN XML RAW"};

        private void queryWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            QueryArguments arguments = (QueryArguments)e.Argument;

            try
            {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();

                XmlDocument queryPlan;
                List<ErrorMessage> errorMessages;
                if (returnClauses.Any(s => arguments.Query.Trim().EndsWith(s, StringComparison.OrdinalIgnoreCase)))
                {
                    arguments.RawXmlResults = arguments.Connection.QueryXml(arguments.Query, out queryPlan, out errorMessages);
                    arguments.Errors = errorMessages;
                }
                else
                {
                    arguments.Results = arguments.Connection.Query(arguments.Query, out queryPlan);

                    if (arguments.Results.ExtendedProperties.Contains("Errors") && arguments.Results.ExtendedProperties["Errors"] != null)
                        arguments.Errors = (List<ErrorMessage>) arguments.Results.ExtendedProperties["Errors"];
                }
                arguments.QueryPlan = queryPlan;
                arguments.Log = LogHeaderMessageInspector.LastReplyLog;

                stopWatch.Stop();
                arguments.QueryTime = stopWatch.Elapsed;

                e.Result = arguments;
            }
            catch (Exception ex)
            {
                e.Result = new QueryErrorResult {ErrorMessage = ex.Message, Log = LogHeaderMessageInspector.LastReplyLog};
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
                            grid.Columns.Add(column.ColumnName, column.ColumnName);
                            grid.Columns[column.ColumnName].DataPropertyName = column.ColumnName;

                        }

                        if (table.Columns.Contains("Uri"))
                        {
                            grid.AllowUserToDeleteRows = true;
                            grid.ReadOnly = false;
                        }
                        else
                        {
                            grid.AllowUserToDeleteRows = false;
                            grid.ReadOnly = true;
                        }

                        grid.DataSource = arg.Results;
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
                ShowLog(error.Log);
                MessageBox.Show(this, error.ErrorMessage, "SWQL Studio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void ShowLog(string lastReplyLog)
        {
            logTextbox.Text = lastReplyLog ?? string.Empty;
            LogTabVisible = !string.IsNullOrEmpty(lastReplyLog);
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

        private class QueryArguments
        {
            public ConnectionInfo Connection { get; set; }
            public string Query { get; set; }
            public DataTable Results { get; set; }
            public XmlDocument QueryPlan { get; set; }
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

            Func<Subscription> action;
            SubscriberInfo subscriberInfo;
            if (arg.Connection.ServerType.Equals("Java over HTTP"))
            {
                subscriberInfo = ApplicationService.GetHttpSubscriberInfo();
                action = () => SubscribeHttp(arg.Connection.Proxy, arg.Query, subscriberInfo);
            }
            else
            {
                if (Settings.Default.UseActiveSubscriber)
                    subscriberInfo = arg.Connection.GetActiveSubscriberInfo();
                else
                    subscriberInfo = ApplicationService.GetSubscriberInfo();

                action = () => SubscribeNetTcp(arg.Connection.Proxy, arg.Query, subscriberInfo);
            }

            if (subscriberInfo.OpenedSuccessfully)
            {
                subscriptionWorker.ReportProgress(0, "Starting subscription...");
                try
                {
                    subscription = ConnectionInfo.DoWithExceptionTranslation(action);
                    subscriptionWorker.ReportProgress(0, "Waiting for notifications");
                }
                catch (ApplicationException ex)
                {
                    e.Result = new QueryErrorResult { ErrorMessage = ex.Message, Log = ex.ToString() };
                }
            }
            else
            {
                e.Result = new QueryErrorResult {ErrorMessage = subscriberInfo.ErrorMessage};
            }
        }


        private Subscription SubscribeNetTcp(InfoServiceProxy proxy, string query, SubscriberInfo subscriberInfo)
        {
            return new Subscription(proxy, subscriberInfo.EndpointAddress, query, subscriberInfo.Binding, subscriberInfo.DataFormat);
        }

        private Subscription SubscribeHttp(InfoServiceProxy proxy, string query, SubscriberInfo subscriberInfo)
        {
            return new Subscription(proxy, subscriberInfo.EndpointAddress, query, subscriberInfo.Binding, subscriberInfo.DataFormat, CredentialType.Username, "subscriber", "subscriber");
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
            var errors = new StringBuilder();
            var deletedRows = new List<DataGridViewRow>();
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                try
                {
                    var uri = (string)row.Cells["Uri"].Value;
                    ConnectionInfo.DoWithExceptionTranslation(() => connectionInfo.Proxy.Delete(uri));
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

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                var uri = (string)e.Row.Cells["Uri"].Value;
                ConnectionInfo.DoWithExceptionTranslation(() => connectionInfo.Proxy.Delete(uri));
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "SWQL Studio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var row = dataGridView1.Rows[e.RowIndex];
            var column = dataGridView1.Columns[e.ColumnIndex];
            try
            {
                var uri = (string)row.Cells["Uri"].Value;
                var props = new PropertyBag {{column.DataPropertyName, row.Cells[e.ColumnIndex].Value}};
                ConnectionInfo.DoWithExceptionTranslation(() => connectionInfo.Proxy.Update(uri, props));
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "SWQL Studio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}

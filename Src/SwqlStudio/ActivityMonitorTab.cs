using System;
using System.Windows.Forms;
using SwqlStudio.Subscriptions;

namespace SwqlStudio
{
    public partial class ActivityMonitorTab : TabTemplate, IConnectionTab
    {
        private string subscriptionId;
        private bool connectionSet;

        public SubscriptionManager SubscriptionManager { get; set; }

        public override bool AllowsChangeConnection => !this.connectionSet;

        public override ConnectionInfo ConnectionInfo
        {
            set
            {
                base.ConnectionInfo = value;
                this.connectionSet = true;
            }
        }

        public ActivityMonitorTab()
        {
            InitializeComponent();
            Disposed += ActivityMonitorTabDisposed;
        }

        void ActivityMonitorTabDisposed(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(subscriptionId) && ConnectionInfo.IsConnected)
            {
                this.SubscriptionManager.Unsubscribe(ConnectionInfo, subscriptionId);
            }
        }

        private void SubscriptionIndicationReceived(IndicationEventArgs e)
        {
            if (this.IsDisposed)
                return;

            BeginInvoke(new Action<IndicationEventArgs>(AddIndication), e);
        }

        private void AddIndication(IndicationEventArgs obj)
        {
            var item = new ListViewItem(new[]
                                            {
                                                ((DateTime)obj.IndicationProperties["IndicationTime"]).ToLongTimeString(),
                                                (string)obj.IndicationProperties["QueryText"],
                                                (string)obj.IndicationProperties["Parameters"],
                                                string.Format("{0} ms", obj.IndicationProperties["ExecutionTimeMS"])
                                            });
            listView1.Items.Add(item);
            item.EnsureVisible();
        }

        public void Start()
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            backgroundWorker1.ReportProgress(0, "Waiting for subscriber host to be opened...");

            backgroundWorker1.ReportProgress(0, "Starting subscription...");
            try
            {
                subscriptionId = this.SubscriptionManager.CreateSubscription(ConnectionInfo, "SUBSCRIBE System.QueryExecuted", SubscriptionIndicationReceived);
                backgroundWorker1.ReportProgress(0, "Waiting for notifications");
            }
            catch (ApplicationException ex)
            {
                e.Result = ex;
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            toolStripStatusLabel1.Text = e.UserState.ToString();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
            {
                MessageBox.Show(e.Result.ToString());
            }
        }

        private void CopySelected(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
                return;

            var text = listView1.SelectedItems[0].SubItems[1].Text;
            var param = listView1.SelectedItems[0].SubItems[2].Text;

            var finalText = text;

            if (!string.IsNullOrEmpty(param))
                finalText += $"\n-- {param}";

            Clipboard.SetDataObject(finalText, true);
        }

        private void ClearContent(object sender, EventArgs e)
        {
            listView1.Items.Clear();
        }
    }
}

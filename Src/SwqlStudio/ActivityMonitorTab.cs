using System;
using System.Windows.Forms;

namespace SwqlStudio
{
    public partial class ActivityMonitorTab : UserControl, IConnectionTab
    {
        private string subscriptionId;

        public ActivityMonitorTab()
        {
            InitializeComponent();
            Disposed += ActivityMonitorTabDisposed;
        }

        void ActivityMonitorTabDisposed(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(subscriptionId) && ConnectionInfo.IsConnected)
            {
                ApplicationService.SubscriptionManager.Unsubscribe(ConnectionInfo, subscriptionId);
            }
        }

        public IApplicationService ApplicationService { get; set; }

        private void SubscriptionIndicationReceived(IndicationEventArgs e)
        {
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

        public ConnectionInfo ConnectionInfo { get; set; }

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
                subscriptionId = ApplicationService.SubscriptionManager.CreateSubscription(ConnectionInfo, "SUBSCRIBE System.QueryExecuted", SubscriptionIndicationReceived);
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
            Clipboard.SetDataObject(text, true);
        }

        private void ClearContent(object sender, EventArgs e)
        {
            listView1.Items.Clear();
        }
    }
}

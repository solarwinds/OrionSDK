using System;
using System.Linq;
using System.Windows.Forms;
using SolarWinds.InformationService.Contract2;
using SwqlStudio.Subscriptions;

namespace SwqlStudio
{
    public partial class ActivityMonitorTab : TabTemplate, IConnectionTab
    {
        private readonly IApplicationService applicationService;

        private string subscriptionId;
        private bool connectionSet;
        private bool pause;
        public SubscriptionManager SubscriptionManager { get; set; }

        public override bool AllowsChangeConnection => !this.connectionSet;

        public override ConnectionInfo ConnectionInfo
        {
            set
            {
                base.ConnectionInfo = value;
                this.connectionSet = true;

                this.RefreshSelectedItem();
            }
        }

        public ActivityMonitorTab(IApplicationService applicationService)
        {
            this.applicationService = applicationService ?? throw new ArgumentNullException(nameof(applicationService));

            InitializeComponent();
            Disposed += ActivityMonitorTabDisposed;
        }

        void ActivityMonitorTabDisposed(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(subscriptionId) && ConnectionInfo.IsConnected)
            {
                this.SubscriptionManager.Unsubscribe(ConnectionInfo, subscriptionId, SubscriptionIndicationReceived);
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
            if (pause)
                return;


            var item = new ListViewItem(new[]
                                            {
                                                ((DateTime)obj.IndicationProperties["IndicationTime"]).ToLongTimeString(),
                                                (string)obj.IndicationProperties["QueryText"],
                                                (string)obj.IndicationProperties["Parameters"],
                                                string.Format("{0} ms", obj.IndicationProperties["ExecutionTimeMS"])
                                            });
            item.Tag = obj;

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
                subscriptionId = this.SubscriptionManager
                    .CreateSubscription(ConnectionInfo, "SUBSCRIBE System.QueryExecuted", SubscriptionIndicationReceived);
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
            RefreshSelectedItem();
        }

        private void Pause(object sender, EventArgs e)
        {
            this.pause = !pause;
            this.toolStripButtonPause.Image = this.pause ? Properties.Resources.Run_16x : Properties.Resources.Pause_16x;
            this.toolStripButtonPause.Text = this.pause ? "Run" : "Pause";
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            this.RefreshSelectedItem();
        }

        private void RefreshSelectedItem()
        {
            var selected = this.listView1.SelectedItems.Cast<ListViewItem>().FirstOrDefault();
            if (selected == null)
            {
                this.applicationService.QueryParameters = new PropertyBag();
            }
            else
            {
                var indication = (IndicationEventArgs)selected.Tag;

                this.applicationService.QueryParameters = indication?.IndicationProperties ?? new PropertyBag();

            }
        }
    }
}

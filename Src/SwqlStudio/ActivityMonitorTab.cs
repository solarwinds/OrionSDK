using System;
using System.Windows.Forms;

namespace SwqlStudio
{
    public partial class ActivityMonitorTab : UserControl, IConnectionTab
    {
        private Subscription subscription;

        public ActivityMonitorTab()
        {
            InitializeComponent();
            Disposed += ActivityMonitorTabDisposed;
        }

        void ActivityMonitorTabDisposed(object sender, EventArgs e)
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

        private void SubscriptionIndicationReceived(object sender, IndicationEventArgs e)
        {
            // hack. it would be better to get the actual subscription id and compare properly
            if (subscription != null && subscription.SubscriptionUri.Contains(e.SubscriptionID))
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

            SubscriberInfo subscriberInfo = ApplicationService.GetSubscriberInfo();
            if (subscriberInfo.OpenedSuccessfully)
            {
                backgroundWorker1.ReportProgress(0, "Starting subscription...");
                try
                {
                    subscription = ConnectionInfo.DoWithExceptionTranslation(() => new Subscription(ConnectionInfo.Proxy,
                                                                                                    subscriberInfo.EndpointAddress, "SUBSCRIBE System.QueryExecuted"));
                    backgroundWorker1.ReportProgress(0, "Waiting for notifications");
                }
                catch (ApplicationException ex)
                {
                    e.Result = ex;
                }
            }
            else
            {
                e.Result = new ApplicationException(subscriberInfo.ErrorMessage);
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
    }
}

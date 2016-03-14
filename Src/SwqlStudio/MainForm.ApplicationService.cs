using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SwqlStudio.Metadata;
using SwqlStudio.Subscriptions;

namespace SwqlStudio
{
    partial class MainForm : IApplicationService
    {
        public event EventHandler<IndicationEventArgs> IndicationReceived;


        public SubscriptionManager SubscriptionManager { get; } = new SubscriptionManager();

        public void AddTextToEditor(string text, ConnectionInfo info)
        {
            if (info == null)
                info = ActiveConnectionInfo;

            CreateQueryTab(info.Title, info);
            ActiveQueryTab.QueryText = text;
        }

        public void OpenActivityMonitor(string title, ConnectionInfo info)
        {
            var tab = new TabPage(title) { BorderStyle = BorderStyle.None, Padding = new Padding(0) };
            var activityMonitorTab = new ActivityMonitorTab { ConnectionInfo = info, Dock = DockStyle.Fill, ApplicationService = this };
            tab.Controls.Add(activityMonitorTab);
            fileTabs.Controls.Add(tab);
            fileTabs.SelectedTab = tab;
            activityMonitorTab.Start();
        }

        public void OpenInvokeTab(string title, ConnectionInfo info, Verb verb)
        {
            var tab = new TabPage(title) { BorderStyle = BorderStyle.None, Padding = new Padding(0) };
            var invokeVerbTab = new InvokeVerbTab { ConnectionInfo = info, Dock = DockStyle.Fill, ApplicationService = this, Verb = verb };
            tab.Controls.Add(invokeVerbTab);
            fileTabs.Controls.Add(tab);
            fileTabs.SelectedTab = tab;
        }
    }
}

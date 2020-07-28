using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ScintillaNET;
using SolarWinds.InformationService.Contract2;
using SwqlStudio.Metadata;
using WeifenLuo.WinFormsUI.Docking;

namespace SwqlStudio
{
    public partial class QueriesDockPanel : DockPanel
    {
        private DockContent lastActiveContent = null;
        private ITabsFactory tabsFactory;
        private ObjectExplorer.ObjectExplorer objectExplorer;
        private DockContent objectExplorerContent;
        private QueryParameters queryParametersContent;
        private DocumentationContent documentationContent;

        public PropertyBag QueryParameters
        {
            get { return queryParametersContent.Parameters; }
            set
            {
                queryParametersContent.Parameters = value;
                ShowPropertiesContent(value);
            }
        }

        internal QueryTab ActiveQueryTab
        {
            get
            {
                return SelectedTabFirstControl() as QueryTab;
            }
        }

        internal IConnectionTab ActiveConnectionTab
        {
            get
            {
                return SelectedTabFirstControl() as IConnectionTab;
            }
        }

        /// <summary>Returns a list of all editor controls</summary>
        internal IEnumerable<QueryTab> QueryTabs
        {
            get { return GetAllControlsOnTabs<QueryTab>(); }
        }

        public QueriesDockPanel()
        {
            InitializeComponent();

            InitializeDockPanel();
            InitializeObjectExplorer();
            InitializeQueryParameters();
            InitializeDocumentation();
        }

        public void CreateTabFromPrevious()
        {
            var previousTab = ActiveQueryTab;
            if (previousTab != null)
            {
                tabsFactory.OpenQueryTab(previousTab.QueryText, previousTab.ConnectionInfo);
            }
            else
            {
                tabsFactory.OpenQueryTab();
            }
        }

        private Control SelectedTabFirstControl()
        {
            if (!HasActiveContent())
                return null;

            return lastActiveContent.Controls[0];
        }

        private bool HasActiveContent()
        {
            return lastActiveContent != null;
        }

        private void InitializeDockPanel()
        {
            // Workaround for crash, when form is MDI
            // https://github.com/jacobslusser/ScintillaNET/issues/85
            Scintilla.SetDestroyHandleBehavior(true);
            Theme = new VS2015LightTheme();
            ShowDocumentIcon = false;
            ActiveContentChanged += FilesDock_ActiveContentChanged;
            ContentRemoved += FilesDock_ContentRemoved;
        }

        private void InitializeObjectExplorer()
        {
            objectExplorer = new ObjectExplorer.ObjectExplorer();
            objectExplorer.Dock = DockStyle.Fill;
            objectExplorer.SetGroupingMode(EntityGroupingMode.Flat);
            objectExplorer.Location = new System.Drawing.Point(0, 0);
            objectExplorer.Name = "objectExplorer";
            objectExplorer.Size = new System.Drawing.Size(191, 571);
            objectExplorer.TabIndex = 0;
            objectExplorerContent = new DockContent();
            ConfigureBuildInToolbox(objectExplorerContent);
            objectExplorerContent.Text = "Object explorer";
            objectExplorerContent.Controls.Add(objectExplorer);
            objectExplorerContent.Show(this, DockState.DockLeft);
        }

        private void InitializeQueryParameters()
        {
            queryParametersContent = new QueryParameters();
            queryParametersContent.Text = "Query parameters";
            ConfigureBuildInToolbox(queryParametersContent);
            queryParametersContent.Show(this, DockState.DockRightAutoHide);
        }

        private void InitializeDocumentation()
        {
            documentationContent = new DocumentationContent();
            ConfigureBuildInToolbox(documentationContent);
            objectExplorer.SelectionChanged += ObjectExplorer_SelectionChanged;
            documentationContent.Show(objectExplorerContent.Pane, DockAlignment.Bottom, 0.25);
        }

        private void ObjectExplorer_SelectionChanged(object sender, TreeViewEventArgs e)
        {
            documentationContent.UpdateDocumentation(e.Node);
        }

        private void ConfigureBuildInToolbox(DockContent content)
        {
            content.CloseButton = false;
            content.CloseButtonVisible = false;
        }

        private void FilesDock_ContentRemoved(object sender, DockContentEventArgs e)
        {
            if (e.Content == lastActiveContent)
                lastActiveContent = null;
        }

        private void FilesDock_ActiveContentChanged(object sender, EventArgs e)
        {
            var newContent = ActiveContent as DockContent;
            if (newContent != null &&
                newContent != objectExplorerContent &&
                newContent != queryParametersContent &&
                newContent != documentationContent &&
                newContent != lastActiveContent)
            {
                ActiveQueryTab?.PutParameters();
                lastActiveContent = newContent;
                ActiveQueryTab?.ParseParameters();
            }
        }

        internal void AddServer(IMetadataProvider provider, ConnectionInfo info)
        {
            objectExplorer.AddServer(provider, info);
        }

        internal void CloseActiveContent()
        {
            if (HasActiveContent())
                RemoveTab(lastActiveContent);
        }

        internal void ShowParametersToolbox()
        {
            queryParametersContent.DockState = DockState.DockRight;
            queryParametersContent.Activate();
        }

        internal void SetEntityGroupingMode(EntityGroupingMode mode)
        {
            objectExplorer.SetGroupingMode(mode);
            objectExplorer.RefreshAllServers();
        }

        internal void RefreshObjectExplorerFilters()
        {
            objectExplorer.RefreshFilters();
        }

        internal void FocusSearch()
        {
            objectExplorer.FocusSearch();
        }

        /// <summary>
        /// Close default untitled document if it is still empty
        /// </summary>
        internal void ColoseInitialDocument()
        {
            if (Contents.Count == 3 &&
                ActiveQueryTab != null && ActiveQueryTab.QueryText.Trim() == String.Empty)
                RemoveTab(lastActiveContent);
        }

        internal void RemoveTab(DockContent tabPage)
        {
            if (tabPage != null)
                tabPage.Close();
        }

        internal void OpenFiles(string[] files)
        {
            tabsFactory.OpenFiles(files);
        }

        internal void AddNewQueryTab()
        {
            tabsFactory.OpenQueryTab();
        }

        internal void SetAplicationService(TabsFactory tabsFactory)
        {
            this.tabsFactory = tabsFactory;
            objectExplorer.TabsFactory = tabsFactory;
        }

        internal void AllowSetParameters(bool allow)
        {
            queryParametersContent.AllowSetParameters = allow;
        }

        private void ShowPropertiesContent(PropertyBag value)
        {
            if (value.Keys.Count > 0 && IsPropertiesTabAutoHiden())
            {
                queryParametersContent.IsHidden = false;
                queryParametersContent.DockState = ActivateHidenProperties();
            }
        }

        private bool IsPropertiesTabAutoHiden()
        {
            switch (queryParametersContent.DockState)
            {
                case DockState.DockTopAutoHide:
                case DockState.DockLeftAutoHide:
                case DockState.DockBottomAutoHide:
                case DockState.DockRightAutoHide:
                    return true;
                default:
                    return false;
            }
        }

        private DockState ActivateHidenProperties()
        {
            switch (queryParametersContent.DockState)
            {
                case DockState.DockTopAutoHide:
                    return DockState.DockTop;
                case DockState.DockLeftAutoHide:
                    return DockState.DockLeft;
                case DockState.DockBottomAutoHide:
                    return DockState.DockBottom;
                case DockState.DockRightAutoHide:
                    return DockState.DockRight;
                default:
                    return DockState.DockRight;
            }
        }

        internal void RefreshServer(ConnectionInfo connection)
        {
            objectExplorer.RefreshServer(connection);
        }

        internal void CloseServer(ConnectionInfo current, ConnectionInfo replacement)
        {
            objectExplorer.CloseServer(current);
            CloseAllFixedConnectionTabs(current);
            ReplaceConnection(current, replacement);
        }

        internal void ReplaceConnection(ConnectionInfo current, ConnectionInfo replacement)
        {
            IEnumerable<IConnectionTab> connectionTabs = GetAllControlsOnTabs<IConnectionTab>()
                .Where(t => t.ConnectionInfo == current && t.AllowsChangeConnection);

            foreach (var tab in connectionTabs)
            {
                tab.ConnectionInfo = replacement;
            }
        }

        private void CloseAllFixedConnectionTabs(ConnectionInfo connection)
        {
            var toClose = Contents.OfType<DockContent>()
                .Where(t => IsFixedConnectionTab(t, connection))
                .ToList();

            foreach (var connectionTab in toClose)
            {
                connectionTab.Close();
            }
        }

        private bool IsFixedConnectionTab(DockContent tab, ConnectionInfo connection)
        {
            if (tab.Controls.Count < 1)
                return false;

            var connectionTab = tab.Controls[0] as IConnectionTab;
            return connectionTab != null &&
                   connectionTab.ConnectionInfo == connection &&
                   !connectionTab.AllowsChangeConnection;
        }

        private IEnumerable<TControl> GetAllControlsOnTabs<TControl>()
        {
            return from t in Contents.OfType<DockContent>()
                   from c in t.Controls.OfType<TControl>()
                   select c;
        }
    }
}

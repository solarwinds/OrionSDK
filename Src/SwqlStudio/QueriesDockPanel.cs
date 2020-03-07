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
            get { return this.queryParametersContent.Parameters; }
            set
            {
                this.queryParametersContent.Parameters = value;
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
            var previousTab = this.ActiveQueryTab;
            if (previousTab != null)
            {
                this.tabsFactory.OpenQueryTab(previousTab.QueryText, previousTab.ConnectionInfo);
            }
            else
            {
                this.tabsFactory.OpenQueryTab();
            }
        }

        private Control SelectedTabFirstControl()
        {
            if (!HasActiveContent())
                return null;

            return this.lastActiveContent.Controls[0];
        }

        private bool HasActiveContent()
        {
            return this.lastActiveContent != null;
        }

        private void InitializeDockPanel()
        {
            // Workaround for crash, when form is MDI
            // https://github.com/jacobslusser/ScintillaNET/issues/85
            Scintilla.SetDestroyHandleBehavior(true);
            this.Theme = new VS2015LightTheme();
            this.ShowDocumentIcon = false;
            this.ActiveContentChanged += FilesDock_ActiveContentChanged;
            this.ContentRemoved += FilesDock_ContentRemoved;
        }

        private void InitializeObjectExplorer()
        {
            this.objectExplorer = new ObjectExplorer.ObjectExplorer();
            this.objectExplorer.Dock = DockStyle.Fill;
            this.objectExplorer.SetGroupingMode(EntityGroupingMode.Flat);
            this.objectExplorer.Location = new System.Drawing.Point(0, 0);
            this.objectExplorer.Name = "objectExplorer";
            this.objectExplorer.Size = new System.Drawing.Size(191, 571);
            this.objectExplorer.TabIndex = 0;
            this.objectExplorerContent = new DockContent();
            ConfigureBuildInToolbox(this.objectExplorerContent);
            this.objectExplorerContent.Text = "Object explorer";
            this.objectExplorerContent.Controls.Add(this.objectExplorer);
            this.objectExplorerContent.Show(this, DockState.DockLeft);
        }

        private void InitializeQueryParameters()
        {
            this.queryParametersContent = new QueryParameters();
            this.queryParametersContent.Text = "Query parameters";
            ConfigureBuildInToolbox(this.queryParametersContent);
            this.queryParametersContent.Show(this, DockState.DockRightAutoHide);
        }

        private void InitializeDocumentation()
        {
            this.documentationContent = new DocumentationContent();
            ConfigureBuildInToolbox(this.documentationContent);
            this.objectExplorer.SelectionChanged += ObjectExplorer_SelectionChanged;
            this.documentationContent.Show(this.objectExplorerContent.Pane, DockAlignment.Bottom, 0.25);
        }

        private void ObjectExplorer_SelectionChanged(object sender, TreeViewEventArgs e)
        {
            this.documentationContent.UpdateDocumentation(e.Node);
        }

        private void ConfigureBuildInToolbox(DockContent content)
        {
            content.CloseButton = false;
            content.CloseButtonVisible = false;
        }

        private void FilesDock_ContentRemoved(object sender, DockContentEventArgs e)
        {
            if (e.Content == this.lastActiveContent)
                this.lastActiveContent = null;
        }

        private void FilesDock_ActiveContentChanged(object sender, EventArgs e)
        {
            var newContent = this.ActiveContent as DockContent;
            if (newContent != null &&  
                newContent != this.objectExplorerContent &&
                newContent != this.queryParametersContent &&
                newContent != this.documentationContent &&
                newContent != this.lastActiveContent)
            {
                this.ActiveQueryTab?.PutParameters();
                this.lastActiveContent = newContent;
                this.ActiveQueryTab?.ParseParameters();
            }
        }

        internal void AddServer(IMetadataProvider provider, ConnectionInfo info)
        {
            this.objectExplorer.AddServer(provider, info);
        }

        internal void CloseActiveContent()
        {
            if (HasActiveContent())
                RemoveTab(this.lastActiveContent);
        }

        internal void ShowParametersToolbox()
        {
            this.queryParametersContent.DockState = DockState.DockRight;
            this.queryParametersContent.Activate();
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
            if (this.Contents.Count == 3 &&
                ActiveQueryTab != null && ActiveQueryTab.QueryText.Trim() == String.Empty)
                RemoveTab(this.lastActiveContent);
        }

        internal void RemoveTab(DockContent tabPage)
        {
            if (tabPage != null)
                tabPage.Close();
        }

        internal void OpenFiles(string[] files)
        {
            this.tabsFactory.OpenFiles(files);
        }

        internal void AddNewQueryTab()
        {
            this.tabsFactory.OpenQueryTab();
        }

        internal void SetAplicationService(TabsFactory tabsFactory)
        {
            this.tabsFactory = tabsFactory;
            this.objectExplorer.TabsFactory = tabsFactory;
        }
                
        internal void AllowSetParameters(bool allow)
        {
            this.queryParametersContent.AllowSetParameters = allow;
        }

        private void ShowPropertiesContent(PropertyBag value)
        {
            if (value.Keys.Count > 0 && IsPropertiesTabAutoHiden())
            {
                this.queryParametersContent.IsHidden = false;
                this.queryParametersContent.DockState = ActivateHidenProperties();
            }
        }

        private bool IsPropertiesTabAutoHiden()
        {
            switch (this.queryParametersContent.DockState)
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
            switch (this.queryParametersContent.DockState)
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
                    return  DockState.DockRight;
            }
        }

        internal void RefreshServer(ConnectionInfo connection)
        {
            this.objectExplorer.RefreshServer(connection);
        }

        internal void CloseServer(ConnectionInfo current, ConnectionInfo replacement)
        {
            this.objectExplorer.CloseServer(current);
            this.CloseAllFixedConnectionTabs(current);
            this.ReplaceConnection(current, replacement);
        }

        internal void ReplaceConnection(ConnectionInfo current, ConnectionInfo replacement)
        {
            IEnumerable<IConnectionTab> connectionTabs = this.GetAllControlsOnTabs<IConnectionTab>()
                .Where(t => t.ConnectionInfo == current && t.AllowsChangeConnection);

            foreach (var tab in connectionTabs)
            {
                tab.ConnectionInfo = replacement;
            }
        }

        private void CloseAllFixedConnectionTabs(ConnectionInfo connection)
        {
            var toClose =this.Contents.OfType<DockContent>()
                .Where(t => IsFixedConnectionTab(t, connection))
                .ToList();

            foreach (var connectionTab in toClose)
            {
                connectionTab.Close();
            }
        }

        private bool IsFixedConnectionTab(DockContent tab, ConnectionInfo connection)
        {
            if(tab.Controls.Count < 1)
                return false;

            var connectionTab = tab.Controls[0] as IConnectionTab;
            return connectionTab != null && 
                   connectionTab.ConnectionInfo == connection &&
                   !connectionTab.AllowsChangeConnection;
        }

        private IEnumerable<TControl> GetAllControlsOnTabs<TControl>()
        {
            return from t in this.Contents.OfType<DockContent>()
                from c in t.Controls.OfType<TControl>()
                select c;
        }
    }
}

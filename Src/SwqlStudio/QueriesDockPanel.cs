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
        private TabsFactory tabsFactory;
        private ObjectExplorer objectExplorer;
        private DockContent objectExplorerContent;
        private QueryParameters queryParametersContent;

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
        internal IEnumerable<QueryTab> AllEditors
        {
            get
            {
                return from t in this.Contents.OfType<DockContent>()
                    from c in t.Controls.OfType<QueryTab>()
                    select c;
            }
        }

        public QueriesDockPanel()
        {
            InitializeComponent();

            InitializeDockPanel();
            InitializeObjectExplorer();
            InitializeQueryParameters();
        }

        public void CreateTabFromPrevious()
        {
            this.tabsFactory.CreateTabFromPrevious();
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

        internal void SetObjectExplorerImageList(ImageList imageList)
        {
            this.objectExplorer.ImageList = imageList;
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
            this.objectExplorer = new ObjectExplorer();
            this.objectExplorer.Dock = DockStyle.Fill;
            this.objectExplorer.EntityGroupingMode = EntityGroupingMode.Flat;
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
            var content = this.ActiveContent as DockContent;
            if (content != null &&  (content != this.objectExplorerContent || content != this.queryParametersContent))
            {
                this.lastActiveContent = content;
                this.ActiveQueryTab?.DetectQueryParameters();
            }
        }

        internal void AddServer(IMetadataProvider provider, ConnectionInfo info)
        {
            this.objectExplorer.AddServer(provider, info);
        }

        internal void GenerateSelectStatement(Entity table, bool includeInheritedProperties)
        {
            this.objectExplorer.GenerateSelectStatement(table, includeInheritedProperties);
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
            objectExplorer.EntityGroupingMode = mode;
            objectExplorer.RefreshAllServers();
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
            this.tabsFactory.AddNewQueryTab();
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

        internal void CloseServer(ConnectionInfo connection)
        {
            this.objectExplorer.CloseServer(connection);
        }

        internal void RefreshServer(ConnectionInfo connection)
        {
            this.objectExplorer.RefreshServer(connection);
        }

        internal void CloseAllFixedConnectionTabs(ConnectionInfo connection)
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
    }
}

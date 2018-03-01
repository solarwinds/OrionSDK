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
        private ObjectExplorer objectExplorer;
        private DockContent objectExplorerContent;
        private QueryParameters queryParametersContent;

        internal ImageList ObjectExplorerImageList
        {
            get
            {
                return this.objectExplorer.ImageList;
            }
            set
            {
                this.objectExplorer.ImageList = value;
            }
        }
        
        internal IApplicationService ApplicationService
        {
            get
            {
                return this.objectExplorer.ApplicationService;
            }
            set
            {
                this.objectExplorer.ApplicationService = value;
            }
        }

        public PropertyBag QueryParameters
        {
            get { return this.queryParametersContent.Parameters; }
        }

        /// <summary>Returns the currently displayed editor, or null if none are open</summary>
        internal SciTextEditorControl ActiveEditor
        {
            get
            {
                var tab = ActiveQueryTab;
                if (tab == null) return null;
                return tab.Editor;
            }
        }

        internal ConnectionInfo ActiveConnectionInfo
        {
            get
            {
                var tab = ActiveConnectionTab;
                if (tab == null) return null;
                return tab.ConnectionInfo;
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
        internal IEnumerable<SciTextEditorControl> AllEditors
        {
            get
            {
                return from t in this.Contents.OfType<DockContent>()
                    from c in t.Controls.OfType<SciTextEditorControl>()
                    select c;
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

        public QueriesDockPanel()
        {
            InitializeComponent();

            InitializeDockPanel();
            InitializeObjectExplorer();
            InitializeQueryParameters();
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
            this.queryParametersContent.Show(this, DockState.DockRight);
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
            if (content != null && this.objectExplorerContent != content)
            {
                this.lastActiveContent = content;
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
    }
}

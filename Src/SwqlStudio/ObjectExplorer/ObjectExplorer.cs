using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using SolarWinds.Logging;
using SwqlStudio.Filtering;
using SwqlStudio.Metadata;
using SwqlStudio.Utils;
using TextBox = System.Windows.Forms.TextBox;
using TreeNode = System.Windows.Forms.TreeNode;
using TreeView = System.Windows.Forms.TreeView;

namespace SwqlStudio.ObjectExplorer
{
    internal class ObjectExplorer : Control
    {
        private static readonly Log log = new Log();

        private readonly SearchTextBox _treeSearch;
        private readonly TreeView _tree;
        private TreeView _treeData;
        private TreeNodeUtils.TreeNodeBindings _treeBindings = new TreeNodeUtils.TreeNodeBindings(); // default value, so this field is never null
        private TreeNode _contextMenuNode;
        private readonly Dictionary<string, ContextMenu> _tableContextMenuItems;
        private readonly Dictionary<string, ContextMenu> _tableCrudContextMenuItems;
        private readonly Dictionary<string, ContextMenuStrip> _serverContextMenuItems;
        private readonly ContextMenu _verbContextMenu;
        private bool _isDragging;
        private string _filter;
        private bool _treeIsUnderUpdate; 
        private Point _lastLocation;
        private ImageList objectExplorerImageList;
        private System.ComponentModel.IContainer components;
        private TreeNode _dragNode;
        private readonly TreeNodesBuilder treeNodesBuilder = new TreeNodesBuilder(DefaultFont);
        public event TreeViewEventHandler SelectionChanged;
        public ITabsFactory TabsFactory { get; set; }

        public ObjectExplorer()
        {
            InitializeComponent();

            _treeSearch = new SearchTextBox
            {
                Dock = DockStyle.Top
            };


            _tree = new TreeView
            {
                Dock = DockStyle.Fill,
                ShowNodeToolTips = true
            };

            InitializeTreeview();

            _treeSearch.TextChangedWithDebounce += (sender, e) => { SetFilter(((TextBox) sender).Text); };
            _treeSearch.CueText = "Search (Ctrl + \\)";
            _treeSearch.DebounceLimit = TimeSpan.FromMilliseconds(400);

            _tableContextMenuItems = new Dictionary<string, ContextMenu>();
            _serverContextMenuItems = new Dictionary<string, ContextMenuStrip>();
            _tableCrudContextMenuItems = new Dictionary<string, ContextMenu>();

            _verbContextMenu = new ContextMenu();
            _verbContextMenu.MenuItems.Add("Invoke...", (s, e) => OpenInvokeTab());

            Controls.Add(_tree);
            Controls.Add(_treeSearch);
        }

        private void InitializeTreeview()
        {
            _treeData = new TreeView();

            _tree.MouseDown += TreeMouseDown;
            _tree.MouseMove += TreeMouseMove;
            _tree.MouseUp += _tree_MouseUp;
            _tree.BeforeExpand += (sender, e) =>
            {
                e.Cancel = !AllowExpandCollapse;
                if (!e.Cancel) _tree_BeforeExpand(sender, e);
            };
            _tree.BeforeCollapse += (sender, e) => { e.Cancel = !AllowExpandCollapse; };
            // copy expanded / not expanded state to data, so it is persisted
            _tree.AfterExpand += (sender, e) =>
            {
                if (_treeIsUnderUpdate) // we are calling expand on the display tree when cloning from data. 
                    // we do not want to update data with such information, as we dont have proper _treeBindings at the moment
                    return;

                var dataNode = _treeBindings.FindDataNode(e.Node);
                dataNode.Expand();
            };

            _tree.AfterCollapse += (sender, e) =>
            {
                if (_treeIsUnderUpdate)
                    return;

                var dataNode = _treeBindings.FindDataNode(e.Node);
                dataNode.Collapse();
            };

            _tree.NodeMouseDoubleClick += _tree_NodeMouseDoubleClick;
            _tree.AfterSelect += OnTreeOnAfterSelect;
            _tree.ImageList = this.objectExplorerImageList;
        }

        private void OnTreeOnAfterSelect(object sender, TreeViewEventArgs args)
        {
            this.SelectionChanged?.Invoke(this, args);
        }

        public void FocusSearch()
        {
            _treeSearch.Focus();
        }

        private void SetFilter(string filter)
        {
            if (string.IsNullOrWhiteSpace(filter))
                filter = null;

            if (_filter != filter)
            {
                _filter = filter;
                UpdateDrawnNodes();
            }
        }

        // since we have data in _treeData, but are displaying _tree,
        // we need to copy data from treedata to trees (according to applied filter)
        private void UpdateDrawnNodes()
        {
            _treeData.SelectedNode = _treeBindings.FindDataNode(_tree.SelectedNode);

            _treeIsUnderUpdate = true;
            _tree.BeginUpdate();
            try
            {
                var filters = new NodeFilter(_treeData, _filter);

                _treeBindings = TreeNodeUtils.CopyTree(_treeData, _tree, filters.FilterAction, filters.UpdateAction);

                _tree.SetHorizontalScroll(0);

                UpdateDrawnNodesSelection();
            }
            finally
            {
                _tree.EndUpdate();
                _treeIsUnderUpdate = false;
            }
        }

        private void UpdateDrawnNodesSelection()
        {
            _tree.SelectedNode = _treeBindings.FindDisplayNode(_treeData.SelectedNode);
        }

        private bool AllowExpandCollapse
        {
            get
            {
                Point p = _tree.PointToClient(MousePosition);
                var hitTest = _tree.HitTest(p);

                return hitTest != null && hitTest.Location != TreeViewHitTestLocations.Label || _treeIsUnderUpdate;
            }
        }

        private void GenerateCSharpCode(TreeNode contextMenuNode)
        {
            var dialog = new FolderBrowserDialog();
            if (DialogResult.OK == dialog.ShowDialog(FindForm()))
            {
                var metadataProvider = FindProvider(contextMenuNode);
                CodeGenerator.GenerateCSharpCode(metadataProvider.Tables, dialog.SelectedPath);
            }
        }

        private void TreeMouseDown(object sender, MouseEventArgs e)
        {
            _isDragging = false;
            _lastLocation = e.Location;
            _dragNode = _tree.GetNodeAt(e.X, e.Y);
        }

        private void TreeMouseMove(object sender, MouseEventArgs e)
        {
            const int diff = 10;
            if (_dragNode != null && !_isDragging && ((Math.Abs(_lastLocation.X - e.Location.X) >= diff) || (Math.Abs(_lastLocation.Y - e.Location.Y) >= diff)))
            {
                _isDragging = true;
                _tree.DoDragDrop(_dragNode.Tag, DragDropEffects.Copy);
                _dragNode = null;
            }
        }

        void _tree_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            var verbNode = e.Node;
            if (verbNode.Tag is Verb)
            {
                var provider = FindProvider(verbNode);
                TreeNodesBuilder.RebuildVerbArguments(verbNode, provider);
            }
        }


        void _tree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag != null)
            {
                _contextMenuNode = e.Node;

                if ((_contextMenuNode as TreeNodeWithConnectionInfo) != null)
                {
                    if (_contextMenuNode.Tag is Entity)
                    {
                        Entity table = _contextMenuNode.Tag as Entity;
                        GenerateSelectStatement(table, !table.IsIndication && table.IsAbstract);
                    }
                    else
                        if (_contextMenuNode.Tag is IMetadataProvider)
                            OpenActivityMonitor(_contextMenuNode);
                } else
                    if (_contextMenuNode.Tag is Verb)
                        OpenInvokeTab();
            }
        }

        private IMetadataProvider FindProvider(TreeNode node)
        {
            var providerNode = node as TreeNodeWithConnectionInfo;
            if (providerNode?.Provider != null)
                return providerNode.Provider;

            throw new InvalidOperationException("No IMetadataProvider found in tree.");
        }

        public void RefreshAllServers()
        {
            foreach (TreeNode node in _treeData.Nodes)
            {
                RefreshServer(node);
            }

            UpdateDrawnNodes();
        }

        public void RefreshFilters() => UpdateDrawnNodes();

        internal void RefreshServer(ConnectionInfo connection)
        {
            TreeNodeWithConnectionInfo serverNode = FindServerNodeByConnection(connection);
            RefreshServer(serverNode);
        }

        private void RefreshServer(TreeNode node)
        {
            var provider = node.Tag as IMetadataProvider;
            if (provider != null)
            {
                UseWaitCursor = true;
                try
                {
                    node.Nodes.Clear();
                    node.Nodes.Add("Refreshing...");
                    ThreadPool.QueueUserWorkItem(o =>
                                                     {
                                                         try
                                                         {
                                                             provider.Refresh();
                                                             BeginInvoke(new Action(() =>
                                                                 {
                                                                     var treeNodeWithConnectionInfo = node as TreeNodeWithConnectionInfo;
                                                                     if (treeNodeWithConnectionInfo != null)
                                                                         this.treeNodesBuilder.RebuildDatabaseNode(node, provider);
                                                                     else
                                                                         node.Nodes.Clear();

                                                                     UpdateDrawnNodes();
                                                                 }));
                                                         }
                                                         catch (FaultException faultEx)
                                                         {
                                                             BeginInvoke(new Action(() => MessageBox.Show(this, faultEx.Message)));
                                                         }
                                                         catch (MessageSecurityException ex)
                                                         {
                                                             BeginInvoke(new Action(() => MessageBox.Show(this, ex.Message)));
                                                         }
                                                         catch (Exception ex)
                                                         {
                                                             BeginInvoke(new Action(() => MessageBox.Show(this, ex.Message)));
                                                         }
                                                     });
                }
                finally
                {
                    UseWaitCursor = false;
                }
            }
        }

        private void OpenActivityMonitor(TreeNode node)
        {
            var provider = node.Tag as IMetadataProvider;
            if (provider != null && provider.ConnectionInfo.CanCreateSubscription)
                TabsFactory.OpenActivityMonitor(provider.ConnectionInfo);
        }

        private void OpenInvokeTab()
        {
            var provider = FindProvider(_contextMenuNode);
            var verb = (Verb)_contextMenuNode.Tag;
            if (verb.Arguments.Count == 0)
                verb.Arguments.AddRange(provider.GetVerbArguments(verb));
            TabsFactory.OpenInvokeTab(provider.ConnectionInfo, verb);
        }

        public void GenerateSelectStatement(Entity table, bool includeInheritedProperties)
        {
            if (table != null)
            {
                string query = GenerateSwql(table, includeInheritedProperties);
                AddTextEditor(query);
            }
        }

        void _tree_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                _contextMenuNode = _tree.GetNodeAt(e.X, e.Y);

                if (_contextMenuNode != null)
                {
                    if (_contextMenuNode.Tag is Entity)
                    {
                        var treeNodeWithConnectionInfo = _contextMenuNode as TreeNodeWithConnectionInfo;
                        if (treeNodeWithConnectionInfo != null && treeNodeWithConnectionInfo.Tag is Entity entity)
                        {
                            // crud does not make sense on indications
                            if (!entity.IsIndication && (entity.CanCreate || entity.CanDelete || entity.CanUpdate))
                            {
                                var menuItem = _tableCrudContextMenuItems[treeNodeWithConnectionInfo.Connection.Title];

                                foreach (MenuItem subMenuItem in menuItem.MenuItems)
                                {
                                    if (subMenuItem.Name == "create") subMenuItem.Enabled = entity.CanCreate;
                                    if (subMenuItem.Name == "update") subMenuItem.Enabled = entity.CanUpdate;
                                    if (subMenuItem.Name == "delete") subMenuItem.Enabled = entity.CanDelete;
                                }

                                menuItem.Show(_tree, e.Location);
                            }
                            else
                            {
                                _tableContextMenuItems[treeNodeWithConnectionInfo.Connection.Title].Show(_tree, e.Location);
                            }
                        }
                    }

                    if (_contextMenuNode.Tag is IMetadataProvider)
                    {
                        var nodeWithConnectionInfo = _contextMenuNode as TreeNodeWithConnectionInfo;
                        if (nodeWithConnectionInfo != null)
                            _serverContextMenuItems[nodeWithConnectionInfo.Connection.Title].Show(_tree, e.Location);
                    }

                    if (_contextMenuNode.Tag is Verb)
                        _verbContextMenu.Show(_tree, e.Location);
                }
            }
        }

        private string GenerateSwql(Entity table, bool includeInheritedProperties)
        {
            StringBuilder sb = new StringBuilder();

            var queryProperties = table.Properties.Where(c => c.IsNavigable == false);

            if (includeInheritedProperties == false)
                queryProperties = queryProperties.Where(c => c.IsInherited == false);

            sb.Append("SELECT TOP 1000 ");
            sb.AppendLine(String.Join(", ", queryProperties.Select(c => c.Name).Distinct().ToArray()));
            sb.AppendFormat("FROM {0}", table.FullName);
            sb.AppendLine();

            return sb.ToString();
        }

        public void AddServer(IMetadataProvider provider, ConnectionInfo connection)
        {
            //Check if the current connection can create subscription
            DataTable dt = null;

            try
            {
                dt = connection.Query("SELECT CanCreate FROM Metadata.Entity WHERE FullName='System.Subscription'");
            }
            catch (ApplicationException e)
            {
                log.Info("Exception checking if we can create subscriptions.", e);
            }

            if (dt != null && (dt.Rows.Count == 1 && dt.Columns.Count == 1))
            {
                connection.CanCreateSubscription = Convert.ToBoolean(dt.Rows[0][0]);
            }

            var tableContextMenuWithoutCrud = new ContextMenu();
            var tableContextMenuWithCrud = new ContextMenu();

            var commonTableContextMenus = new[] { tableContextMenuWithCrud, tableContextMenuWithoutCrud };
            foreach(var tableContextMenu in commonTableContextMenus)
            { 
                tableContextMenu.MenuItems.Add("Generate Select Statement", (s, e) => GenerateSelectStatement(_contextMenuNode.Tag as Entity, false));
                tableContextMenu.MenuItems.Add("Generate Select Statement (with Inherited Properties)", (s, e) => GenerateSelectStatement(_contextMenuNode.Tag as Entity, true));

                if (connection.CanCreateSubscription)
                    tableContextMenu.MenuItems.Add("Subscribe", StartSubscription);
            }

            tableContextMenuWithCrud.MenuItems.Add("-");
            // note: the names are crucial for disabling/enabling the menu based on operations allowed
            tableContextMenuWithCrud.MenuItems.Add("Create", (s, e) => Crud(_contextMenuNode.Tag as Entity, CrudOperation.Create)).Name = "create";
            tableContextMenuWithCrud.MenuItems.Add("Update", (s, e) => Crud(_contextMenuNode.Tag as Entity, CrudOperation.Update)).Name = "update";
            tableContextMenuWithCrud.MenuItems.Add("Delete", (s, e) => Crud(_contextMenuNode.Tag as Entity, CrudOperation.Delete)).Name = "delete";


            _tableContextMenuItems.Add(connection.Title, tableContextMenuWithoutCrud);
            _tableCrudContextMenuItems.Add(connection.Title, tableContextMenuWithCrud);

            var serverContextMenu = new ContextMenuStrip();
            serverContextMenu.Items.Add("Refresh", Properties.Resources.Refresh_16x, (s, e) => RefreshServer(_contextMenuNode));

            if (connection.CanCreateSubscription)
                serverContextMenu.Items.Add("Activity Monitor", null, (s, e) => OpenActivityMonitor(_contextMenuNode));

            serverContextMenu.Items.Add("Generate C# Code...", null, (s, e) => GenerateCSharpCode(_contextMenuNode));
            var closeMenuItem = new ToolStripMenuItem("Disconnect", Properties.Resources.Disconnect_16x,
                (s, e) => CloseServer(_contextMenuNode));
            serverContextMenu.Items.Add(closeMenuItem);

            _serverContextMenuItems.Add(connection.Title, serverContextMenu);

            TreeNode[] existingNodes = _treeData.Nodes.Find(provider.Name, false);
            if (existingNodes.Length == 0)
            {
                TreeNode databaseNode = TreeNodesBuilder.CreateDatabaseNode(_treeData, provider, connection);
                RefreshServer(databaseNode);
            }
            else
            {
                // Node exists.  Just focus on it.
                _treeData.SelectedNode = existingNodes[0];
                UpdateDrawnNodesSelection();
            }
        }

        internal void CloseServer(ConnectionInfo connection)
        {
            TreeNodeWithConnectionInfo serverNode = FindServerNodeByConnection(connection);
            if (serverNode != null)
            {
                RemoveFromMenus(serverNode.Connection);
                _treeData.Nodes.Remove(_treeBindings.FindDataNode(serverNode));
                _tree.Nodes.Remove(serverNode);
            }
        }

        private TreeNodeWithConnectionInfo FindServerNodeByConnection(ConnectionInfo connection)
        {
            return _tree.Nodes.OfType<TreeNodeWithConnectionInfo>()
                .FirstOrDefault(n => n.Connection == connection);
        }

        private void CloseServer(TreeNode contextMenuNode)
        {
            var node = contextMenuNode as TreeNodeWithConnectionInfo;
            if (node != null)
                node.Connection.Close();
        }

        private void RemoveFromMenus(ConnectionInfo connection)
        {
            string title = connection.Title;
            var tableContextMenuWithoutCrud = _tableContextMenuItems[title];
            _tableContextMenuItems.Remove(title);
            tableContextMenuWithoutCrud.Dispose();

            var tableContextMenuWithCrud = _tableCrudContextMenuItems[title];
            _tableCrudContextMenuItems.Remove(title);
            tableContextMenuWithCrud.Dispose();

            var serverContextMenu = _serverContextMenuItems[title];
            _serverContextMenuItems.Remove(title);
            serverContextMenu.Dispose();
        }

        private void Crud(Entity entity, CrudOperation operation)
        {
            var provider = FindProvider(_contextMenuNode);
            TabsFactory.OpenCrudTab(operation, provider.ConnectionInfo, entity);
        }

        private void StartSubscription(object sender, EventArgs e)
        {
            var table = _contextMenuNode.Tag as Entity;
            if (table != null)
            {
                string query = string.Format(table.IsIndication ? "SUBSCRIBE {0}" : "SUBSCRIBE CHANGES TO {0}", table.FullName);
                AddTextEditor(query);
            }
        }

        private void AddTextEditor(string query)
        {
            var node = _contextMenuNode as TreeNodeWithConnectionInfo;
            if (node != null)
            {
                TabsFactory.OpenQueryTab(query, node.Connection);
            }
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ObjectExplorerResources));
            this.objectExplorerImageList = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // objectExplorerImageList
            // 
            this.objectExplorerImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("objectExplorerImageList.ImageStream")));
            this.objectExplorerImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.objectExplorerImageList.Images.SetKeyName(0, ImageKeys.Column);
            this.objectExplorerImageList.Images.SetKeyName(1, ImageKeys.Database);
            this.objectExplorerImageList.Images.SetKeyName(2, ImageKeys.Link);
            this.objectExplorerImageList.Images.SetKeyName(3, ImageKeys.Table);
            this.objectExplorerImageList.Images.SetKeyName(4, ImageKeys.InheritedColumn);
            this.objectExplorerImageList.Images.SetKeyName(5, ImageKeys.KeyColumn);
            this.objectExplorerImageList.Images.SetKeyName(6, ImageKeys.Verb);
            this.objectExplorerImageList.Images.SetKeyName(7, ImageKeys.Argument);
            this.objectExplorerImageList.Images.SetKeyName(8, ImageKeys.Indication);
            this.objectExplorerImageList.Images.SetKeyName(9, ImageKeys.Namespace);
            this.objectExplorerImageList.Images.SetKeyName(10, ImageKeys.BaseType);
            this.objectExplorerImageList.Images.SetKeyName(11, ImageKeys.BaseTypeAbstract);
            this.objectExplorerImageList.Images.SetKeyName(12, ImageKeys.TableAbstract);
            this.objectExplorerImageList.Images.SetKeyName(13, ImageKeys.TableCrud);
            this.ResumeLayout(false);

        }

        public void SetGroupingMode(EntityGroupingMode mode)
        {
            this.treeNodesBuilder.EntityGroupingMode = mode;
        }
    }
}

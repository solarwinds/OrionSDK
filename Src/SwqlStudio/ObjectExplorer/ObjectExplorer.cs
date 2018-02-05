using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.Text;
using System.Threading;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using SolarWinds.Logging;
using SwqlStudio.Metadata;
using SwqlStudio.Utils;
using TextBox = System.Windows.Forms.TextBox;
using TreeNode = System.Windows.Forms.TreeNode;
using TreeView = System.Windows.Forms.TreeView;

namespace SwqlStudio
{
    enum EntityGroupingMode
    {
        Flat = 1,
        ByNamespace = 2,
        ByBaseType = 3,
        ByHierarchy = 4
    }

    class ObjectExplorer : Control
    {
        private static readonly Log log = new Log();

        private readonly SearchTextBox _treeSearch;
        private readonly TreeView _tree;
        private readonly TreeView _treeData;
        private TreeNodeUtils.TreeNodeBindings _treeBindings = new TreeNodeUtils.TreeNodeBindings(); // default value, so this field is never null
        private TreeNode _contextMenuNode;
        private readonly Dictionary<string, ContextMenu> _tableContextMenuItems;
        private readonly Dictionary<string, ContextMenu> _serverContextMenuItems;
        private readonly ContextMenu _verbContextMenu;
        private bool _isDragging;
        private string _filter;
        private bool _treeIsUnderUpdate; 
        private Point _lastLocation;
        private TreeNode _dragNode;


        public IApplicationService ApplicationService { get; set; }

        public EntityGroupingMode EntityGroupingMode { get; set; }

        public ObjectExplorer()
        {
            _treeSearch = new SearchTextBox
            {
                Dock = DockStyle.Top
            };


            _tree = new TreeView
            {
                Dock = DockStyle.Fill,
                ShowNodeToolTips = true
            };

            _treeData = new TreeView();

            _tree.MouseDown += TreeMouseDown;
            _tree.MouseMove += TreeMouseMove;
            _tree.MouseUp += _tree_MouseUp;
            _tree.BeforeExpand += (sender, e) => { e.Cancel = !AllowExpandCollapse; if (!e.Cancel) _tree_BeforeExpand(sender, e); };
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
            _treeSearch.TextChangedWithDebounce += (sender, e) => { SetFilter(((TextBox) sender).Text); };
            _treeSearch.CueText = "Search (Ctrl + \\)";
            _treeSearch.DebounceLimit = TimeSpan.FromMilliseconds(400);

            _tableContextMenuItems = new Dictionary<string, ContextMenu>();
            _serverContextMenuItems = new Dictionary<string, ContextMenu>();

            _verbContextMenu = new ContextMenu();
            _verbContextMenu.MenuItems.Add("Invoke...", (s, e) => OpenInvokeTab());

            Controls.Add(_tree);
            Controls.Add(_treeSearch);
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
            _tree.Nodes.Clear();
            try
            {
                // quick path
                if (_filter == null)
                {
                    _treeBindings = TreeNodeUtils.CopyTree(_treeData, _tree, null, null);
                }
                else
                {
                    var visibility = new TreeNodeUtils.NodeVisibility();
                    TreeNodeUtils.IterateNodes(_treeData, node =>
                    {
                        if (PassesFilter(node))
                            visibility.SetVisible(node);
                    });

                    _treeBindings = TreeNodeUtils.CopyTree(_treeData, _tree,
                        node => visibility.GetVisibility(node) !=
                                TreeNodeUtils.NodeVisibility.VisibilityStatus.NotVisible, (data, display) =>
                        {
                            var nodeVisibility = visibility.GetVisibility(data);
                            if (nodeVisibility == TreeNodeUtils.NodeVisibility.VisibilityStatus.ChildVisible)
                                // this one is not directly visible, gray it out
                                display.ForeColor = Color.LightBlue;

                            if (nodeVisibility == TreeNodeUtils.NodeVisibility.VisibilityStatus.ParentVisible)
                                // this one is not directly visible, gray it out
                                display.ForeColor = Color.DarkGray;

                            // this one is visible directly, ensure it is visible (parents are expanded).
                            // it's children are visible as well, but may be not expanded
                            if (nodeVisibility == TreeNodeUtils.NodeVisibility.VisibilityStatus.Visible)
                                display.EnsureVisible();
                        });


                    _tree.SetHorizontalScroll(0);
                }

                UpdateDrawnNodesSelection();
            }
            finally
            {
                _tree.EndUpdate();
                _treeIsUnderUpdate = false;
            }
        }

        private bool PassesFilter(TreeNode node)
        {
            var nodeText = node.Text.Split('(')[0]; // trim everything after first (, we do not want to use it in search

            if (nodeText.IndexOf(_filter, StringComparison.OrdinalIgnoreCase) >= 0)
                return true;

            else // behave in 'special' way for dots, and capitals, the same way as resharper does
                 // let's Met.Ent match also METadata...ENTity
                 // also Met.EntNa should match Metadata.EntityName
            {
                var filter = SplitTextByCapsAndDot(_filter);
                var text = SplitTextByCapsAndDot(nodeText);

                int textPivot = 0;

                for (int filterPivot = 0; filterPivot < filter.Count; filterPivot++)
                {
                    for (; textPivot <= text.Count; textPivot++)
                    {
                        if (textPivot == text.Count)
                            return false;

                        if (text[textPivot].StartsWith(filter[filterPivot], StringComparison.OrdinalIgnoreCase))
                            break;
                    }
                    textPivot++;
                }

                return true;
            }
        }

        private static List<string> SplitTextByCapsAndDot(string text)
        {
            var rv = new List<string>();

            var buf = new StringBuilder();

            void FlushBuffer()
            {
                if (buf.Length > 0)
                    rv.Add(buf.ToString());

                buf.Clear();
            }

            foreach (var t in text)
            {
                if (t == '.')
                {
                    FlushBuffer();
                }
                else
                {
                    if (char.IsUpper(t))
                        FlushBuffer();

                    buf.Append(t);
                }
            }

            FlushBuffer();
            return rv;
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

                return hitTest != null && hitTest.Location != TreeViewHitTestLocations.Label;
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
            var verb = e.Node.Tag as Verb;
            if (verb != null)
            {
                e.Node.Nodes.Clear();

                foreach (var arg in FindProvider(e.Node).GetVerbArguments(verb))
                {
                    string text = String.Format("{0}({1})", arg.Name, arg.Type);
                    var argNode = new TreeNode(text) { SelectedImageKey = "Argument" };
                    argNode.ImageKey = argNode.SelectedImageKey;
                    argNode.Tag = arg;
                    e.Node.Nodes.Add(argNode);
                }
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
            var provider = node.Tag as IMetadataProvider;
            if (provider != null)
                return provider;

            if (node.Parent == null)
                throw new InvalidOperationException("No IMetadataProvider found in tree.");

            return FindProvider(node.Parent);
        }

        public void RefreshAllServers()
        {
            foreach (TreeNode node in _treeData.Nodes)
            {
                RefreshServer(node);
            }

            UpdateDrawnNodes();
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
                                                                     node.Nodes.Clear();
                                                                     var treeNodeWithConnectionInfo = node as TreeNodeWithConnectionInfo;
                                                                     if (treeNodeWithConnectionInfo != null)
                                                                         AddTablesToNode(node, provider, treeNodeWithConnectionInfo.Connection);
                                                                     else
                                                                         AddTablesToNode(node, provider, null);

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
                ApplicationService.OpenActivityMonitor(provider.ConnectionInfo.Title + " Activity", provider.ConnectionInfo);
        }

        private void OpenInvokeTab()
        {
            var provider = FindProvider(_contextMenuNode);
            var verb = (Verb)_contextMenuNode.Tag;
            if (verb.Arguments.Count == 0)
                verb.Arguments.AddRange(provider.GetVerbArguments(verb));
            ApplicationService.OpenInvokeTab(string.Format("{0} - Invoke {1}.{2}", provider.ConnectionInfo.Title, verb.EntityName, verb.Name),
                                             provider.ConnectionInfo, verb);
        }

        public void GenerateSelectStatement(Entity table, bool includeInheritedProperties)
        {
            if (table != null)
            {
                string swql = GenerateSwql(table, includeInheritedProperties);

                ConnectionInfo connection = null;
                if ((_contextMenuNode as TreeNodeWithConnectionInfo) != null)
                    connection = (_contextMenuNode as TreeNodeWithConnectionInfo).Connection;

                ApplicationService.AddTextToEditor(swql, connection);
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
                        if (treeNodeWithConnectionInfo != null)
                            _tableContextMenuItems[treeNodeWithConnectionInfo.Connection.Title].Show(_tree, e.Location);
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

        public ImageList ImageList
        {
            get { return _tree.ImageList; }
            set { _tree.ImageList = value; }
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

            var tableContextMenu = new ContextMenu();
            tableContextMenu.MenuItems.Add("Generate Select Statement", (s, e) => GenerateSelectStatement(_contextMenuNode.Tag as Entity, false));
            tableContextMenu.MenuItems.Add("Generate Select Statement (with Inherited Properties)", (s, e) => GenerateSelectStatement(_contextMenuNode.Tag as Entity, true));

            if (connection.CanCreateSubscription)
                tableContextMenu.MenuItems.Add("Subscribe", StartSubscription);

            _tableContextMenuItems.Add(connection.Title, tableContextMenu);

            var serverContextMenu = new ContextMenu();
            serverContextMenu.MenuItems.Add("Refresh", (s, e) => RefreshServer(_contextMenuNode));

            if (connection.CanCreateSubscription)
                serverContextMenu.MenuItems.Add("Activity Monitor", (s, e) => OpenActivityMonitor(_contextMenuNode));

            serverContextMenu.MenuItems.Add("Generate C# Code...", (s, e) => GenerateCSharpCode(_contextMenuNode));
            serverContextMenu.MenuItems.Add("Close", (s, e) => CloseServer(_contextMenuNode));

            _serverContextMenuItems.Add(connection.Title, serverContextMenu);


            TreeNode node = CreateDatabaseNode(provider, connection);

            TreeNode[] existingNodes = _treeData.Nodes.Find(node.Name, false);
            if (existingNodes.Length == 0)
            {
                // Node doesn't already exist.  Add it
                _treeData.Nodes.Add(node);
                _treeData.SelectedNode = node;
                RefreshServer(node);
            }
            else
            {
                // Node exists.  Just focus on it.
                _treeData.SelectedNode = existingNodes[0];
                UpdateDrawnNodesSelection();
            }

            connection.ConnectionClosed += (o, e) =>
            {
                _tableContextMenuItems.Remove(connection.Title);
                tableContextMenu.Dispose();
                tableContextMenu = null;

                _serverContextMenuItems.Remove(connection.Title);
                serverContextMenu.Dispose();
                serverContextMenu = null;
            };
        }

        private void CloseServer(TreeNode contextMenuNode)
        {
            TreeNodeWithConnectionInfo node = contextMenuNode as TreeNodeWithConnectionInfo;
            if (node != null)
            {
                node.Connection.Close();
                _treeData.Nodes.Remove(_treeBindings.FindDataNode(node));
            }
        }

        private static TreeNode CreateDatabaseNode(IMetadataProvider provider, ConnectionInfo connection)
        {
            TreeNode node = new TreeNodeWithConnectionInfo(provider.Name, connection);
            node.SelectedImageKey = "Database";
            node.ImageKey = "Database";
            node.Tag = provider;
            node.Name = node.Text;

            return node;
        }

        private void AddTablesToNode(TreeNode parent, IMetadataProvider provider, ConnectionInfo connection)
        {
            switch (EntityGroupingMode)
            {
                case EntityGroupingMode.Flat:
                    parent.Nodes.AddRange(MakeEntityTreeNodes(provider, connection, provider.Tables.OrderBy(e => e.FullName)));
                    break;
                case EntityGroupingMode.ByNamespace:
                    foreach (var group in provider.Tables.GroupBy(e => e.Namespace).OrderBy(g => g.Key))
                    {
                        TreeNode[] childNodes = MakeEntityTreeNodes(provider, connection, group.OrderBy(e => e.FullName));

                        int countChilds = childNodes.Length;
                        var namespaceNode = new TreeNode(string.Format("{0} ({1} item{2})", group.Key, countChilds, countChilds > 1 ? "s" : string.Empty))
                        {
                            Tag = group.Key,
                            ImageKey = "Namespace"
                        };
                        namespaceNode.SelectedImageKey = namespaceNode.ImageKey;

                        namespaceNode.Nodes.AddRange(childNodes);
                        parent.Nodes.Add(namespaceNode);
                    }
                    break;
                case SwqlStudio.EntityGroupingMode.ByBaseType:
                    foreach (var group in provider.Tables.Where(e => e.BaseEntity != null).GroupBy(
                        e => e.BaseEntity,
                        (key, group) => new { Key = key, Entities = group }).OrderBy(item => item.Key.FullName))
                    {
                        TreeNode[] childNodes = MakeEntityTreeNodes(provider, connection, group.Entities.OrderBy(e => e.FullName));

                        int countChilds = childNodes.Length;
                        var baseTypeNode = new TreeNodeWithConnectionInfo(
                            string.Format("{0} ({1} item{2})", group.Key.FullName, countChilds, countChilds > 1 ? "s" : string.Empty),
                            connection)
                        {
                            Tag = group.Key
                        };
                        baseTypeNode.ImageKey = !group.Key.IsAbstract ? "BaseType" : "BaseTypeAbstract";
                        baseTypeNode.SelectedImageKey = baseTypeNode.ImageKey;

                        baseTypeNode.Nodes.AddRange(childNodes);
                        parent.Nodes.Add(baseTypeNode);
                    }
                    break;
                case SwqlStudio.EntityGroupingMode.ByHierarchy:
                    GroupByHierarchy(provider, connection, parent);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static void GroupByHierarchy(IMetadataProvider provider, ConnectionInfo connection, TreeNode baseNode)
        {
            Entity baseEntity = baseNode != null ? baseNode.Tag as Entity : null;

            var entities = provider.Tables.Where(e => baseEntity == null ? e.BaseEntity == null : e.BaseEntity == baseEntity);

            if (entities.Any())
            {
                TreeNode[] childNodes = MakeEntityTreeNodes(provider, connection, entities.OrderBy(e => e.FullName));
                
                baseNode.Nodes.AddRange(childNodes);

                if (baseEntity != null)
                {
                    int countChilds = childNodes.Length;
                    baseNode.Text = string.Format("{0} ({1} derived entit{2})", baseNode.Text, countChilds, countChilds > 1 ? "ies" : "y");
                }

                foreach (var node in childNodes)
                {
                    GroupByHierarchy(provider, connection, node);
                }

                if (baseEntity == null)
                {
                    foreach (var node in childNodes)
                    {
                        node.Expand();
                    }
                    baseNode.Expand();
                }
            }
        }

        private static TreeNode[] MakeEntityTreeNodes(IMetadataProvider provider, ConnectionInfo connection, IEnumerable<Entity> entities)
        {
            return entities.Select(e => MakeEntityTreeNode(provider, connection, e)).ToArray();
        }

        private static TreeNodeWithConnectionInfo MakeEntityTreeNode(IMetadataProvider provider, ConnectionInfo connection, Entity table)
        {
            var node = new TreeNodeWithConnectionInfo(table.FullName, connection);
            node.ImageKey = GetImageKey(table);
            node.SelectedImageKey = node.ImageKey;
            node.Tag = table;
            node.ToolTipText = string.Format(
                @"{0}
Base type: {1}
CanCreate: {2}
CanUpdate: {3}
CanDelete: {4}",
                table.FullName, table.BaseType, table.CanCreate, table.CanUpdate, table.CanDelete);

            // Add keys
            AddPropertiesToNode(node, table.Properties.Where(c => c.IsKey));

            // Add the simple Properties
            AddPropertiesToNode(node, table.Properties.Where(c => !c.IsInherited && !c.IsNavigable && !c.IsKey));

            // Add the inherited Properties
            AddPropertiesToNode(node, table.Properties.Where(c => c.IsInherited && !c.IsNavigable && !c.IsKey));

            // Add the Navigation Properties
            AddPropertiesToNode(node, table.Properties.Where(c => c.IsNavigable));

            AddVerbsToNode(node, table, provider);
            return node;
        }

        private static string GetImageKey(Entity table)
        {
            if (table.IsIndication)
                return "Indication";
            else if (table.IsAbstract)
                return "TableAbstract";
            else if (table.CanCreate || table.CanDelete || table.CanUpdate)
                return "TableCrud";

            return "Table";
        }

        private static void AddVerbsToNode(TreeNode parent, Entity table, IMetadataProvider provider)
        {
            foreach (var verb in table.Verbs.OrderBy(v => v.Name))
            {
                TreeNode verbNode = new TreeNode(verb.Name);
                verbNode.SelectedImageKey = "Verb";
                verbNode.ImageKey = verbNode.SelectedImageKey;
                verbNode.Tag = verb;

                parent.Nodes.Add(verbNode);

                verbNode.Nodes.Add(new ObjectExplorer.ArgumentsPlaceholderTreeNode(verb, provider));
            }
        }

        private class ArgumentsPlaceholderTreeNode : TreeNode
        {
            public Verb Verb { get; set; }
            public IMetadataProvider Provider { get; set; }

            public ArgumentsPlaceholderTreeNode(Verb verb, IMetadataProvider provider)
            {
                Verb = verb;
                Provider = provider;
            }
        }

        private static void AddPropertiesToNode(TreeNode parent, IEnumerable<Property> Properties)
        {
            foreach (Property column in Properties.OrderBy(c => c.Name))
            {
                string text = String.Format("{0} ({1})", column.Name, column.Type);
                TreeNode node = new TreeNode(text);
                node.SelectedImageKey = GetColumnIcon(column);
                node.ImageKey = node.SelectedImageKey;
                node.Tag = column;

                parent.Nodes.Add(node);
            }
        }

        private static string GetColumnIcon(Property column)
        {
            if (column.IsNavigable)
                return "Link";
            if (column.IsKey)
                return "KeyColumn";
            if (column.IsInherited)
                return "InheritedColumn";

            return "Column";
        }

        private void StartSubscription(object sender, EventArgs e)
        {
            var table = _contextMenuNode.Tag as Entity;
            if (table != null)
            {
                string query = string.Format(table.IsIndication ? "SUBSCRIBE {0}" : "SUBSCRIBE CHANGES TO {0}", table.FullName);

                ConnectionInfo connection = null;
                if ((_contextMenuNode as TreeNodeWithConnectionInfo) != null)
                    connection = (_contextMenuNode as TreeNodeWithConnectionInfo).Connection;

                ApplicationService.AddTextToEditor(query, connection);
            }
        }
    }
}

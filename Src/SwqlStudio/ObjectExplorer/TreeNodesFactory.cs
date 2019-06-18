using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SwqlStudio.Metadata;

namespace SwqlStudio
{
    internal class TreeNodesFactory
    {
        public static TreeNode CreateDatabaseNode(TreeView treeView, IMetadataProvider provider,
            ConnectionInfo connection)
        {
            TreeNode node = new TreeNodeWithConnectionInfo(provider.Name, connection);
            node.SelectedImageKey = "Database";
            node.ImageKey = "Database";
            node.Tag = provider;
            node.Name = node.Text;

            treeView.Nodes.Add(node);
            treeView.SelectedNode = node;

            return node;
        }

        public static TreeNodeWithConnectionInfo CreateEntityNode(ConnectionInfo connection,
            Entity entity, TreeNode[] childNodes)
        {
            int countChilds = childNodes.Length;
            var countSuffix = countChilds > 1 ? "s" : String.Empty;
            var name = String.Format("{0} ({1} item{2})", entity.FullName, countChilds, countSuffix);
            var entityNode = new TreeNodeWithConnectionInfo(name, connection)
            {
                Tag = entity
            };
            entityNode.ImageKey = !entity.IsAbstract ? "BaseType" : "BaseTypeAbstract";
            entityNode.SelectedImageKey = entityNode.ImageKey;

            entityNode.Nodes.AddRange(childNodes);
            return entityNode;
        }

        public static TreeNode CreateVerbArgumentNode(VerbArgument arg)
        {
            string text = $"{arg.Name} ({arg.Type})";
            var argNode = new TreeNode(text)
            {
                SelectedImageKey = "Argument"
            };
            argNode.ImageKey = argNode.SelectedImageKey;
            argNode.Tag = arg;
            argNode.ToolTipText = ToolTipBuilder.ToToolTip(arg);
            return argNode;
        }

        public static TreeNodeWithConnectionInfo MakeEntityTreeNode(IMetadataProvider provider, ConnectionInfo connection, Entity entity)
        {
            var node = TreeNodesFactory.CreateEntityNode(connection, entity);

            // Add keys
            AddPropertiesToNode(node, entity.Properties.Where(c => c.IsKey));

            // Add the simple Properties
            AddPropertiesToNode(node, entity.Properties.Where(c => !c.IsInherited && !c.IsNavigable && !c.IsKey));

            // Add the inherited Properties
            AddPropertiesToNode(node, entity.Properties.Where(c => c.IsInherited && !c.IsNavigable && !c.IsKey));

            // Add the Navigation Properties
            AddPropertiesToNode(node, entity.Properties.Where(c => c.IsNavigable));

            AddVerbsToNode(node, entity, provider);
            return node;
        }

        private static void AddVerbsToNode(TreeNode parent, Entity table, IMetadataProvider provider)
        {
            foreach (var verb in table.Verbs.OrderBy(v => v.Name))
            {
                TreeNode verbNode = new TreeNode(verb.Name);
                verbNode.SelectedImageKey = "Verb";
                verbNode.ImageKey = verbNode.SelectedImageKey;
                verbNode.Tag = verb;
                verbNode.ToolTipText = ToolTipBuilder.ToToolTip(verb);

                var argumentsPlaceholder = new ArgumentsPlaceholderTreeNode(verb, provider);
                verbNode.Nodes.Add(argumentsPlaceholder);

                parent.Nodes.Add(verbNode);
            }
        }

        private static TreeNodeWithConnectionInfo CreateEntityNode(ConnectionInfo connection, Entity entity)
        {
            var node = new TreeNodeWithConnectionInfo(entity.FullName, connection);
            node.ImageKey = GetImageKey(entity);
            node.SelectedImageKey = node.ImageKey;
            node.Tag = entity;
            node.ToolTipText = ToolTipBuilder.ToToolTip(connection, entity);
            return node;
        }

        private static string GetImageKey(Entity table)
        {
            if (table.IsIndication)
                return "Indication";
        
            if (table.IsAbstract)
                return "TableAbstract";
        
            if (table.CanCreate || table.CanDelete || table.CanUpdate)
                return "TableCrud";

            return "Table";
        }

        private static void AddPropertiesToNode(TreeNode parent, IEnumerable<Property> properties)
        {
            foreach (Property property in properties.OrderBy(c => c.Name))
            {
                string name = $"{property.Name} ({property.Type})";
                TreeNode node = new TreeNode(name);
                node.SelectedImageKey = GetColumnIcon(property);
                node.ImageKey = node.SelectedImageKey;
                node.Tag = property;
                node.ToolTipText = ToolTipBuilder.ToToolTip(property, name);
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

        public static TreeNode CreateNamespaceNode(TreeNode[] childNodes, string namespaceName)
        {
            int countChilds = childNodes.Length;
            
            var countSuffix = countChilds > 1 ? "s" : String.Empty;
            var name = String.Format("{0} ({1} item{2})", namespaceName, countChilds, countSuffix);
            var namespaceNode = new TreeNode(name)
            {
                Tag = namespaceName,
                ImageKey = "Namespace"
            };
            namespaceNode.SelectedImageKey = namespaceNode.ImageKey;

            namespaceNode.Nodes.AddRange(childNodes);
            return namespaceNode;
        }

        public static void RebuildVerbArguments(TreeNode verbNode, IMetadataProvider provider)
        {
            verbNode.Nodes.Clear();
            var verb = verbNode.Tag as Verb;

            foreach (var arg in provider.GetVerbArguments(verb))
            {
                var argNode = TreeNodesFactory.CreateVerbArgumentNode(arg);
                verbNode.Nodes.Add(argNode);
            }
        }

        public static TreeNode[] MakeEntityTreeNodes(IMetadataProvider provider, ConnectionInfo connection, IEnumerable<Entity> entities)
        {
            return entities.Select(e => TreeNodesFactory.MakeEntityTreeNode(provider, connection, e)).ToArray();
        }

        public static void RebuildDatabaseNode(EntityGroupingMode groupingMode, TreeNode databaseNode, IMetadataProvider provider, ConnectionInfo connection)
        {
            databaseNode.Nodes.Clear();

            switch (groupingMode)
            {
                case EntityGroupingMode.Flat:
                    databaseNode.Nodes.AddRange(TreeNodesFactory.MakeEntityTreeNodes(provider, connection, provider.Tables.OrderBy(e => e.FullName)));
                    break;
                case EntityGroupingMode.ByNamespace:
                    foreach (var group in provider.Tables.GroupBy(e => e.Namespace).OrderBy(g => g.Key))
                    {
                        TreeNode[] childNodes = TreeNodesFactory.MakeEntityTreeNodes(provider, connection, group.OrderBy(e => e.FullName));
                        var namespaceNode = TreeNodesFactory.CreateNamespaceNode(childNodes, group.Key);
                        databaseNode.Nodes.Add(namespaceNode);
                    }
                    break;
                case EntityGroupingMode.ByBaseType:
                    foreach (var group in provider.Tables.Where(e => e.BaseEntity != null).GroupBy(
                        e => e.BaseEntity,
                        (key, group) => new { Key = key, Entities = group }).OrderBy(item => item.Key.FullName))
                    {
                        TreeNode[] childNodes = TreeNodesFactory.MakeEntityTreeNodes(provider, connection, group.Entities.OrderBy(e => e.FullName));
                        var entityNode = TreeNodesFactory.CreateEntityNode(connection, group.Key, childNodes);
                        databaseNode.Nodes.Add(entityNode);
                    }
                    break;
                case EntityGroupingMode.ByHierarchy:
                    GroupByHierarchy(provider, connection, databaseNode);
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
                TreeNode[] childNodes = TreeNodesFactory.MakeEntityTreeNodes(provider, connection, entities.OrderBy(e => e.FullName));
                
                baseNode.Nodes.AddRange(childNodes);

                if (baseEntity != null)
                {
                    int countChilds = childNodes.Length;
                    var entitiesSuffix = countChilds > 1 ? "ies" : "y";
                    baseNode.Text = String.Format("{0} ({1} derived entit{2})", baseNode.Text, countChilds, entitiesSuffix);
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
    }
}
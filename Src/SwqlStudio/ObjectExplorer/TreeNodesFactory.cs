using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SwqlStudio.Metadata;

namespace SwqlStudio
{
    internal class TreeNodesFactory
    {
        public static TreeNode CreateDatabaseNode(IMetadataProvider provider, ConnectionInfo connection)
        {
            TreeNode node = new TreeNodeWithConnectionInfo(provider.Name, connection);
            node.SelectedImageKey = "Database";
            node.ImageKey = "Database";
            node.Tag = provider;
            node.Name = node.Text;

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

                parent.Nodes.Add(verbNode);

                verbNode.Nodes.Add(new ArgumentsPlaceholderTreeNode(verb, provider));
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
    }
}
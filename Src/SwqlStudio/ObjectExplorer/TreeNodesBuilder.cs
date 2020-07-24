using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SwqlStudio.Metadata;

namespace SwqlStudio
{
    internal class TreeNodesBuilder
    {
        public EntityGroupingMode EntityGroupingMode { get; set; }

        private readonly Font _defaultFont;
        private Font NodeFont(IObsoleteMetadata entity) => entity.IsObsolete ? new Font(_defaultFont, FontStyle.Strikeout) : null;

        public TreeNodesBuilder(Font defaultFont)
        {
            _defaultFont = defaultFont;
        }

        private TreeNodeWithConnectionInfo MakeEntityTreeNode(IMetadataProvider provider, Entity entity)
        {
            var entityNode = CreateEntityNode(provider, entity);

            // Add keys
            AddPropertiesToNode(provider, entityNode, entity.Properties.Where(c => c.IsKey));

            // Add the simple Properties
            AddPropertiesToNode(provider, entityNode, entity.Properties.Where(c => !c.IsInherited && !c.IsNavigable && !c.IsKey));

            // Add the inherited Properties
            AddPropertiesToNode(provider, entityNode, entity.Properties.Where(c => c.IsInherited && !c.IsNavigable && !c.IsKey));

            // Add the Navigation Properties
            AddPropertiesToNode(provider, entityNode, entity.Properties.Where(c => c.IsNavigable));

            AddVerbsToNode(entityNode, entity, provider);
            return entityNode;
        }

        private void AddVerbsToNode(TreeNode entityNode, Entity entity, IMetadataProvider provider)
        {
            foreach (var verb in entity.Verbs.OrderBy(v => v.Name))
            {
                TreeNode verbNode = CreateNode(provider, verb.Name, ImageKeys.Verb, verb);
                verbNode.ToolTipText = DocumentationBuilder.ToToolTip(verb);

                var argumentsPlaceholder = new ArgumentsPlaceholderTreeNode(verb, provider);
                verbNode.Nodes.Add(argumentsPlaceholder);
                verbNode.NodeFont = NodeFont(verb);

                entityNode.Nodes.Add(verbNode);
            }
        }

        private void AddPropertiesToNode(IMetadataProvider provider, TreeNode entityNode, IEnumerable<Property> properties)
        {
            foreach (Property property in properties.OrderBy(c => c.Name))
            {
                string name = DocumentationBuilder.ToNodeText(property);
                var imageKey = ImageKeys.GetImageKey(property);
                TreeNode node = CreateNode(provider, name, imageKey, property);
                node.ToolTipText = DocumentationBuilder.ToToolTip(property, property);
                node.NodeFont = NodeFont(property);
                entityNode.Nodes.Add(node);
            }
        }

        public static void RebuildVerbArguments(TreeNode verbNode, IMetadataProvider provider)
        {
            verbNode.Nodes.Clear();
            var verb = verbNode.Tag as Verb;

            foreach (var argument in provider.GetVerbArguments(verb))
            {
                var argNode = CreateVerbArgumentNode(provider, argument);
                verbNode.Nodes.Add(argNode);
            }
        }

        private TreeNodeWithConnectionInfo[] MakeEntityTreeNodes(IMetadataProvider provider, IEnumerable<Entity> entities)
        {
            return entities.Select(e => MakeEntityTreeNode(provider, e)).ToArray();
        }

        public void RebuildDatabaseNode(TreeNode databaseNode, IMetadataProvider provider)
        {
            databaseNode.Nodes.Clear();

            switch (this.EntityGroupingMode)
            {
                case EntityGroupingMode.Flat:
                    databaseNode.Nodes.AddRange(MakeEntityTreeNodes(provider, provider.Tables.OrderBy(e => e.FullName)));
                    break;
                case EntityGroupingMode.ByNamespace:
                    foreach (var group in provider.Tables.GroupBy(e => e.Namespace).OrderBy(g => g.Key))
                    {
                        TreeNode[] entityNodes = MakeEntityTreeNodes(provider, group.OrderBy(e => e.FullName));
                        var namespaceNode = CreateNamespaceNode(provider, entityNodes, group.Key);
                        databaseNode.Nodes.Add(namespaceNode);
                    }
                    break;
                case EntityGroupingMode.ByBaseType:
                    foreach (var group in provider.Tables.Where(e => e.BaseEntity != null).GroupBy(
                        e => e.BaseEntity,
                        (key, group) => new { Key = key, Entities = group }).OrderBy(item => item.Key.FullName))
                    {
                        TreeNode[] childNodes = MakeEntityTreeNodes(provider, group.Entities.OrderBy(e => e.FullName));
                        var entityNode = CreateEntityNode(provider, group.Key, childNodes);
                        databaseNode.Nodes.Add(entityNode);
                    }
                    break;
                case EntityGroupingMode.ByHierarchy:
                    GroupByHierarchy(provider, databaseNode);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void GroupByHierarchy(IMetadataProvider provider, TreeNode baseNode)
        {
            Entity baseEntity = baseNode != null ? baseNode.Tag as Entity : null;

            var entities = provider.Tables.Where(e => baseEntity == null ? e.BaseEntity == null : e.BaseEntity == baseEntity);

            if (entities.Any())
            {
                TreeNode[] childNodes = MakeEntityTreeNodes(provider, entities.OrderBy(e => e.FullName));

                baseNode.Nodes.AddRange(childNodes);

                if (baseEntity != null)
                {
                    baseNode.Text = DocumentationBuilder.ToBaseNodeText(baseNode, childNodes.Length);
                }

                foreach (var node in childNodes)
                {
                    GroupByHierarchy(provider, node);
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

        public static TreeNodeWithConnectionInfo CreateDatabaseNode(TreeView treeView, IMetadataProvider provider,
            ConnectionInfo connection)
        {
            TreeNodeWithConnectionInfo node = CreateNode(provider, provider.Name, ImageKeys.Database, provider);
            node.Name = node.Text;
            treeView.Nodes.Add(node);
            treeView.SelectedNode = node;
            return node;
        }

        public static TreeNodeWithConnectionInfo CreateNamespaceNode(IMetadataProvider provider, TreeNode[] entityNodes, string namespaceName)
        {
            var name = DocumentationBuilder.ToNodeText(namespaceName, entityNodes.Length);
            var namespaceNode = CreateNode(provider, name, ImageKeys.Namespace, namespaceName);
            namespaceNode.Nodes.AddRange(entityNodes);
            return namespaceNode;
        }

        private static TreeNodeWithConnectionInfo CreateEntityNode(IMetadataProvider provider, Entity entity, TreeNode[] childNodes)
        {
            var imageKey = !entity.IsAbstract ? ImageKeys.BaseType : ImageKeys.BaseTypeAbstract;
            var name = DocumentationBuilder.ToNodeText(entity.FullName, childNodes.Length);
            var entityNode = CreateNode(provider, name, imageKey, entity);

            entityNode.Nodes.AddRange(childNodes);
            return entityNode;
        }

        private TreeNodeWithConnectionInfo CreateEntityNode(IMetadataProvider provider, Entity entity)
        {
            var imageKey = ImageKeys.GetImageKey(entity);
            var node = CreateNode(provider, entity.FullName, imageKey, entity);
            node.ToolTipText = DocumentationBuilder.ToToolTip(provider.ConnectionInfo, entity);
            node.NodeFont = NodeFont(entity);
            return node;
        }

        private static TreeNodeWithConnectionInfo CreateVerbArgumentNode(IMetadataProvider provider, VerbArgument argument)
        {
            string text = DocumentationBuilder.ToNodeText(argument);
            var argNode = CreateNode(provider, text, ImageKeys.Argument, argument);
            argNode.ToolTipText = DocumentationBuilder.ToToolTip(argument);
            return argNode;
        }

        private static TreeNodeWithConnectionInfo CreateNode(IMetadataProvider provider, string name, string imageKey, object data)
        {
            var node = new TreeNodeWithConnectionInfo(name, provider);
            node.ImageKey = imageKey;
            node.SelectedImageKey = imageKey;
            node.Tag = data;
            return node;
        }
    }
}
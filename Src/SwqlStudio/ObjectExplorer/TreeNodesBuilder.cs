using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SwqlStudio.Metadata;

namespace SwqlStudio
{
    internal class TreeNodesBuilder
    {
        public EntityGroupingMode EntityGroupingMode { get; set; }

        public static TreeNodeWithConnectionInfo MakeEntityTreeNode(IMetadataProvider provider, ConnectionInfo connection, Entity entity)
        {
            var entityNode = CreateEntityNode(connection, entity);

            // Add keys
            AddPropertiesToNode(entityNode, entity.Properties.Where(c => c.IsKey));

            // Add the simple Properties
            AddPropertiesToNode(entityNode, entity.Properties.Where(c => !c.IsInherited && !c.IsNavigable && !c.IsKey));

            // Add the inherited Properties
            AddPropertiesToNode(entityNode, entity.Properties.Where(c => c.IsInherited && !c.IsNavigable && !c.IsKey));

            // Add the Navigation Properties
            AddPropertiesToNode(entityNode, entity.Properties.Where(c => c.IsNavigable));

            AddVerbsToNode(entityNode, entity, provider);
            return entityNode;
        }

        private static void AddVerbsToNode(TreeNode entityNode, Entity entity, IMetadataProvider provider)
        {
            foreach (var verb in entity.Verbs.OrderBy(v => v.Name))
            {
                TreeNode verbNode = CreateNode(verb.Name, ImageKeys.Verb, verb);
                verbNode.ToolTipText = DocumentationBuilder.ToToolTip(verb);

                var argumentsPlaceholder = new ArgumentsPlaceholderTreeNode(verb, provider);
                verbNode.Nodes.Add(argumentsPlaceholder);

                entityNode.Nodes.Add(verbNode);
            }
        }

        private static void AddPropertiesToNode(TreeNode entityNode, IEnumerable<Property> properties)
        {
            foreach (Property property in properties.OrderBy(c => c.Name))
            {
                string name = ToNodeText(property);
                var imageKey = ImageKeys.GetImageKey(property);
                TreeNode node = CreateNode(name, imageKey, property);
                node.ToolTipText = DocumentationBuilder.ToToolTip(property, name);
                entityNode.Nodes.Add(node);
            }
        }

        public static void RebuildVerbArguments(TreeNode verbNode, IMetadataProvider provider)
        {
            verbNode.Nodes.Clear();
            var verb = verbNode.Tag as Verb;

            foreach (var argument in provider.GetVerbArguments(verb))
            {
                var argNode = CreateVerbArgumentNode(argument);
                verbNode.Nodes.Add(argNode);
            }
        }

        private static TreeNodeWithConnectionInfo[] MakeEntityTreeNodes(IMetadataProvider provider, ConnectionInfo connection, IEnumerable<Entity> entities)
        {
            return entities.Select(e => MakeEntityTreeNode(provider, connection, e)).ToArray();
        }

        public void RebuildDatabaseNode(TreeNode databaseNode, IMetadataProvider provider, ConnectionInfo connection)
        {
            databaseNode.Nodes.Clear();

            switch (this.EntityGroupingMode)
            {
                case EntityGroupingMode.Flat:
                    databaseNode.Nodes.AddRange(MakeEntityTreeNodes(provider, connection, provider.Tables.OrderBy(e => e.FullName)));
                    break;
                case EntityGroupingMode.ByNamespace:
                    foreach (var group in provider.Tables.GroupBy(e => e.Namespace).OrderBy(g => g.Key))
                    {
                        TreeNode[] entityNodes = MakeEntityTreeNodes(provider, connection, group.OrderBy(e => e.FullName));
                        var namespaceNode = CreateNamespaceNode(entityNodes, group.Key);
                        databaseNode.Nodes.Add(namespaceNode);
                    }
                    break;
                case EntityGroupingMode.ByBaseType:
                    foreach (var group in provider.Tables.Where(e => e.BaseEntity != null).GroupBy(
                        e => e.BaseEntity,
                        (key, group) => new { Key = key, Entities = group }).OrderBy(item => item.Key.FullName))
                    {
                        TreeNode[] childNodes = MakeEntityTreeNodes(provider, connection, group.Entities.OrderBy(e => e.FullName));
                        var entityNode = CreateEntityNode(connection, group.Key, childNodes);
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
                TreeNode[] childNodes = MakeEntityTreeNodes(provider, connection, entities.OrderBy(e => e.FullName));
                
                baseNode.Nodes.AddRange(childNodes);

                if (baseEntity != null)
                {
                    baseNode.Text = ToBaseNodeText(baseNode, childNodes.Length);
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

        public static TreeNode CreateDatabaseNode(TreeView treeView, IMetadataProvider provider,
            ConnectionInfo connection)
        {
            TreeNode node = CreateNode(connection, provider.Name, ImageKeys.Database, provider);
            node.Name = node.Text;
            treeView.Nodes.Add(node);
            treeView.SelectedNode = node;
            return node;
        }

        public static TreeNode CreateNamespaceNode(TreeNode[] entityNodes, string namespaceName)
        {
            var name = ToNodeText(namespaceName, entityNodes.Length);
            var namespaceNode = CreateNode(name, ImageKeys.Namespace, namespaceName);
            namespaceNode.Nodes.AddRange(entityNodes);
            return namespaceNode;
        }

        private static TreeNodeWithConnectionInfo CreateEntityNode(ConnectionInfo connection,
            Entity entity, TreeNode[] childNodes)
        {
            var imageKey = !entity.IsAbstract ? ImageKeys.BaseType : ImageKeys.BaseTypeAbstract;
            var name = ToNodeText(entity.FullName, childNodes.Length);
            var entityNode = CreateNode(connection, name, imageKey, entity);
            
            entityNode.Nodes.AddRange(childNodes);
            return entityNode;
        }

        private static TreeNodeWithConnectionInfo CreateEntityNode(ConnectionInfo connection, Entity entity)
        {
            var imageKey = ImageKeys.GetImageKey(entity);
            var node = CreateNode(connection, entity.FullName, imageKey, entity);
            node.ToolTipText = DocumentationBuilder.ToToolTip(connection, entity);
            return node;
        }

        private static TreeNode CreateVerbArgumentNode(VerbArgument argument)
        {
            string text = ToNodeText(argument);
            var argNode = CreateNode(text, ImageKeys.Argument, argument);
            argNode.ToolTipText = DocumentationBuilder.ToToolTip(argument);
            return argNode;
        }

        private static TreeNode CreateNode(string name, string imageKey, object data)
        {
            var node = new TreeNode(name);
            AssignProperties(node, imageKey, data);
            return node;
        }

        private static TreeNodeWithConnectionInfo CreateNode(ConnectionInfo connection, string name,
            string imageKey, object data)
        {
            var node = new TreeNodeWithConnectionInfo(name, connection);
            AssignProperties(node, imageKey, data);
            return node;
        }

        private static void AssignProperties(TreeNode node, string imageKey, object data)
        {
            node.ImageKey = imageKey;
            node.SelectedImageKey = imageKey;
            node.Tag = data;
        }

        private static string ToNodeText(string name, int childsCount)
        {
            var countSuffix = childsCount > 1 ? "s" : String.Empty;
            return $"{name} ({childsCount} item{countSuffix})";
        }

        private static string ToNodeText(ITypedMetadata metadata)
        {
            return $"{metadata.Name} ({metadata.Type})";
        }

        private static string ToBaseNodeText(TreeNode baseNode, int childsCount)
        {
            var entitiesSuffix = childsCount > 1 ? "ies" : "y";
            return $"{baseNode.Text} ({childsCount} derived entit{entitiesSuffix})";
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SolarWinds.InformationService.InformationServiceClient;

namespace SwqlStudio
{
    public partial class EntityClassGraphForm : Form
    {
        public EntityClassGraphForm(EntityClassGraph entityClassGraph)
        {
            InitializeComponent();

            LoadTree(entityClassGraph);

            //The user will want to always expand the System.Entity node, so let's do it for them.
            entityClassGraphTreeView.Nodes[0].Expand();
        }

        private void LoadTree(EntityClassGraph entityClassGraph)
        {
            entityClassGraphTreeView.Nodes.Clear();

            if (entityClassGraph.Root == null)
                return;

            Stack<KeyValuePair<EntityMetadata, TreeNode>> baseClasses = new Stack<KeyValuePair<EntityMetadata, TreeNode>>();
            
            //Add the root node.
            TreeNode node = entityClassGraphTreeView.Nodes.Add(entityClassGraph.Root.FullName, entityClassGraph.Root.FullName, 3);
            baseClasses.Push(new KeyValuePair<EntityMetadata, TreeNode>(entityClassGraph.Root, node));

            foreach (EntityMetadata decendent in entityClassGraph.Root.Descendants)
            {
                //Find the base class that we belong to.  Since the enumeration is pre-fix order, then we can find it as 
                //an ancestor of us.
                while (!decendent.BaseClass.Equals(baseClasses.Peek().Key))
                {
                    baseClasses.Pop();
                }

                //Add this child node.
                node = baseClasses.Peek().Value.Nodes.Add(decendent.FullName, decendent.FullName, 3);
                baseClasses.Push(new KeyValuePair<EntityMetadata, TreeNode>(decendent, node));
            }
        }
    }
}

using System;

namespace SwqlStudio.Filtering
{
    [Flags]
    internal enum VisibilityStatus
    {
        /// <summary>
        /// Visibility Status is not set for this node
        /// </summary>
        None = 0,
        /// <summary>
        /// This node is not visible
        /// </summary>
        NotVisible = 1,
        /// <summary>
        /// Some children of this node passed filter
        /// </summary>
        ChildVisible = 2,
        /// <summary>
        /// This node passed filter
        /// </summary>
        Visible = 4,
        /// <summary>
        /// This node's parent passed filter
        /// </summary>
        ParentVisible = 8
    }
}

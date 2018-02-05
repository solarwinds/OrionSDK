using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SwqlStudio.Metadata;

namespace SwqlStudio
{
    public partial class CrudTab : UserControl, IConnectionTab
    {
        public CrudTab()
        {
            InitializeComponent();
        }

        /// <inheritdoc />
        public IApplicationService ApplicationService { get; set; }

        /// <inheritdoc />
        public ConnectionInfo ConnectionInfo { get; set; }

        public Entity Entity { get; set; }
    }
}

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using SwqlStudio.Properties;

namespace SwqlStudio
{
    internal class SearchTextBox : TextBox
    {
        private const int EM_SETMARGINS = 0xd3;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);


        private readonly PictureBox _searchPictureBox;

        public SearchTextBox()
        {
            _searchPictureBox = new PictureBox();
            _searchPictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _searchPictureBox.Size = new Size(16, 16);
            _searchPictureBox.TabIndex = 0;
            _searchPictureBox.TabStop = false;
            _searchPictureBox.Visible = true;
            _searchPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            Controls.Add(_searchPictureBox);

            // Send EM_SETMARGINS to prevent text from disappearing underneath the button
            SendMessage(Handle, EM_SETMARGINS, (IntPtr)2, (IntPtr)(16 << 16));

            SearchImage = Resources.Search;
        }

        [Browsable(true)]
        public Image SearchImage
        {
            set
            {
                _searchPictureBox.Image = value;
                _searchPictureBox.Left = Width - _searchPictureBox.Size.Width - 4;
                _searchPictureBox.Top = Height - _searchPictureBox.Size.Height - 4;
            }

            get => _searchPictureBox.Image;
        }
    }
}
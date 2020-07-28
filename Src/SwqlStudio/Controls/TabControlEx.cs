using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SwqlStudio.Controls
{
    /// <summary>
    /// Tabcontrol with the 'X' button for each tab
    /// </summary>
    internal class TabControlEx : TabControl
    {
        private const int CloseButtonPadding = 15;
        private const string CloseButtonText = "×";
        private readonly Lazy<Size> _closeButtonSize;
        public TabControlEx()
        {
            DrawMode = TabDrawMode.OwnerDrawFixed;
            SizeMode = TabSizeMode.Fixed;

            _closeButtonSize = new Lazy<Size>(() => TextRenderer.MeasureText(CloseButtonText, Font));
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);

            // recompute tab widths
            int maxTabLength = TabPages.Cast<TabPage>()
                .Select(currentPage => TextRenderer.MeasureText(currentPage.Text, Font).Width + Padding.X + Padding.X + CloseButtonPadding)
                .DefaultIfEmpty(0)
                .Max();

            var newItemWidth = Math.Max(maxTabLength, ItemSize.Width);

            var newItemSize = new Size(newItemWidth, ItemSize.Height);

            if (ItemSize != newItemSize)
            {
                ItemSize = newItemSize;
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            var closeButtonSize = _closeButtonSize.Value;

            for (int i = 0; i < TabPages.Count; i++)
            {
                var tabRectangle = GetTabRect(i);
                var tabCloseButton = new Rectangle(tabRectangle.Right - CloseButtonPadding, tabRectangle.Top + Padding.Y, closeButtonSize.Width, closeButtonSize.Height);

                if (tabCloseButton.Contains(e.Location))
                {
                    var page = TabPages[i];
                    TabPages.RemoveAt(i);
                    page.Dispose();
                    break;
                }
            }
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            TextRenderer.DrawText(e.Graphics, CloseButtonText, e.Font, new Point(e.Bounds.Right - CloseButtonPadding, e.Bounds.Top + Padding.Y), Color.Black);
            TextRenderer.DrawText(e.Graphics, TabPages[e.Index].Text, e.Font, new Point(e.Bounds.Location.X + Padding.X, e.Bounds.Top + Padding.Y), Color.Black);

            e.DrawFocusRectangle();
        }
    }
}

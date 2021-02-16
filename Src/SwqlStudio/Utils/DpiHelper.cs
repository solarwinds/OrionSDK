using System.Drawing;
using System.Windows.Forms;

namespace SwqlStudio.Utils
{
    internal static class DpiHelper
    {
        /// <summary>
        /// Sets the currently used system UI font as the default font for the <paramref name="control"/>
        /// </summary>
        /// <param name="control">Usually a <see cref="Form"/></param>
        /// <remarks>This is needed because dimensions of the default font are used to calculate a proper DPI scaling ratio of the <paramref name="control"/>'s child elements.
        /// <para>.Net Framework tries to use "MS Sans Serif" from Windows 3.1, which isn't available anymore. So the system automatically replaces it with "Microsoft Sans Serif",
        /// or sometimes with "Tahoma". But those are also too old. And if there are elements using also other fonts, like "Segoe UI", it messes up the calculation.
        /// So, instead of hard-coding a specific font, let's use whatever the OS prefers to use for its own dialogs.</para>
        /// <para>This has been reportedly fixed in .Net Core and .Net 5.</para></remarks>
        public static void FixFont(Control control)
        {
            control.Font = SystemFonts.MessageBoxFont;
        }

        /// <summary>
        /// Adjusts the default row height in a <see cref="DataGridView"/>
        /// </summary>
        /// <remarks>The default row height is defined as the height of the default font + 9 pixels.
        /// However, because the default font in .Net Framework is "MS Sans Serif 8.25F", it's too small for fonts like "Segoe UI, 9F",
        /// especially when DPI scaling is involved.
        /// <para>This method, when called after <see cref="FixFont"/>, forces the recalculation of the height.</para>
        /// <para>This has been reportedly fixed in .Net Core and .Net 5.</para></remarks>
        public static void FixRowHeight(DataGridView dataGridView)
        {
            // Instead of "dataGridView.DefaultCellStyle.Font.Height" we could just hard-code "SystemFonts.MessageBoxFont". That way, this method would not depend
            // on a previous call to "FixFont". But this is a bit more universal solution.
            dataGridView.RowTemplate.Height = dataGridView.DefaultCellStyle.Font.Height + 9;
        }
    }
}

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
        /// <remarks>This is needed because dimensions of the default font are used to calculate a proper DPI scaling ratio of child elements of the <paramref name="control"/>.
        /// And the .Net Framework uses "Microsoft Sans Serif", 8.25F" from Windows 2.0, regardless of what the OS actually uses. This messes up the calculation.
        /// <para>This has been reportedly fixed in .Net Core and .Net 5.</para></remarks>
        public static void FixFont(Control control)
        {
            control.Font = SystemFonts.MessageBoxFont;
        }

        /// <summary>
        /// Adjusts the default row height in a <see cref="DataGridView"/>
        /// </summary>
        /// <remarks>The default row height is defined as the height of the default font + 9 pixels.
        /// However, because the default font in .Net Framework is "Microsoft Sans Serif", 8.25F", it's too small for fonts like "Segoe UI, 9F",
        /// especially when DPI scaling is involved.
        /// <para>This method, when called after <see cref="FixFont"/>, forces the recalculation of the height.</para>
        /// <para>This has been reportedly fixed in .Net Core and .Net 5.</para></remarks>
        public static void FixRowHeight(DataGridView dataGridView)
        {
            // Instead of "dataGridView.DefaultCellStyle.Font.Height" we could just hardcode "SystemFonts.MessageBoxFont". That way, this method would not depend
            // on a previous call to "FixFont". But this is a bit more universal solution.
            dataGridView.RowTemplate.Height = dataGridView.DefaultCellStyle.Font.Height + 9;
        }
    }
}

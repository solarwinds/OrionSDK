using System.Drawing;
using System.Windows.Forms;

namespace SwqlStudio.Utils
{
    /// <summary>
    /// A helper class for supporting font and DPI scaling
    /// </summary>
    /// <remarks>
    /// <para>This dimensions of the default font are used to calculate a proper DPI scaling ratio of elements. .Net Framework tries to use "MS Sans Serif"
    /// from Windows 3.1, which isn't available anymore. So the system automatically replaces it with "Microsoft Sans Serif", or sometimes with "Tahoma".
    /// But those are too old and don't match with Windows UI fonts. And if there are elements using also other fonts, like "Segoe UI", it messes up the calculation.
    /// That can happen especially when a different font is used for rendering than for the DPI scaling calculation.</para>
    /// <para>This should not be needed anymore in .Net Core 3.1 and .Net 5: https://github.com/dotnet/winforms/pull/656 </para>
    /// </remarks>
    internal static class DpiHelper
    {
        /// <summary>
        /// The default font used in SWQL Studio dialogs
        /// </summary>
        /// <remarks>Returns the default font used by the OS.</remarks>
        /// <value><see cref="SystemFonts.MessageBoxFont"/></value>
        public static readonly Font DefaultFont = SystemFonts.MessageBoxFont;

        /// <summary>
        /// Sets the <see cref="DefaultFont"/> as the default font for the <paramref name="control"/>
        /// </summary>
        /// <param name="control">Usually a <see cref="Form"/></param>
        /// <remarks>This is needed to correctly calculate a proper DPI scaling ratio of the <paramref name="control"/> and its child elements.
        /// It forces the <paramref name="control"/> to sync the fonts used for its rendering and DPI scaling calculation.
        /// <para>This should be called in the <paramref name="control"/>'s constructor.</para></remarks>
        public static void FixFont(Control control)
        {
            control.Font = DefaultFont;
        }

        /// <summary>
        /// Adjusts the default row height in a <see cref="DataGridView"/>
        /// </summary>
        /// <remarks>The default row height is defined as the height of the default font + 9 pixels.
        /// This method, when called after <see cref="FixFont"/>, forces the recalculation of the height.</remarks>
        public static void FixRowHeight(DataGridView dataGridView)
        {
            // Instead of "dataGridView.DefaultCellStyle.Font.Height" we could just hard-code "DefaultFont". That way, this method would not depend
            // on a previous call to "FixFont". But this is a bit more universal solution.
            dataGridView.RowTemplate.Height = dataGridView.DefaultCellStyle.Font.Height + 9;
        }
    }
}

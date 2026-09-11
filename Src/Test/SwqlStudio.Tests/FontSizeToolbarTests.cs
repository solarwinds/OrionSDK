using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using SwqlStudio.ObjectExplorer;
using Xunit;

namespace SwqlStudio.Tests
{
    public class FontSizeToolbarTests
    {
        [Fact]
        public void IncreasingFontSizeDoesNotDisposeInitialFont()
        {
            using (var initialFont = new Font("Microsoft Sans Serif", 8.25f))
            using (var target = new Label { Font = initialFont })
            using (var toolbar = CreateToolbar(target))
            {
                ClickButton(toolbar, "Increase font");

                Assert.NotSame(initialFont, target.Font);
                AssertFontIsUsable(initialFont);
            }
        }

        [Fact]
        public void ChangingFontSizeDisposesPreviouslyOwnedFont()
        {
            using (var initialFont = new Font("Microsoft Sans Serif", 8.25f))
            using (var target = new Label { Font = initialFont })
            using (var toolbar = CreateToolbar(target))
            {
                ClickButton(toolbar, "Increase font");
                Font firstOwnedFont = target.Font;

                ClickButton(toolbar, "Increase font");

                AssertFontIsDisposed(firstOwnedFont);
                AssertFontIsUsable(target.Font);
            }
        }

        [Fact]
        public void ResettingFontSizeDisposesOwnedFontAndPreservesInitialFont()
        {
            using (var initialFont = new Font("Microsoft Sans Serif", 8.25f))
            using (var target = new Label { Font = initialFont })
            using (var toolbar = CreateToolbar(target))
            {
                ClickButton(toolbar, "Increase font");
                Font increasedFont = target.Font;

                ClickButton(toolbar, "Reset font");

                Assert.Equal(initialFont.Size, target.Font.Size);
                Assert.NotSame(initialFont, target.Font);
                AssertFontIsDisposed(increasedFont);
                AssertFontIsUsable(initialFont);
                AssertFontIsUsable(target.Font);
            }
        }

        [Fact]
        public void ChangingTargetRestoresPreviousTargetsInitialFont()
        {
            using (var firstInitialFont = new Font("Microsoft Sans Serif", 8.25f))
            using (var secondInitialFont = new Font("Microsoft Sans Serif", 9f))
            using (var firstTarget = new Label { Font = firstInitialFont })
            using (var secondTarget = new Label { Font = secondInitialFont })
            using (var toolbar = CreateToolbar(firstTarget))
            {
                ClickButton(toolbar, "Increase font");
                Font firstOwnedFont = firstTarget.Font;

                toolbar.Target = secondTarget;

                Assert.Same(firstInitialFont, firstTarget.Font);
                AssertFontIsUsable(firstTarget.Font);
                AssertFontIsDisposed(firstOwnedFont);
            }
        }

        [Fact]
        public void DisposingToolbarRestoresTargetsInitialFont()
        {
            using (var initialFont = new Font("Microsoft Sans Serif", 8.25f))
            using (var target = new Label { Font = initialFont })
            {
                var toolbar = CreateToolbar(target);
                ClickButton(toolbar, "Increase font");
                Font ownedFont = target.Font;

                toolbar.Dispose();

                Assert.Same(initialFont, target.Font);
                AssertFontIsUsable(target.Font);
                AssertFontIsDisposed(ownedFont);
            }
        }

        private static FontSizeToolbar CreateToolbar(Control target) =>
            new FontSizeToolbar(1f) { Target = target };

        private static void ClickButton(FontSizeToolbar toolbar, string tooltip)
        {
            ToolStrip strip = toolbar.Controls.OfType<ToolStrip>().Single();
            ToolStripButton button = strip.Items
                .OfType<ToolStripButton>()
                .Single(item => item.ToolTipText == tooltip);

            button.PerformClick();
        }

        private static void AssertFontIsUsable(Font font)
        {
            IntPtr handle = font.ToHfont();
            Assert.NotEqual(IntPtr.Zero, handle);
            DeleteObject(handle);
        }

        private static void AssertFontIsDisposed(Font font) =>
            Assert.Throws<ArgumentException>(() => font.ToHfont());

        [DllImport("gdi32.dll")]
        private static extern bool DeleteObject(IntPtr handle);
    }
}
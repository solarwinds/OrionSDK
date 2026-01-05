using System;
using System.Drawing;
using System.Windows.Forms;

namespace SwqlStudio.ObjectExplorer
{
    /// <summary>
    /// Provides a toolbar control for adjusting the font size of a target <see cref="Control"/> at runtime.
    /// </summary>
    /// <remarks>The <c>FontSizeToolbar</c> enables users to increase, decrease, or reset the font size of a
    /// specified control using dedicated toolbar buttons. The font size can be adjusted within a predefined range, and
    /// the reset button restores the font to its original size. This control is intended for use in scenarios where
    /// dynamic font scaling is required, such as accessibility or user preference settings.</remarks>
    internal sealed class FontSizeToolbar : UserControl
    {
        private Control _target;
        private  float _defaultFontSize;
        private float _currentFontSize;       

        private readonly ToolStripButton _btnReset;
        private readonly ToolStripButton _btnDecrease;
        private readonly ToolStripButton _btnIncrease;

        public FontSizeToolbar()
        {
            Height = 26;
            Width = 81;

            var strip = new ToolStrip
            {
                Dock = DockStyle.Fill,
                GripStyle = ToolStripGripStyle.Hidden,
                RenderMode = ToolStripRenderMode.System,
                Padding = new Padding(10, 0, 0, 0)
            };

            _btnReset = CreateButton(Properties.Resources.Refresh_16x, "Reset font");
            _btnReset.Enabled = false;
            _btnDecrease = CreateButton(Properties.Resources.FontDecrease_16x, "Decrease font");
            _btnIncrease = CreateButton(Properties.Resources.FontIncrease_16x, "Increase font");

            _btnDecrease.Click += (_, __) => ChangeFont(-1);
            _btnIncrease.Click += (_, __) => ChangeFont(+1);
            _btnReset.Click += (_, __) => ResetFontSize();

            strip.Items.Add(_btnReset);
            strip.Items.Add(_btnDecrease);
            strip.Items.Add(_btnIncrease);

            Controls.Add(strip);
        }

        private const float MinFontSize = 7f;
        private const float MaxFontSize = 20f;
        private const float Step = 1f;

        public Control Target
        {
            get => _target;
            set
            {
                _target = value;
                if (_target != null)
                {
                    _defaultFontSize = _target.Font.Size;
                    _currentFontSize = _defaultFontSize;
                }
            }
        }
        private void ChangeFont(int delta)
        {
            if (Target == null)
                return;

            float newSize = Clamp(
                _currentFontSize + delta * Step,
                MinFontSize,
                MaxFontSize);

            if (Math.Abs(newSize - _currentFontSize) < 0.01f)
                return;

            _currentFontSize = newSize;
            
            var oldFont = Target.Font;
            Target.Font = new Font(oldFont.FontFamily, _currentFontSize, oldFont.Style);

            UpdateResetButton();
        }

        private void ResetFontSize()
        {
            if (Target == null)
                return;

            _currentFontSize = _defaultFontSize;

            var oldFont = Target.Font;
            Target.Font = new Font(oldFont.FontFamily, _defaultFontSize, oldFont.Style);

            UpdateResetButton();
        }

        private void UpdateResetButton()
        {
            bool isDirty = Math.Abs(_currentFontSize - _defaultFontSize) > 0.01f;

            _btnReset.Enabled = isDirty;           
        }

        private static float Clamp(float value, float min, float max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

        private static ToolStripButton CreateButton(Image image, string tooltip) =>
            new ToolStripButton
            {
                DisplayStyle = ToolStripItemDisplayStyle.Image,
                Image = image,
                ImageTransparentColor = Color.Magenta,
                ToolTipText = tooltip,
                AutoSize = false,
                Width = 23
            };
    }
}

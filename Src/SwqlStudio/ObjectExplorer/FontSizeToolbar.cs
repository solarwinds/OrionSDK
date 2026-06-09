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
        private readonly ToolStripButton _btnReset;
        private readonly ToolStripButton _btnDecrease;
        private readonly ToolStripButton _btnIncrease;

        private float? _initialFontSize;
        private float _minFontSize;
        private float _maxFontSize;

        private readonly float _step;

        public FontSizeToolbar(float scaleFactor)
        {
            AutoScaleMode = AutoScaleMode.Dpi;

            _step = scaleFactor;
            _minFontSize = 7f;
            _maxFontSize = 20f * scaleFactor;

            ToolStrip strip = new ToolStrip
            {
                GripStyle = ToolStripGripStyle.Hidden,
                RenderMode = ToolStripRenderMode.System,
                LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow,
                AutoSize = true,
                Padding = Padding.Empty,
                CanOverflow = false
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

            strip.Dock = DockStyle.Fill;
            Controls.Add(strip);

            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }

        public Control Target
        {
            get => _target; set => _target = value;
        }

        private void ChangeFont(int delta)
        {
            if (Target == null)
                return;

            SaveInitialFontSize();

            float newSize = Clamp(
                _target.Font.Size + delta * _step,
                _minFontSize,
                _maxFontSize);

            if (Math.Abs(newSize - _target.Font.Size) < 0.01f)
                return;

            var oldFont = Target.Font;
            Target.Font = new Font(oldFont.FontFamily, newSize, oldFont.Style, oldFont.Unit);
            oldFont.Dispose();

            UpdateResetButton();

            void SaveInitialFontSize()
            {
                if (_initialFontSize.HasValue)
                    return;
                _initialFontSize = Target.Font.Size;
            }
        }

        private void ResetFontSize()
        {
            if (Target == null || !_initialFontSize.HasValue)
                return;

            var oldFont = Target.Font;
            Target.Font = new Font(oldFont.FontFamily, _initialFontSize.Value, oldFont.Style, oldFont.Unit);
            oldFont.Dispose();

            UpdateResetButton();
        }

        private void UpdateResetButton()
        {
            bool isDirty = _initialFontSize.HasValue && Math.Abs( Target.Font.Size - _initialFontSize.Value) > _step*0.01f;

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
                AutoSize = true
            };
    }
}

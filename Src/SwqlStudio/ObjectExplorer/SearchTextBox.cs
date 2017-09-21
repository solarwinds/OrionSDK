using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using SwqlStudio.Properties;
using SwqlStudio.Utils;

namespace SwqlStudio
{
    internal class SearchTextBox : TextBox
    {
        private readonly PictureBox _searchPictureBox;
        private string _cueText = string.Empty;
        private TimeSpan _debounceLimit = TimeSpan.Zero;
        private readonly Timer _timer;
        /// <summary>
        /// Raised after DebounceLimit after user stopped typing.
        /// Useful, if the event associated with text change (search) is expensive - we just wait till user stops writing.
        /// </summary>
        public event EventHandler TextChangedWithDebounce;

        public SearchTextBox()
        {
            _searchPictureBox = new PictureBox();
            _searchPictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _searchPictureBox.Size = new Size(16, 16);
            _searchPictureBox.TabIndex = 0;
            _searchPictureBox.TabStop = false;
            _searchPictureBox.Visible = true;
            _searchPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

            _timer = new Timer();
            _timer.Enabled = false;
            _timer.Tick += OnTimerTicked;

            Controls.Add(_searchPictureBox);

            // Send EM_SETMARGINS to prevent text from disappearing underneath the button
            Win32.SendMessage(Handle, Win32.EM_SETMARGINS, (IntPtr)2, (IntPtr)(16 << 16));

            SearchImage = Resources.Search;
        }

        private void OnTimerTicked(object sender, EventArgs e)
        {
            var timer = (Timer) sender;
            timer.Stop();

            OnTextChangedWithDebounce(e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            if (_debounceLimit == TimeSpan.Zero)
            {
                OnTextChangedWithDebounce(e);
            }
            else
            {
                _timer.Stop(); // restart the timer
                _timer.Start();
            }

            base.OnTextChanged(e);
        }

        [Browsable(true)]
        public string CueText
        {
            set
            {
                _cueText = value ?? string.Empty;
                this.SetCueText(_cueText);
            }
            get => _cueText;
        }

        [Browsable(true)]
        public TimeSpan DebounceLimit
        {
            set
            {
                if (value < TimeSpan.Zero)
                    throw new ArgumentException("DebounceLimit must be greater than or equal to zero", nameof(value));

                _debounceLimit = value;
                _timer.Interval = (int)_debounceLimit.TotalMilliseconds;
            }
            get => _debounceLimit;
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

        protected virtual void OnTextChangedWithDebounce(EventArgs e)
        {
            TextChangedWithDebounce?.Invoke(this, e);
        }
    }
}
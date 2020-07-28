using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using SwqlStudio.Utils;

namespace SwqlStudio
{
    internal class SearchTextBox : TextBox
    {
        private readonly Label _searchPicture;
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
            _searchPicture = new Label();
            _searchPicture.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _searchPicture.Size = new Size(16, 16);
            _searchPicture.TabIndex = 0;
            _searchPicture.TabStop = false;
            _searchPicture.Visible = true;

            _timer = new Timer();
            _timer.Enabled = false;
            _timer.Tick += OnTimerTicked;

            Controls.Add(_searchPicture);

            // Send EM_SETMARGINS to prevent text from disappearing underneath the button
            Win32.SendMessage(Handle, Win32.EM_SETMARGINS, (IntPtr)2, (IntPtr)(16 << 16));
            UserTypingTimerStop();
        }

        private void UserTypingTimerRestart()
        {
            SearchImageText = "…";

            _timer.Stop(); // restart the timer
            _timer.Start();
        }

        private void UserTypingTimerStop()
        {
            _timer.Stop();
            SearchImageText = "🔍";
        }

        private string SearchImageText
        {
            set
            {
                _searchPicture.Text = value;
                var textSize = TextRenderer.MeasureText(value, _searchPicture.Font);
                _searchPicture.Left = Width - textSize.Width - 4;
                _searchPicture.Top = Height - textSize.Height - 6;
            }
        }


        private void OnTimerTicked(object sender, EventArgs e)
        {
            UserTypingTimerStop();

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
                UserTypingTimerRestart();
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

        protected virtual void OnTextChangedWithDebounce(EventArgs e)
        {
            TextChangedWithDebounce?.Invoke(this, e);
        }
    }
}
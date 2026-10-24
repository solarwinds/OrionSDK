using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SwqlStudio.Utils
{
    internal static class Win32
    {
        public const int SB_HORZ = 0x0;
        public const int EM_SETMARGINS = 0xd3;
        public const int EM_SETCUEBANNER = 0x1501;

        [StructLayout(LayoutKind.Sequential)]
        private struct FLASHWINFO
        {
            public uint cbSize;
            public IntPtr hwnd;
            public uint dwFlags;
            public uint uCount;
            public uint dwTimeout;
        }

        private const uint FLASHW_ALL = 3;           // flash caption + taskbar
        private const uint FLASHW_TIMERNOFG = 12;    // keep flashing until the window comes to the foreground

        [DllImport("user32.dll")]
        private static extern bool FlashWindowEx(ref FLASHWINFO pwfi);

        /// <summary>
        /// Flashes the form's taskbar button until the window is brought to the foreground.
        /// Useful when the user is in an external browser and needs to be drawn back to the app.
        /// </summary>
        public static void FlashUntilForeground(Form form)
        {
            if (form == null || form.IsDisposed) return;

            var info = new FLASHWINFO
            {
                cbSize   = (uint)Marshal.SizeOf(typeof(FLASHWINFO)),
                hwnd     = form.Handle,
                dwFlags  = FLASHW_ALL | FLASHW_TIMERNOFG,
                uCount   = 0,
                dwTimeout = 0
            };
            FlashWindowEx(ref info);
        }

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern int SetScrollPos(IntPtr hWnd, int nBar, int nPos, bool bRedraw);

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wp, [MarshalAs(UnmanagedType.LPWStr)] string lp);



        public static void SetHorizontalScroll(this Control control, int scroll)
        {
            SetScrollPos(control.Handle, SB_HORZ, scroll, false);
        }

        public static void SetCueText(this TextBox textbox, string text)
        {
            SendMessage(textbox.Handle, EM_SETCUEBANNER, 0, text);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace SwqlStudio.Utils
{
    internal static class Win32
    {
        public const int SB_HORZ = 0x0;
        public const int EM_SETMARGINS = 0xd3;
        public const int EM_SETCUEBANNER = 0x1501;

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

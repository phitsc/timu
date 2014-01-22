namespace TextManipulationUtility
{
    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    class NativeMethods
    {
        // cue banner
        private const UInt32 EM_SETCUEBANNER = 0x1501;
        private const UInt32 EM_GETCUEBANNER = 0x1502;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, UInt32 msg, IntPtr wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        public static void SetCueText(Control control, string text)
        {
            SendMessage(control.Handle, EM_SETCUEBANNER, IntPtr.Zero, text);
        }
    }
}

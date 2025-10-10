using System.Runtime.InteropServices;

namespace Common
{
    public class ConsoleUtil
    {
        // Define constants and structures for P/Invoke
        private const int STD_OUTPUT_HANDLE = -11;
        private const int TMPF_TRUETYPE = 4; // TrueType font

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        internal struct CONSOLE_FONT_INFOEX
        {
            internal uint cbSize;
            internal uint nFont;
            internal COORD dwFontSize;
            internal int FontFamily;
            internal int FontWeight;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            internal string FaceName;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct COORD
        {
            internal short X;
            internal short Y;
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern IntPtr GetStdHandle(int nStdHandle);

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool SetCurrentConsoleFontEx(
            IntPtr hConsoleOutput,
            bool bMaximumWindow,
            ref CONSOLE_FONT_INFOEX lpConsoleCurrentFontEx
        );

        public static void SetConsoleFontSize(int fontSize)
        {
            IntPtr hConsole = GetStdHandle(STD_OUTPUT_HANDLE);

            CONSOLE_FONT_INFOEX cfi = new();
            cfi.cbSize = (uint)Marshal.SizeOf(cfi);
            cfi.nFont = 0; // Index of the font
            cfi.dwFontSize.X = 0; // Width (0 for auto-sizing)
            cfi.dwFontSize.Y = (short)fontSize; // Height (font size)
            cfi.FontFamily = TMPF_TRUETYPE; // Use TrueType fonts
            cfi.FontWeight = 400; // Normal weight
            cfi.FaceName = "Lucida Console"; // Specify font name

            // Attempt to set the console font
            if (!SetCurrentConsoleFontEx(hConsole, false, ref cfi))
            {
                Console.WriteLine("Failed to set console font size. Error: " + Marshal.GetLastWin32Error());
            }
        }
    }
}

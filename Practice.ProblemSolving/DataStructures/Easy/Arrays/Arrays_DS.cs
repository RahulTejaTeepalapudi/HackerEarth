using System.Runtime.InteropServices;

namespace Practice.ProblemSolving.DataStructures.Easy.Arrays;

public partial class Result
{

    /*
     * Complete the 'reverseArray' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts INTEGER_ARRAY a as parameter.
     */

    public static List<int> ReverseArray(List<int> a)
    {
        a.Reverse();
        return a;
    }
}

public class Arrays_DS
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



    public static void Main()
    {
        SetConsoleFontSize(24);
        
        string input = @"4 
        1 4 3 2";

        string[] lines = [.. input
            .Split(["\r\n", "\n", "\r"], StringSplitOptions.None) 
            .Select(line => line.Trim())                                
            .Where(line => !string.IsNullOrWhiteSpace(line))];

        int n = int.Parse(lines[0]);
        var list = lines[1].Split(' ').Select(n => int.Parse(n)).ToList();

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"Input: {string.Join(" ", list)}");

        var result = Result.ReverseArray(list);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Output: {string.Join(" ", result)}");

        Console.ReadKey();
    }
}

using System.Runtime.InteropServices;

namespace Practice.ProblemSolving.DataStructures.Easy.Arrays;

public partial class Result
{

    /*
     * Complete the 'hourglassSum' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts 2D_INTEGER_ARRAY arr as parameter.
     */

    public static int HourglassSum(List<List<int>> matrix)
    {
        int rows = matrix.Count; // 6 rows
        int columns = matrix[0].Count; // 6 columns for each row

        var sums = new List<int>();

        for (int row = 0; row <= rows - 3; row++)
        {
            for (int col = 0; col <= columns - 3; col++)
            {
                // 3x3 sub matrix
                // hourglass:
                // a b c
                //   d
                // e f g
                int sum = matrix[row][col] + matrix[row][col + 1] + matrix[row][col + 2] +
                    matrix[row + 1][col + 1] +
                    matrix[row + 2][col] + matrix[row + 2][col + 1] + matrix[row + 2][col + 2];

                sums.Add(sum);
            }
        }

        return sums.Max();
    }

}

public class _2D_Array_DS
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

        string input = @"1 1 1 0 0 0 
        0 1 0 0 0 0
        1 1 1 0 0 0
        0 0 2 4 4 0
        0 0 0 2 0 0
        0 0 1 2 4 0";

        string[] lines = [.. input
            .Split(["\r\n", "\n", "\r"], StringSplitOptions.None)
            .Select(line => line.Trim())
            .Where(line => !string.IsNullOrWhiteSpace(line))];

        List<List<int>> matrix = [];

        for (int i = 0; i < 6; i++)
        {
            matrix.Add(lines[i].TrimEnd().Split(' ').Select(n => Convert.ToInt32(n)).ToList());
        }

        int result = Result.HourglassSum(matrix);

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"Input => 6X6 2D array");
        Console.WriteLine(string.Join(Environment.NewLine, matrix.Select(row => string.Join(" ", row))));

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Output => Maximum hourglass sum: {result}");

        Console.ReadKey();
    }
}

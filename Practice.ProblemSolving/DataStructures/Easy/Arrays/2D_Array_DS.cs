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
    public static void Main()
    {
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

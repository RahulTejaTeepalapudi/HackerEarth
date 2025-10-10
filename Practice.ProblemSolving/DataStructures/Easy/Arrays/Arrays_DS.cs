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
    public static void Main()
    {
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

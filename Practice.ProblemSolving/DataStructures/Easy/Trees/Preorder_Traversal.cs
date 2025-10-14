namespace Practice.ProblemSolving.DataStructures.Easy.Trees;

public class Preorder_Traversal
{
    public static void Main()
    {
#pragma warning disable CS0219 // Variable is assigned but its value is never used
        string input1 = @"6 
        1 2 5 3 6 4";
#pragma warning restore CS0219 // Variable is assigned but its value is never used

        string input2 = @"15
        1 14 3 7 4 5 15 6 13 10 11 2 12 8 9";

        string[] lines = [.. input2
            .Split(["\r\n", "\n", "\r"], StringSplitOptions.None)
            .Select(line => line.Trim())];

        int n = Convert.ToInt32(lines[0]);

        List<int> arr = [.. lines[1].TrimEnd().Split(' ').Select(n => Convert.ToInt32(n))];

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"Input: {string.Join(" ", arr)}");

        var tree = new BinarySearchTree();

        foreach (var a in arr)
        {
            tree.Insert(a);
        }

        var result = tree.PreOrder();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Output: {string.Join(" ", result)}");

        Console.ReadKey();
    }
}

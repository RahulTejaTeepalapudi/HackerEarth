namespace Practice.ProblemSolving.DataStructures.Easy.Arrays;

public partial class Result
{

    /*
     * Complete the 'dynamicArray' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. 2D_INTEGER_ARRAY queries
     */

    public static List<int> DynamicArray(int n, List<List<int>> queries)
    {
        var result = new List<int>();

        var arr = new List<List<int>>();
        for (int i = 0; i < n; i++)
        {
            arr.Add([]);
        }

        int lastAnswer = 0;

        foreach (var query in queries)
        {
            int queryType = query[0];
            int x = query[1];
            int y = query[2];

            int idx = (x ^ lastAnswer) % n;

            if (queryType == 1)
            {
                arr[idx].Add(y);
            }
            else
            {
                int size = arr[idx].Count;
                lastAnswer = arr[idx][y % size];
                result.Add(lastAnswer);
            }
        }

        return result;
    }
}

/*
 
Declare a 2-dimensional array, arr, with n empty arrays, all zero-indexed.
Declare an integer, lastAnswer, and initialize it to 0.
You need to process two types of queries:
1 Query: 1 x y
    1. Compute idx = (x ^ lastAnswer) % n
    2. Append the integer y to arr[idx].
2 Query: 2 x y
    1. Compute idx = (x ^ lastAnswer) % n
    2. Assign the value arr[idx][y % size] to lastAnswer, where size is the size of arr[idx].
    3. Print the new value of lastAnswer on a new line.
 
Input Format

The first line contains two space-separated integers, n , the size of  to create, and q, the number of queries, respectively.
Each of the q subsequent lines contains a query string, queries[i].
 
 */

public class Dynamic_Array  
{
    public static void Main()
    {
        string input = @"2 5 
        1 0 5
        1 1 7
        1 0 3
        2 1 0
        2 1 1";

        string[] lines = [.. input
            .Split(["\r\n", "\n", "\r"], StringSplitOptions.None)
            .Select(line => line.Trim())];

        int n = Convert.ToInt32(lines[0].Split(' ')[0]);

        int q = Convert.ToInt32(lines[0].Split(' ')[1]);

        List<List<int>> queries = [];

        for (int i = 1; i <= q; i++)
        {
            queries.Add([.. lines[i].TrimEnd().Split(' ').Select(n => Convert.ToInt32(n))]);
        }

        List<int> result = Result.DynamicArray(n, queries);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Output:");
        result.ForEach(r => Console.WriteLine(r));

        Console.ReadKey();
    }
}

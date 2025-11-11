using Common;

namespace Practice.ProblemSolving.DataStructures.Easy.Arrays;
public partial class Result
{

    /*
     * Complete the 'rotateLeft' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER d
     *  2. INTEGER_ARRAY arr
     */
    private static void Reverse(List<int> arr, int l, int r)
    {
        while (l < r)
        {
            (arr[l], arr[r]) = (arr[r], arr[l]);
            l++;
            r--;
        }
    }


    public static List<int> RotateLeft(int d, List<int> arr)
    {
        int n = arr.Count;
        d %= n;
        Reverse(arr, 0, d - 1);
        Reverse(arr, d, n - 1);
        Reverse(arr, 0, n - 1);
        return arr;
    }

    //public static List<int> RotateLeft(int d, List<int> arr)
    //{
    //    var n = arr.Count;
    //    d %= n;
    //    List<int> rotated = [];
    //    for (int i = 0; i < n; i++)
    //    {
    //        rotated.Add(arr[(i + d) % n]);
    //    }
    //    return rotated;
    //}

    //public static List<int> RotateLeft(int d, List<int> arr)
    //{
    //    var n = arr.Count;
    //    d %= n;
    //    if (d == 0)
    //    {
    //        return arr;
    //    }
    //    var result = new List<int>();
    //    for (int i = 0; i < n; i++)
    //    {
    //        if (i + d < n)
    //        {
    //            result.Add(arr[i + d]);
    //        }
    //        else
    //        {
    //            result.Add(arr[(i + d) - n]);
    //        }
    //    }
    //    return result;
    //}

    //public static List<int> RotateLeft(int d, List<int> arr)
    //{
    //    int n = arr.Count;
    //    // Handle case when d > n
    //    d %= n;

    //    // Storing rotated version of array
    //    int[] temp = new int[n];

    //    // Copy last n - d elements to the front of temp
    //    for (int i = 0; i < n - d; i++)
    //        temp[i] = arr[d + i];

    //    // Copy the first d elements to the back of temp
    //    for (int i = 0; i < d; i++)
    //        temp[n - d + i] = arr[i];

    //    // Copying the elements of temp in arr
    //    // to get the final rotated array
    //    for (int i = 0; i < n; i++)
    //        arr[i] = temp[i];

    //    return arr;
    //}

}

/*
 
    An operation on a circular array shifts each of the array's elements  unit to the left. 
    The elements that fall off the left end reappear at the right end. 
    Given an integer , rotate the array that many steps to the left and return the result.

 */


public class Left_Rotation
{
    public static void Main()
    {
        string input = @"5 4 
        1 2 3 4 5";

        string[] lines = [.. input
            .Split(["\r\n", "\n", "\r"], StringSplitOptions.None)
            .Select(line => line.Trim())];

        int n = Convert.ToInt32(lines[0].Split(' ')[0]);

        int d = Convert.ToInt32(lines[0].Split(' ')[1]);

        List<int> arr = [.. lines[1].TrimEnd().Split(' ').Select(n => Convert.ToInt32(n))];

        ConsoleUtil.SetForegroundColor(ConsoleColor.Magenta);

        // Log input
        Console.WriteLine($"Input: {string.Join(" ", arr)}");

        List<int> result = Result.RotateLeft(d, arr);

        ConsoleUtil.SetForegroundColor(ConsoleColor.Green);
        Console.WriteLine($"Output: {string.Join(" ", result)}");

        Console.ReadKey();
    }
}

using System.Runtime.Serialization.Formatters;

public static class DisplaySums {
    public static void Run() {
        DisplaySumPairs([1, 2, 3, 4, 5, 6, 7, 8, 9, 10]);
        // Should show something like (order does not matter):
        // 6 4
        // 7 3
        // 8 2
        // 9 1 

        Console.WriteLine("------------");
        DisplaySumPairs([-20, -15, -10, -5, 0, 5, 10, 15, 20]);
        // Should show something like (order does not matter):
        // 10 0
        // 15 -5
        // 20 -10

        Console.WriteLine("------------");
        DisplaySumPairs([5, 11, 2, -4, 6, 8, -1]);
        // Should show something like (order does not matter):
        // 8 2
        // -1 11
    }

    /// <summary>
    /// Display pairs of numbers (no duplicates should be displayed) that sum to
    /// 10 using a set in O(n) time.  We are assuming that there are no duplicates
    /// in the list.
    /// </summary>
    /// <param name="numbers">array of integers</param>
    private static void DisplaySumPairs(int[] numbers)
    {
        var found = new HashSet<int>();
        var pairs = new HashSet<(int, int)>();

        // TODO Problem 2 - This should print pairs of numbers in the given array
        // it doesn't work as expected.

        foreach (var num in numbers)
        {
            int result = 0;
            // check 
            result = 10 - num;
            // need to check if result is in numbers, put the numbers in the set, then check to see if the numbers are in teh set  CAll conatins on the set
            //check to see if num in a pair
            if (found.Add(num) && found.Add(result))
            {
                // add result to a set
                pairs.Add((num, result));
                Console.WriteLine(num + ", " + result);
            }

        }
        //  Console.WriteLine("Pair: " + String.Join(", ", pairs)); 
        
    }
}
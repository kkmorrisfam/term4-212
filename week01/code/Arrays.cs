using System.Diagnostics;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // create empty array
        // Use for loop to find number *1, number * 2....number * n
        // start loop at 1, go to length, multiply by i, incriment i
        // add each product to array within loop
        double[] products = new double[length];  // declare empty array of doubles of size length; goes from 0 to length-1
        for (int i = 0; i < length; i++)
        {
            products[i] = (i + 1) * number;  //assign value starting at index 0 in array, for value multiply number starting with 1.
        }

        return products; // return array of products
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Method does not return a value, so I need to change the values in data

        Debug.WriteLine("amount: " + amount);

        // create 2 empty lists to hold ranges, could also use arrays
        List<int> firstHalf = new List<int>();
        List<int> secondHalf = new List<int>();

        //get size of list data
        int listSize = data.Count();

        Debug.WriteLine("List Size: " + listSize);
        //if listSize == amount, then there's nothing to do, list will be the same
        //if not, complete the logic to rotate the list
        if (amount < listSize)
        {
            // get the position where the list index will move from 0 to ?
            // find this by taking the list size less the amount of the shift
            int midIndex = listSize - amount;   
            Debug.WriteLine("midIndex: " + midIndex);

            //get first half of range and add to new list
            //get the range from 0 and gather items (count) to shift (listSize - amount)
            //data.GetRange(index, count) -> add to firstHalf list
            firstHalf.AddRange(data.GetRange(0, midIndex));

            Debug.WriteLine("first half: ");
            foreach (int item in firstHalf)
            {
                Debug.WriteLine($"{item}, ");
            }

            // get the range from the middle to the end
            //data.GetRange(index, count) -> secondHalf list
            secondHalf.AddRange(data.GetRange(midIndex, amount));

            Debug.WriteLine("Second half: ");
            foreach (int item in secondHalf)
            {
                Debug.WriteLine($"{item}, ");

            }
            // clear all data in the list that was passed in
            data.Clear();
            //add the second half list to the original data list first
            data.AddRange(secondHalf);
            //append the first half list to the original data list
            data.AddRange(firstHalf);

            // check to see results
            Debug.WriteLine("\nend data: ");
            foreach (int item in data)
            {
                Debug.Write($"{item}, ");
            }

        }
    }
}

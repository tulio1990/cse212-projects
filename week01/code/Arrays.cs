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
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Step 1: Create a new array of doubles with the size of 'length' to store the multiples.
        // Step 2: Loop through each index 'i' from 0 up to 'length - 1'.
        // Step 3: For each index 'i', calculate the multiple by multiplying 'number' by (i + 1) and store it at index 'i'.
        // Step 4: Return the filled array.

        double[] multiples = new double[length];

        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }

        return multiples;
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
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Step 1: Find the starting index of the elements that need to move to the front by subtracting 'amount' from 'data.Count'.
        // Step 2: Use GetRange to copy the last 'amount' elements from 'data' into a temporary list.
        // Step 3: Use RemoveRange to remove those last 'amount' elements from the end of 'data'.
        // Step 4: Use InsertRange at index 0 to place the copied elements at the beginning of 'data'.

        int splitIndex = data.Count - amount;
        List<int> rightPart = data.GetRange(splitIndex, amount);
        data.RemoveRange(splitIndex, amount);
        data.InsertRange(0, rightPart);
    }
}

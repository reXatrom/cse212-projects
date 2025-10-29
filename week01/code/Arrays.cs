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
        // Create a new array to store the multiples
        double[] multiples = new double[length];
        
        // Loop through each position in the array
        for (int i = 0; i < length; i++)
        {
            // Calculate the multiple: number multiplied by (i + 1)
            // i + 1 is used because array indices start at 0, but we want to start with 1x the number
            multiples[i] = number * (i + 1);
        }
        
        // Return the array of multiples
        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    /// 
    
    
    
    public static void RotateListRight(List<int> data, int amount)
    {
        // Step 1: Calculate the split point - this is where the list will be divided
        // The last 'amount' elements will be moved to the front
        int splitIndex = data.Count - amount;
        
        // Step 2: Get the sublist that needs to be moved to the front
        // We use GetRange to get the elements from splitIndex to the end
        var elementsToMove = data.GetRange(splitIndex, amount);
        
        // Step 3: Remove the elements from their current position
        data.RemoveRange(splitIndex, amount);
        
        // Step 4: Insert the elements at the beginning of the list
        data.InsertRange(0, elementsToMove);
        
        // The list is now modified in place with the elements rotated right by 'amount'
    }
}

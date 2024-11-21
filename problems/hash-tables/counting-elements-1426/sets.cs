public class Solution
{
    // Time: O(n)
    // Space: O(n)
    public int CountElements(int[] arr)
    {
        HashSet<int> numSet = new(arr);

        int count = 0;

        foreach (int num in arr)
        {
            if (numSet.Contains(num + 1))
            {
                count++;
            }
        }

        return count;
    }
}

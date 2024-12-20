public class Solution
{
    // Time: O(n)
    // Space: O(n)
    public bool ContainsDuplicate(int[] nums)
    {
        if (nums.Length <= 1)
        {
            return false;
        }

        HashSet<int> numSet = new();

        foreach (int num in nums)
        {
            bool isDuplicated = !numSet.Add(num);

            if (isDuplicated)
            {
                return true;
            }
        }

        return false;
    }
}

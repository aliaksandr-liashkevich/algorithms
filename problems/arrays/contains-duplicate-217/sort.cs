public class Solution
{
    // Time: O(sort) ~ O(n log n)
    // Space: O(sort) ~ O(1)
    public bool ContainsDuplicate(int[] nums)
    {
        if (nums.Length <= 1)
        {
            return false;
        }

        Array.Sort(nums);

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] == nums[i - 1])
            {
                return true;
            }
        }

        return false;
    }
}

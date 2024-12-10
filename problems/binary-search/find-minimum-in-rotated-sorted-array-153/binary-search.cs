public class Solution
{
    // Time: O(log n)
    // Space: O(1)
    public int FindMin(int[] nums)
    {
        if (nums.Length == 0)
        {
            return -1;
        }

        int offset = FindOffset(nums);
        return nums[offset];
    }

    // Time: O(log n)
    // Space: O(1)
    private static int FindOffset(int[] nums)
    {
        int l = -1;
        int r = nums.Length - 1;

        while (r - l > 1)
        {
            int m = l + (r - l) / 2;

            if (IsGood(m))
            {
                l = m;
            }
            else
            {
                r = m;
            }
        }

        return l + 1;

        bool IsGood(int i) => nums[i] > nums[nums.Length - 1];
    }
}

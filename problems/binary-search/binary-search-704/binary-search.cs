public class Solution
{
    // Time: O(log n)
    // Space: O(1)
    public int Search(int[] nums, int target)
    {
        int l = 0;
        int r = nums.Length;

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

        return nums[l] == target ? l : -1;

        bool IsGood(int i) => nums[i] <= target;
    }
}

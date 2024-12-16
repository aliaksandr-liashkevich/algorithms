public class Solution
{
    // Time: O(log n)
    // Space: O(1)
    public int PeakIndexInMountainArray(int[] nums)
    {
        int l = 1;
        int r = nums.Length - 1;

        while (r - l > 1)
        {
            int m = l + (r - l) / 2;

            if (IsPeak(m))
            {
                l = m;
            }
            else
            {
                r = m;
            }
        }

        return IsPeak(l) ? l : -1;

        bool IsPeak(int i) => nums[i - 1] < nums[i];
    }
}

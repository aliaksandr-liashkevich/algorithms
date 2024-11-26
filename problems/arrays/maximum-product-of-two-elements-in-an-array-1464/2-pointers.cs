public class Solution
{
    // Time: O(n)
    // Space: O(1)
    public int MaxProduct(int[] nums)
    {
        int l = 0;
        int r = nums.Length - 1;

        int lMax = l;
        int rMax = r;

        while (l < nums.Length && r >= 0)
        {
            if (l != rMax)
            {
                lMax = nums[l] > nums[lMax] ? l : lMax;
            }

            if (r != lMax)
            {
                rMax = nums[r] > nums[rMax] ? r : rMax;
            }

            l++;
            r--;
        }

        return (nums[lMax] - 1) * (nums[rMax] - 1);
    }
}

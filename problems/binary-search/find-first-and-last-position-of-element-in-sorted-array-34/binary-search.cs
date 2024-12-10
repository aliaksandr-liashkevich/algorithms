public class Solution
{
    // Time: O(log n)
    // Space: O(1)
    public int[] SearchRange(int[] nums, int target)
    {
        int startIndex = FindStartIndex(nums, target);
        int endIndex = FindEndIndex(nums, startIndex);
        return [startIndex, endIndex];
    }

    // Time: O(log n)
    // Space: O(1)
    private static int FindStartIndex(int[] nums, int target)
    {
        if (nums.Length == 0)
        {
            return -1;
        }

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

        return nums[r] == target ? r : -1;

        bool IsGood(int i) => nums[i] < target;
    }

    // Time: O(log (n - startIndex))
    // Space: O(1)
    private static int FindEndIndex(int[] nums, int startIndex)
    {
        if (startIndex == -1)
        {
            return -1;
        }

        int target = nums[startIndex];

        int l = startIndex;
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

public class Solution
{
    // Time: O(log n) + O(log n) ~ O(log n)
    // Space: O(1)
    public int Search(int[] nums, int target)
    {
        int offset = FindOffset(nums);
        int targetIndex = FindTargetIndex(nums, target, offset);
        return targetIndex;
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

    // Time: O(log n)
    // Space: O(1)
    private static int FindTargetIndex(int[] nums, int target, int offset)
    {
        if (nums.Length == 0)
        {
            return -1;
        }

        int l = offset;
        int r = nums.Length + offset;

        while (r - l > 1)
        {
            int m = l + (r - l) / 2;

            if (IsGood(GetOffsetIndex(m)))
            {
                l = m;
            }
            else
            {
                r = m;
            }
        }

        return nums[GetOffsetIndex(l)] == target
            ? GetOffsetIndex(l)
            : -1;

        int GetOffsetIndex(int i) => i % nums.Length;

        bool IsGood(int i) => nums[i] <= target;
    }
}

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

        OffsetArray offsetNums = new OffsetArray(nums, offset);

        int l = 0;
        int r = offsetNums.Length;

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

        return offsetNums[l] == target ? offsetNums.GetOffsetIndex(l) : -1;

        bool IsGood(int i) => offsetNums[i] <= target;
    }

    private class OffsetArray
    {
        private readonly int[] _nums;
        private readonly int _offset;

        public OffsetArray(int[] nums, int offset)
        {
            _nums = nums;
            _offset = offset;
        }

        public int Length => _nums.Length;

        public int this[int index]
        {
            get
            {
                int offsetIndex = GetOffsetIndex(index);
                return _nums[offsetIndex];
            }
        }

        public int GetOffsetIndex(int index) => (index + _offset) % Length;
    }
}

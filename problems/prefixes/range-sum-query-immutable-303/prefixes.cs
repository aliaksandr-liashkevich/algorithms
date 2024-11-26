public class NumArray
{
    private readonly int[] _prefixSums;

    // Time: O(n)
    // Space: O(n)
    public NumArray(int[] nums)
    {
        _prefixSums = new int[nums.Length + 1];

        for (int numIndex = 0; numIndex < nums.Length; numIndex++)
        {
            _prefixSums[numIndex + 1] = _prefixSums[numIndex] + nums[numIndex];
        }
    }

    // Time: O(1)
    // Space: O(1)
    public int SumRange(int left, int right)
    {
        return _prefixSums[right + 1] - _prefixSums[left];
    }
}

/**
 * Your NumArray object will be instantiated and called as such:
 * NumArray obj = new NumArray(nums);
 * int param_1 = obj.SumRange(left,right);
 */

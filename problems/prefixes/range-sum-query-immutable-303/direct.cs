public class NumArray
{
    public int[] nums;

    // Time: O(1)
    // Space: O(1)
    public NumArray(int[] nums)
    {
        this.nums = nums;
    }

    // Time: O(right - left)
    // Space: O(1)
    public int SumRange(int left, int right)
    {
        int sum = 0;

        for (int i = left; i <= right; i++)
        {
            sum += nums[i];
        }

        return sum;
    }
}

/**
 * Your NumArray object will be instantiated and called as such:
 * NumArray obj = new NumArray(nums);
 * int param_1 = obj.SumRange(left,right);
 */

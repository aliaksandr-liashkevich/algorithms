public class Solution
{
    // Time: O(n)
    // Space: O(1)
    public double FindMaxAverage(int[] nums, int k)
    {
        if (k <= 0 || k > nums.Length)
        {
            return 0;
        }

        long kSum = 0;

        for (int i = 0; i < (k - 1); i++)
        {
            kSum += nums[i];
        }

        long maxSum = long.MinValue;

        for (int i = (k - 1); i < nums.Length; i++)
        {
            kSum += nums[i];

            maxSum = Math.Max(maxSum, kSum);

            kSum -= nums[i - (k - 1)];
        }

        return (double)maxSum / k;
    }
}

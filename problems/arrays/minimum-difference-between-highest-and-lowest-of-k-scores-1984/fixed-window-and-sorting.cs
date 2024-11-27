public class Solution
{
    // Time: O(n log n) + O (n - k) ~ O(n)
    // Space: O(1)
    public int MinimumDifference(int[] nums, int k)
    {
        if (k == 1)
        {
            return 0;
        }

        int answer = int.MaxValue;

        // O(n log n)
        Array.Sort(nums);

        int minIndex = 0;
        int maxIndex = k - 1;

        // O(n - k)
        while (maxIndex < nums.Length)
        {
            answer = Math.Min(answer, nums[maxIndex] - nums[minIndex]);
            minIndex++;
            maxIndex++;
        }

        return answer;
    }
}

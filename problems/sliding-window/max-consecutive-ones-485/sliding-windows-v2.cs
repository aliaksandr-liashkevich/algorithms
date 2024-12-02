public class Solution
{
    // Time: O(n)
    // Space: O(1)
    public int FindMaxConsecutiveOnes(int[] nums)
    {
        if (nums.Length == 0)
        {
            return 0;
        }

        int l = 0;
        int prev = nums[l];
        int answer = 0;

        for (int r = 0; r < nums.Length; r++)
        {
            int curr = nums[r];

            while (prev != curr)
            {
                l++;
                prev = nums[l];
            }

            if (curr == 1)
            {
                answer = Math.Max(answer, r - l + 1);
            }
        }

        return answer;
    }
}

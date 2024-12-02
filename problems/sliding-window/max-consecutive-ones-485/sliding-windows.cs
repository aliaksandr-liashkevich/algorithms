public class Solution
{
    // Time: O(n)
    // Space: O(1)
    public int FindMaxConsecutiveOnes(int[] nums)
    {
        int l = 0;
        int r = 0;
        int answer = 0;

        while (l < nums.Length)
        {
            while ((r + 1) < nums.Length && nums[r] == nums[r + 1])
            {
                r++;
            }

            if (nums[r] == 1)
            {
                answer = Math.Max(answer, r - l + 1);
            }

            r++;
            l = r;
        }

        return answer;
    }
}

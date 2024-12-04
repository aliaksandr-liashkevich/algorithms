// int[] nums = [3, 1, 2, 11, 4, 2, 1, 1, 5];
// int k = 8;

// int answer = new Solution().LongestSubarraySumLessOrEqual(nums, k);

// bool isPassed = answer == 4; // 4 2 1 1

public class Solution
{
    // Time: O(n)
    // Space: O(1)
    public int LongestSubarraySumLessOrEqual(int[] nums, int targetSum)
    {
        if (nums.Length == 0)
        {
            return 0;
        }

        int l = 0;
        int r = -1;
        int currSum = 0;
        int answer = 0;

        while (l < nums.Length)
        {
            while ((r + 1) < nums.Length && (currSum + nums[r + 1]) <= targetSum)
            {
                r++;
                currSum += nums[r];
            }

            answer = Math.Max(answer, r - l + 1);

            currSum -= nums[l];
            l++;
        }

        return answer;
    }
}

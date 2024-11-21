public class Solution
{
    // Time: O(n)
    // Space: O(1)
    public int MissingNumber(int[] nums)
    {
        int answer = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            answer += (i + 1 - nums[i]);
        }

        return answer;
    }
}

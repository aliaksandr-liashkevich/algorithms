public class Solution
{
    // Time: O(n)
    // Space: O(1)
    public int FindLengthOfLCIS(int[] nums)
    {
        int prev = int.MaxValue;
        int count = 0;
        int answer = 0;

        foreach (int curr in nums)
        {
            if (prev < curr)
            {
                count++;
            }
            else
            {
                count = 1;
            }

            answer = Math.Max(answer, count);
            prev = curr;
        }

        return answer;
    }
}

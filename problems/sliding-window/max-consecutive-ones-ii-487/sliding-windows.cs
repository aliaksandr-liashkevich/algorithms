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
        int r = -1;
        int zeroCount = 0;
        int answer = 0;

        while (l < nums.Length)
        {
            while ((r + 1) < nums.Length && (nums[r + 1] == 1 || zeroCount < 1))
            {
                r++;
                zeroCount += GetOneIfZero(r);
            }

            answer = Math.Max(answer, r - l + 1);

            zeroCount -= GetOneIfZero(l);
            l++;
        }

        return answer;

        int GetOneIfZero(int index) => nums[index] == 0 ? 1 : 0;
    }
}

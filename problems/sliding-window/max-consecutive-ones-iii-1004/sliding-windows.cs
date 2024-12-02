public class Solution
{
    // Time: O(n)
    // Space: O(1)
    public int LongestOnes(int[] nums, int k)
    {
        if (nums.Length == 0)
        {
            return 0;
        }

        int l = 0;
        int r = 0;
        int zeroCount = GetOneIfZero(r);
        int answer = 0;

        while (l < nums.Length)
        {
            if (k > 0 || (k == 0 && nums[r] == 1))
            {
                while ((r + 1) < nums.Length && (nums[r + 1] == 1 || zeroCount < k))
                {
                    r++;
                    zeroCount += GetOneIfZero(r);
                }

                answer = Math.Max(answer, r - l + 1);
            }

            zeroCount -= GetOneIfZero(l);
            l++;

            if (r < l && l < nums.Length)
            {
                r = l;
                zeroCount += GetOneIfZero(r);
            }
        }

        return answer;

        int GetOneIfZero(int index) => nums[index] == 0 ? 1 : 0;
    }
}
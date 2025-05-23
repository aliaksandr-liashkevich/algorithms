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
        int zerosCount = 0;
        int answer = 0;

        for (int r = 0; r < nums.Length; r++)
        {
            zerosCount += GetOneIfZero(r);

            while (zerosCount > 1)
            {
                zerosCount -= GetOneIfZero(l);
                l++;
            }

            answer = Math.Max(answer, r - l + 1);
        }

        return answer;

        int GetOneIfZero(int index) => nums[index] == 0 ? 1 : 0;
    }
}

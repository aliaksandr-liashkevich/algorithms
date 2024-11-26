public class Solution
{
    // Time: O(n)
    // Space: O(1)
    public int MissingNumber(int[] nums)
    {
        int answer = SumOfN(nums.Length);

        foreach (int num in nums)
        {
            answer -= num;
        }

        return answer;
    }

    private int SumOfN(int n)
    {
        return n * (n + 1) / 2;
    }
}

public class Solution
{
    // Time: O(n)
    // Space: O(1)
    public int[] SortedSquares(int[] nums)
    {
        int l = 0;
        int r = nums.Length - 1;

        int[] answer = new int[nums.Length];
        int p = r;

        while (r >= l)
        {
            int lSquare = nums[l] * nums[l];
            int rSquare = nums[r] * nums[r];

            if (lSquare > rSquare)
            {
                answer[p] = lSquare;
                l++;
            }
            else
            {
                answer[p] = rSquare;
                r--;
            }

            p--;
        }

        return answer;
    }
}

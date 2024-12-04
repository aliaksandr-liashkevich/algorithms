public class Solution
{
    // Time: O(n)
    // Space: O(n)
    public int[] SortedSquares(int[] nums)
    {
        int l = 0;
        int r = nums.Length - 1;

        int[] answer = new int[nums.Length];
        int p = r;

        while (r >= l)
        {
            if (Math.Abs(nums[l]) > Math.Abs(nums[r]))
            {
                answer[p] = nums[l] * nums[l];
                l++;
            }
            else
            {
                answer[p] = nums[r] * nums[r];
                r--;
            }

            p--;
        }

        return answer;
    }
}

public class Solution
{
    // Time: O(n)
    // Space: O(n)
    public IList<string> SummaryRanges(int[] nums)
    {
        int l = 0;
        int r = 0;

        List<string> intervals = new List<string>();

        while (l < nums.Length)
        {
            while ((r + 1) < nums.Length && nums[r + 1] == nums[r] + 1)
            {
                r++;
            }

            if (l == r)
            {
                intervals.Add($"{nums[l]}");
            }
            else
            {
                intervals.Add($"{nums[l]}->{nums[r]}");
            }

            r++;
            l = r;
        }

        return intervals;
    }
}

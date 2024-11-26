public class Solution
{
    // Time: O(n)
    // Space: O(n)
    public int SubarraySum(int[] nums, int targetSum)
    {
        Dictionary<int, int> countsByPxSum = new();
        countsByPxSum.Add(0, 1);

        int pxSum = 0;
        int answer = 0;

        foreach (int num in nums)
        {
            pxSum += num;

            if (countsByPxSum.TryGetValue(pxSum - targetSum, out int count))
            {
                answer += count;
            }

            if (!countsByPxSum.ContainsKey(pxSum))
            {
                countsByPxSum[pxSum] = 0;
            }

            countsByPxSum[pxSum]++;
        }

        return answer;
    }
}

public class Solution
{
    // Time: O(n)
    // Space: O(n)
    public int NumberOfSubarrays(int[] nums, int k)
    {
        Dictionary<int, int> countsByPxOdd = new();
        countsByPxOdd.Add(0, 1);

        int pxOdd = 0;
        int answer = 0;

        foreach (int num in nums)
        {
            pxOdd += (num & 1);

            if (countsByPxOdd.TryGetValue(pxOdd - k, out int count))
            {
                answer += count;
            }

            if (!countsByPxOdd.ContainsKey(pxOdd))
            {
                countsByPxOdd[pxOdd] = 0;
            }

            countsByPxOdd[pxOdd]++;
        }

        return answer;
    }
}

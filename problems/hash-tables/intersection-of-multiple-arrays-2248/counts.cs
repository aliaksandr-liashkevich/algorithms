public class Solution
{
    private const int MAX_NUMBER = 1000;

    // n - the number of all nums, k - the number of distinct nums ~ 1000
    // Time: O(n + k log k)
    // Space: O(k) ~ O(1000) ~ O(1)
    public IList<int> Intersection(int[][] nums)
    {
        int[] counts = new int[MAX_NUMBER + 1];

        int subnumsCount = 0;

        foreach (int[] subnums in nums)
        {
            subnumsCount++;

            foreach (int num in subnums)
            {
                counts[num]++;
            }
        }

        List<int> answer = new();

        for (int i = 0; i < counts.Length; i++)
        {
            if (counts[i] == subnumsCount)
            {
                answer.Add(i);
            }
        }

        return answer;
    }
}

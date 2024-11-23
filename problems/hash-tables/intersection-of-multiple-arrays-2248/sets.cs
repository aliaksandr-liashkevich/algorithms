public class Solution
{
    // n - the number of all nums, k - the number of distinct nums
    // Time: O(n + k log k)
    // Space: O(k)
    public IList<int> Intersection(int[][] nums)
    {
        Dictionary<int, int> countsByNum = new();

        int subnumsCount = 0;

        foreach (int[] subnums in nums)
        {
            subnumsCount++;

            foreach (int num in subnums)
            {
                if (!countsByNum.ContainsKey(num))
                {
                    countsByNum[num] = 0;
                }

                countsByNum[num]++;
            }
        }

        List<int> answer = new();

        foreach (KeyValuePair<int, int> countByNum in countsByNum)
        {
            if (countByNum.Value == subnumsCount)
            {
                answer.Add(countByNum.Key);
            }
        }

        answer.Sort();

        return answer;
    }
}

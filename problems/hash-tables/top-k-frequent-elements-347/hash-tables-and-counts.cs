public class Solution
{
    // Time: O(n)
    // Space: O(n)
    public int[] TopKFrequent(int[] nums, int k)
    {
        if (k <= 0 || k > nums.Length)
        {
            return [];
        }

        Dictionary<int, int> countsByNum = new();

        foreach (int num in nums)
        {
            if (!countsByNum.ContainsKey(num))
            {
                countsByNum[num] = 0;
            }

            countsByNum[num]++;
        }

        LinkedList<int>[] numsByCount = new LinkedList<int>[nums.Length + 1];

        foreach (KeyValuePair<int, int> countByNum in countsByNum)
        {
            numsByCount[countByNum.Value] ??= new LinkedList<int>();
            numsByCount[countByNum.Value].AddLast(countByNum.Key);
        }

        int[] answer = new int[k];
        int answerIndex = 0;

        for (int i = numsByCount.Length - 1; i >= 0; i--)
        {
            if (numsByCount[i] is null)
            {
                continue;
            }

            foreach (int num in numsByCount[i])
            {
                answer[answerIndex] = num;
                answerIndex++;

                if (k == answerIndex)
                {
                    return answer;
                }
            }
        }

        return answer;
    }
}
public class Solution
{
    // Time: O(n log k)
    // Space: O(k) + O(k) ~ O(k)
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

        PriorityQueue<int, int> minQueue = new(k);

        foreach (KeyValuePair<int, int> countByNum in countsByNum)
        {
            int num = countByNum.Key;
            int count = countByNum.Value;

            if (minQueue.Count < k)
            {
                minQueue.Enqueue(num, count);
            }
            else if (minQueue.TryPeek(out int _, out int minCount) && count > minCount)
            {
                minQueue.Dequeue();
                minQueue.Enqueue(num, count);
            }
        }

        int[] topKFrequentElements = new int[k];
        int index = 0;

        while (minQueue.Count > 0)
        {
            topKFrequentElements[index] = minQueue.Dequeue();
            index++;
        }

        return topKFrequentElements;
    }
}

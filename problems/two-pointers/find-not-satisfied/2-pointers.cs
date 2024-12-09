public class Solution
{
    // Time: O(n + m)
    // Space: O(1)
    public int FindNotSatisfied(int[] goodIds, int[] needIds)
    {
        if (goodIds.Length == 0)
        {
            return needIds.Sum();
        }

        Array.Sort(goodIds);
        Array.Sort(needIds);

        int goodIndex = 0;
        int notSatisfied = 0;

        foreach (int needId in needIds)
        {
            while ((goodIndex + 1) < goodIds.Length &&
                Math.Abs(needId - goodIds[goodIndex]) >= Math.Abs(needId - goodIds[goodIndex + 1]))
            {
                goodIndex++;
            }

            notSatisfied += Math.Abs(needId - goodIds[goodIndex]);
        }

        return notSatisfied;
    }
}

public class Solution
{
    // n - the length of the first list
    // m - the length of the second list
    // Time: O(n + m)
    // Space: O(k) ~ O(min(n, m))
    public int[][] IntervalIntersection(int[][] firstList, int[][] secondList)
    {
        int firstIndex = 0;
        int secondIndex = 0;

        List<int[]> intersectedIntervals = new();

        while (firstIndex < firstList.Length && secondIndex < secondList.Length)
        {
            int[] firstInterval = firstList[firstIndex];
            int[] secondInterval = secondList[secondIndex];

            if (IsOverlap(firstInterval, secondInterval))
            {
                intersectedIntervals.Add(Intersect(firstInterval, secondInterval));
            }

            if (firstInterval[1] < secondInterval[1])
            {
                firstIndex++;
            }
            else
            {
                secondIndex++;
            }
        }

        return intersectedIntervals.ToArray();

        int[] Intersect(int[] a, int[] b)
            => [Math.Max(a[0], b[0]), Math.Min(a[1], b[1])];

        bool IsOverlap(int[] a, int[] b)
            => Math.Max(a[0], b[0]) <= Math.Min(a[1], b[1]);
    }
}

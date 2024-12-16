public class Solution
{
    // n - the number of intervals
    // Time: O(sort) + O(n) ~ O(n log n)
    // Space: O(sort) + O(n) ~ O(n)
    public int[][] Merge(int[][] intervals)
    {
        if (intervals.Length == 0)
        {
            return new int[0][];
        }

        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

        List<int[]> answer = new();
        answer.Add(intervals[0]);

        foreach (int[] curr in intervals)
        {
            int[] prev = answer[^1];

            if (IsOverlap(prev, curr))
            {
                answer[^1] = Union(prev, curr);
            }
            else
            {
                answer.Add(curr);
            }
        }

        return answer.ToArray();

        bool IsOverlap(int[] a, int[] b)
            => Math.Max(a[0], b[0]) <= Math.Min(a[1], b[1]);

        int[] Union(int[] a, int[] b)
            => [a[0], Math.Max(a[1], b[1])];
    }
}

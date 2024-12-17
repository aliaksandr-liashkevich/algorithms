public class Solution
{
    // Time: O(sort) ~ O(n log n)
    // Space: O(sort) ~ O(1)
    public int FindMinArrowShots(int[][] points)
    {
        if (points.Length <= 1)
        {
            return points.Length;
        }

        Array.Sort(points, (a, b) =>
        {
            int result = a[0].CompareTo(b[0]);
            return result == 0 ? a[1].CompareTo(b[1]) : result;
        });

        int[] prev = points[0];
        int minArrows = 1;

        foreach (int[] curr in points)
        {
            if (IsOverlap(prev, curr))
            {
                prev = Intersect(prev, curr);
            }
            else
            {
                prev = curr;
                minArrows++;
            }
        }

        return minArrows;

        bool IsOverlap(int[] a, int[] b)
            => Math.Max(a[0], b[0]) <= Math.Min(a[1], b[1]);

        int[] Intersect(int[] a, int[] b)
            => [Math.Max(a[0], b[0]), Math.Min(a[1], b[1])];
    }
}

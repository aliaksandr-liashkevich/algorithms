public class Solution {
    // Time: O(n)
    // Space: O(n)
    public bool IsReflected(int[][] points) {
        if (points.Length == 0)
        {
            return false;
        }

        HashSet<(int X, int Y)> pointSet = new();

        int minX = int.MaxValue;
        int maxX = int.MinValue;

        foreach (int[] point in points)
        {
            pointSet.Add((point[0], point[1]));
            minX = Math.Min(minX, point[0]);
            maxX = Math.Max(maxX, point[0]);
        }

        foreach (int[] point in points)
        {
            int reverseX = maxX + minX - point[0];

            if (!pointSet.Contains((reverseX, point[1])))
            {
                return false;
            }
        }

        return true;
    }
}
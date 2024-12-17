public class Solution
{
    // Time: O(sort) ~ O(n log n)
    // Space: O(sort) ~ O(1)
    public bool CarPooling(int[][] trips, int availableCapacity)
    {
        if (trips.Length == 0 || availableCapacity <= 0)
        {
            return availableCapacity > 0;
        }

        List<(int Point, int Passengers)> points = new();

        foreach (int[] trip in trips)
        {
            int passengers = trip[0];
            int from = trip[1];
            int to = trip[2];

            points.Add((from, +passengers));
            points.Add((to, -passengers));
        }

        points.Sort();

        int currentCapacity = 0;

        foreach ((int _, int passengers) in points)
        {
            currentCapacity += passengers;

            if (currentCapacity > availableCapacity)
            {
                return false;
            }
        }

        return true;
    }
}

public class Solution
{
    // Time: O(sort) + O(2n)
    // Space: O(sort)
    public int MinMeetingRooms(int[][] intervals)
    {
        if (intervals.Length == 0)
        {
            return 0;
        }

        List<(int Time, int Count)> points = new();

        foreach (int[] interval in intervals)
        {
            points.Add((interval[0], +1));
            points.Add((interval[1], -1));
        }

        points.Sort();

        int maxRooms = 0;
        int currRooms = 0;

        foreach ((int _, int count) in points)
        {
            currRooms += count;
            maxRooms = Math.Max(maxRooms, currRooms);
        }

        return maxRooms;
    }
}

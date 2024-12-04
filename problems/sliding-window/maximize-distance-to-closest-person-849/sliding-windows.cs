public class Solution
{
    // Time: O(n)
    // Space: O(1)
    public int MaxDistToClosest(int[] seats)
    {
        if (seats.Length == 0)
        {
            return 0;
        }

        int l = 0;
        int r = 0;
        int maxDistance = 0;

        while (l < seats.Length)
        {
            while ((r + 1) < seats.Length && seats[r] == seats[r + 1])
            {
                r++;
            }

            if (seats[r] == 0)
            {
                bool isLeftFirst = l == 0;
                bool isRightLast = r == (seats.Length - 1);

                int windowSize = isLeftFirst || isRightLast
                    ? (r - l + 1)
                    : (r - l + 2) / 2;

                maxDistance = Math.Max(maxDistance, windowSize);
            }

            r++;
            l = r;
        }

        return maxDistance;
    }
}

public class Solution
{
    // Time: O(log n)
    // Space: O(1)
    public bool IsPerfectSquare(int x)
    {
        int sqrtX = Sqrt(x);
        return sqrtX * sqrtX == x;
    }

    // Time: O(log n)
    // Space: O(1)
    private static int Sqrt(int x)
    {
        if (x <= 1)
        {
            return x;
        }

        int l = 1;
        int r = x / 2 + 1;

        while (r - l > 1)
        {
            int m = l + (r - l) / 2;

            if (IsGood(m))
            {
                l = m;
            }
            else
            {
                r = m;
            }
        }

        return l;

        bool IsGood(int i) => (long) i * i <= x;
    }
}

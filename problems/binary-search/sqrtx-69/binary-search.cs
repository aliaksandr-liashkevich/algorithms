public class Solution
{
    // Time: O(log n)
    // Space: O(1)
    public int MySqrt(int x)
    {
        long l = 0;
        long r = (long)x + 1;

        while (r - l > 1)
        {
            long m = l + (r - l) / 2;

            if (IsGood(m))
            {
                l = m;
            }
            else
            {
                r = m;
            }
        }

        return (int)l;

        bool IsGood(long i) => i * i <= x;
    }
}

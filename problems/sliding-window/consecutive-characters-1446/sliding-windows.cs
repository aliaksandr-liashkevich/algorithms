public class Solution
{
    // Time: O(n)
    // Space: O(1)
    public int MaxPower(string s)
    {
        if (s.Length == 0)
        {
            return 0;
        }

        int l = 0;
        int r = 0;

        int maxLength = 0;

        while (l < s.Length)
        {
            while ((r + 1) < s.Length && s[r] == s[r + 1])
            {
                r++;
            }

            maxLength = Math.Max(maxLength, r - l + 1);

            r++;
            l = r;
        }

        return maxLength;
    }
}

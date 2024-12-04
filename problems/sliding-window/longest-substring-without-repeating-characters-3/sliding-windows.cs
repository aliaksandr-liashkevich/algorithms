public class Solution
{
    // Time: O(n)
    // Space: O(unique(n))
    public int LengthOfLongestSubstring(string s)
    {
        if (s.Length == 0)
        {
            return 0;
        }

        int l = 0;
        int r = -1;

        HashSet<char> windowCharSet = new();

        int maxLength = 0;

        while (l < s.Length)
        {
            while ((r + 1) < s.Length && !windowCharSet.Contains(s[r + 1]))
            {
                r++;
                windowCharSet.Add(s[r]);
            }

            maxLength = Math.Max(maxLength, r - l + 1);

            windowCharSet.Remove(s[l]);
            l++;
        }

        return maxLength;
    }
}

public class Solution
{
    // Time: O(n)
    // Space: O(1)
    public bool IsOneEditDistance(string s, string t)
    {
        if (Math.Abs(s.Length - t.Length) > 1 || s == t)
        {
            return false;
        }


        int sIndex = 0;
        int tIndex = 0;

        while (sIndex < s.Length && tIndex < t.Length)
        {
            if (s[sIndex] != t[tIndex])
            {
                return s.Substring(sIndex + 1) == t.Substring(tIndex + 1) ||
                    s.Substring(sIndex) == t.Substring(tIndex + 1) ||
                    s.Substring(sIndex + 1) == t.Substring(tIndex);
            }

            sIndex++;
            tIndex++;
        }

        return true;
    }
}

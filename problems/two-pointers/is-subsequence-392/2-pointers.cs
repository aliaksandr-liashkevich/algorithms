public class Solution
{
    // n - the length of the t string
    // Time: O(n)
    // Space: O(1)
    public bool IsSubsequence(string s, string t)
    {
        if (s.Length > t.Length)
        {
            return false;
        }

        int pS = 0;
        int pT = 0;

        while (pS < s.Length && pT < t.Length)
        {
            if (s[pS] == t[pT])
            {
                pS++;
            }

            pT++;
        }

        return pS == s.Length;
    }
}

public class Solution
{
    // Time: O(n)
    // Space: O(1)
    public bool IsOneEditDistance(string s, string t)
    {
        if (Math.Abs(s.Length - t.Length) > 1)
        {
            return false;
        }

        bool wasDeleted = false;
        bool wasReplaced = false;
        bool wasInserted = false;

        int sIndex = 0;
        int tIndex = 0;

        while (sIndex < s.Length && tIndex < t.Length)
        {
            if (s[sIndex] == t[tIndex])
            {
                tIndex++;
                sIndex++;

                continue;
            }

            if (s.Length > t.Length)
            {
                if (wasDeleted)
                {
                    return false;
                }
                else
                {
                    sIndex++;
                    wasDeleted = true;
                }
            }
            else if (s.Length < t.Length)
            {
                if (wasInserted)
                {
                    return false;
                }
                else
                {
                    tIndex++;
                    wasInserted = true;
                }
            }
            else
            {
                if (wasReplaced)
                {
                    return false;
                }
                else
                {
                    tIndex++;
                    sIndex++;
                    wasReplaced = true;
                }
            }
        }

        if (wasReplaced || wasDeleted || wasInserted)
        {
            return true;
        }
        else
        {
            return Math.Abs(s.Length - t.Length) == 1;
        }
    }
}

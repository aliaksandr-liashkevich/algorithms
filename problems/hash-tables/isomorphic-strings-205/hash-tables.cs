public class Solution
{
    // Time: O(n)
    // Space: O(n)
    public bool IsIsomorphic(string s, string t)
    {
        int length = s.Length;

        if (s.Length != t.Length)
        {
            return false;
        }

        Dictionary<char, char> tCharsBySChar = new(length);
        Dictionary<char, char> sCharsByTChar = new(length);

        for (int i = 0; i < length; i++)
        {
            if (tCharsBySChar.TryGetValue(s[i], out char tChar))
            {
                if (tChar != t[i])
                {
                    return false;
                }
            }
            else
            {
                tCharsBySChar[s[i]] = t[i];
            }

            if (sCharsByTChar.TryGetValue(t[i], out char sChar))
            {
                if (sChar != s[i])
                {
                    return false;
                }
            }
            else
            {
                sCharsByTChar[t[i]] = s[i];
            }
        }

        return true;
    }
}
public class Solution
{
    // Time: O(n)
    // Space: O(1)
    public bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length)
        {
            return false;
        }

        int[] countsByLetterIndex = new int['z' - 'a' + 1];

        foreach (char letter in s)
        {
            countsByLetterIndex[letter - 'a']++;
        }

        foreach (char letter in t)
        {
            int letterIndex = letter - 'a';

            if (countsByLetterIndex[letterIndex] == 0)
            {
                return false;
            }

            countsByLetterIndex[letterIndex]--;
        }

        return true;
    }
}
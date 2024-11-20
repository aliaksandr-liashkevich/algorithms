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

        Dictionary<char, int> countsByLetter = new();

        foreach (char letter in s)
        {
            if (!countsByLetter.ContainsKey(letter))
            {
                countsByLetter[letter] = 0;
            }

            countsByLetter[letter]++;
        }

        foreach (char letter in t)
        {
            if (!countsByLetter.TryGetValue(letter, out int count) || count == 0)
            {
                return false;
            }

            countsByLetter[letter]--;
        }

        return true;
    }
}
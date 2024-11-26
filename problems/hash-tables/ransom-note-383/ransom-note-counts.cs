public class Solution
{
    // the n - the length of magazine
    // Time: O(n)
    // Space: O(1)
    public bool CanConstruct(string ransomNote, string magazine)
    {
        if (ransomNote.Length > magazine.Length)
        {
            return false;
        }

        int[] counts = new int['z' - 'a' + 1];

        foreach (char letter in ransomNote)
        {
            counts[letter - 'a']++;
        }

        foreach (char letter in magazine)
        {
            int letterIndex = letter - 'a';

            if (counts[letterIndex] == 0)
            {
                continue;
            }

            counts[letterIndex]--;

            if (counts[letterIndex] < 0)
            {
                return false;
            }
        }

        return counts.All(x => x == 0);
    }
}

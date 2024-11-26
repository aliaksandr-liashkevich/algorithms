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

        foreach (char letter in magazine)
        {
            counts[letter - 'a']++;
        }

        foreach (char letter in ransomNote)
        {
            int letterIndex = letter - 'a';

            counts[letterIndex]--;

            if (counts[letterIndex] < 0)
            {
                return false;
            }
        }

        return true;
    }
}

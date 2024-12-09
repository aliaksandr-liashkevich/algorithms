public class Solution
{
    // Time: O(n + 26 * 2n) ~ O(53n)
    // Space: O(26)
    public int CharacterReplacement(string s, int k)
    {
        int maxLength = 0;

        // O(n)
        HashSet<char> validLetters = new HashSet<char>(s.Select(x => x));

        // O(26)
        foreach (char validLetter in validLetters)
        {
            int l = 0;
            int r = -1;

            int numberOfReplacements = 0;

            // O(2n) ~ O(n)
            while (l < s.Length)
            {
                while ((r + 1) < s.Length &&
                    (s[r + 1] == validLetter || numberOfReplacements < k))
                {
                    r++;

                    if (s[r] != validLetter)
                    {
                        numberOfReplacements++;
                    }
                }

                maxLength = Math.Max(maxLength, r - l + 1);

                if (s[l] != validLetter)
                {
                    numberOfReplacements--;
                }

                l++;
            }
        }

        return maxLength;
    }
}

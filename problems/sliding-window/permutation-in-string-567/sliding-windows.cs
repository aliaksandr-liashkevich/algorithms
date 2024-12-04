public class Solution
{
    // Time: O(n)
    // Space: O(unique(n)) ~ O(1)
    public bool CheckInclusion(string s1, string s2)
    {
        Dictionary<char, int> countsByS1Char = new();

        foreach (char letter in s1)
        {
            countsByS1Char[letter] = countsByS1Char.GetValueOrDefault(letter) + 1;
        }

        Dictionary<char, int> countsByWindowChar = new();

        int l = 0;
        int r = -1;

        while (l < s2.Length)
        {
            while ((r + 1) < s2.Length &&
                countsByWindowChar.GetValueOrDefault(s2[r + 1]) < countsByS1Char.GetValueOrDefault(s2[r + 1]))
            {
                r++;
                countsByWindowChar[s2[r]] = countsByWindowChar.GetValueOrDefault(s2[r]) + 1;
            }

            if ((r - l + 1) == s1.Length)
            {
                return true;
            }

            countsByWindowChar[s2[l]] = countsByWindowChar.GetValueOrDefault(s2[l]) - 1;

            // Optional dictionary clearing.
            // if (countsByWindowChar[s2[l]] == 0)
            // {
            //     countsByWindowChar.Remove(s2[l]);
            // }

            l++;
        }

        return false;
    }
}

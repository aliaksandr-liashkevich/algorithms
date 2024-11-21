public class Solution
{
    // Time: O(n)
    // Space: O(k)
    public int LengthOfLongestSubstringKDistinct(string s, int k)
    {
        int length = s.Length;

        if (k <= 0 || length == 0)
        {
            return 0;
        }

        int l = 0;
        int r = 0;

        Dictionary<char, int> countsBySymbol = new()
        {
            { s[r], 1 }
        };
        int answer = 0;

        while (l < length)
        {
            while ((r + 1) < length &&
                (countsBySymbol.Count < k || countsBySymbol.ContainsKey(s[r + 1])))
            {
                r++;

                if (!countsBySymbol.ContainsKey(s[r]))
                {
                    countsBySymbol[s[r]] = 0;
                }

                countsBySymbol[s[r]]++;
            }

            answer = Math.Max(answer, (r - l + 1));

            countsBySymbol[s[l]]--;

            if (countsBySymbol[s[l]] == 0)
            {
                countsBySymbol.Remove(s[l]);
            }

            l++;
        }

        return answer;
    }
}

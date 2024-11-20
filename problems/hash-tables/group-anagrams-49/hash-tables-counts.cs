public class Solution {
    // n - the number of words, n - the number of letters in the longest word
    // Time: O(n * m)
    // Space: O(n * m)
    public IList<IList<string>> GroupAnagrams(string[] words)
    {
        Dictionary<string, IList<string>> anagramsByCountsKey = new();

        foreach (string word in words)
        {
            int[] counts = CountLetters(word);
            string countsKey = ToCountsKey(counts);

            if (!anagramsByCountsKey.ContainsKey(countsKey))
            {
                anagramsByCountsKey[countsKey] = new List<string>();
            }

            anagramsByCountsKey[countsKey].Add(word);
        }

        return anagramsByCountsKey.Select(x => x.Value).ToList();
    }

    private int[] CountLetters(string word)
    {
        int[] counts = new int['z' - 'a' + 1];

        foreach (char letter in word)
        {
            counts[letter - 'a']++;
        }

        return counts;
    }

    private string ToCountsKey(int[] counts)
    {
        StringBuilder sb = new();

        for (int i = 0; i < counts.Length; i++)
        {
            int count = counts[i];

            if (count > 0)
            {
                sb.Append((char)(i + 'a')).Append(count);
            }
        }

        return sb.ToString();
    }
}
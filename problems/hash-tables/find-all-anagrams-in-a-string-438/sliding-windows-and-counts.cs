public class Solution
{
    // Time: O(n)
    // Space: O(1)
    public IList<int> FindAnagrams(string s, string p)
    {
        int k = p.Length;

        if (k == 0 || k > s.Length)
        {
            return new List<int>();
        }

        int[] counts = new int['z' - 'a' + 1];

        foreach (char letter in p)
        {
            int letterIndex = letter - 'a';
            counts[letterIndex]++;
        }

        int count = k;

        for (int i = 0; i < (k - 1); i++)
        {
            int letterIndex = s[i] - 'a';
            counts[letterIndex]--;

            if (counts[letterIndex] >= 0)
            {
                count--;
            }
        }

        List<int> answer = new();

        for (int rightIndex = (k - 1); rightIndex < s.Length; rightIndex++)
        {
            int leftIndex = rightIndex - (k - 1);

            int rightLetterIndex = s[rightIndex] - 'a';
            int leftLetterIndex = s[leftIndex] - 'a';

            counts[rightLetterIndex]--;

            if (counts[rightLetterIndex] >= 0)
            {
                count--;
            }

            if (count == 0)
            {
                answer.Add(leftIndex);
            }

            if (counts[leftLetterIndex] >= 0)
            {
                count++;
            }

            counts[leftLetterIndex]++;
        }

        return answer;
    }
}

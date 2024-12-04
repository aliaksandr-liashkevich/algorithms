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

        int[] expectedCounts = new int['z' - 'a' + 1];
        int expectedBits = 0;

        foreach (char letter in p)
        {
            int letterIndex = letter - 'a';
            expectedCounts[letterIndex]++;
            expectedBits |= (1 << letterIndex);
        }

        int[] actualCounts = new int['z' - 'a' + 1];
        int actualBits = 0;

        for (int i = 0; i < (k - 1); i++)
        {
            int letterIndex = s[i] - 'a';
            actualCounts[letterIndex]++;
            RefreshActualBits(letterIndex);
        }

        List<int> answer = new();

        for (int rightIndex = (k - 1); rightIndex < s.Length; rightIndex++)
        {
            int leftIndex = rightIndex - (k - 1);

            int rightLetterIndex = s[rightIndex] - 'a';
            actualCounts[rightLetterIndex]++;
            RefreshActualBits(rightLetterIndex);

            bool isExpectedEqualToActual = expectedBits == actualBits;

            if (isExpectedEqualToActual)
            {
                answer.Add(leftIndex);
            }

            int leftLetterIndex = s[leftIndex] - 'a';
            actualCounts[leftLetterIndex]--;
            RefreshActualBits(leftLetterIndex);
        }

        return answer;

        void RefreshActualBits(int letterIndex)
        {
            if (actualCounts[letterIndex] != expectedCounts[letterIndex] ||
                actualCounts[letterIndex] == 0)
            {
                // Reset bit by letter index
                actualBits &= (~(1 << letterIndex));
            }
            else
            {
                // Set bit by letter index
                actualBits |= (1 << letterIndex);
            }
        }
    }
}

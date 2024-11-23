public class Solution
{
    // Time: O(n)
    // Space: O(1)
    public bool AreOccurrencesEqual(string s)
    {
        if (s.Length == 0)
        {
            return true;
        }

        int[] counts = new int['z' - 'a' + 1];

        int maxCount = 0;

        foreach (char letter in s)
        {
            int i = letter - 'a';
            counts[i]++;
            maxCount = Math.Max(maxCount, counts[i]);
        }

        return counts.All(count => count == 0 || count == maxCount);
    }
}

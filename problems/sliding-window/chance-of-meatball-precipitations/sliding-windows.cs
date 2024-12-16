// bool isPassed = new Solution().ChanceOfMeatballPrecipitations("ababcdaa", 3) == 0.5;
// isPassed = new Solution().ChanceOfMeatballPrecipitations("ab", 5) == 0;
// isPassed = new Solution().ChanceOfMeatballPrecipitations("ab", 1) == 1;

public class Solution
{
    // Time: O(n)
    // Space: O(1)
    public double ChanceOfMeatballPrecipitations(string gene, int k)
    {
        if (k <= 0 || k > gene.Length)
        {
            return 0;
        }

        CountArray counts = new();

        int uniqueCount = 0;

        for (int i = 0; i < (k - 1); i++)
        {
            if (counts[gene[i]] == 0)
            {
                uniqueCount++;
            }

            counts[gene[i]]++;
        }

        int totalCombs = 0;
        int uniqueCombs = 0;

        for (int r = (k - 1); r < gene.Length; r++)
        {
            int l = r - (k - 1);

            if (counts[gene[r]] == 0)
            {
                uniqueCount++;
            }

            counts[gene[r]]++;

            if (uniqueCount == k)
            {
                uniqueCombs++;
            }

            counts[gene[l]]--;

            if (counts[gene[l]] == 0)
            {
                uniqueCount--;
            }

            totalCombs++;
        }

        double answer = (double)uniqueCombs / totalCombs;
        return answer;
    }

    private class CountArray
    {
        private readonly int[] _counts = new int['z' - 'a' + 1];

        public int this[char letter]
        {
            get => _counts[letter - 'a'];
            set => _counts[letter - 'a'] = value;
        }
    }
}

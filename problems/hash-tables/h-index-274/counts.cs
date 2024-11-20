public class Solution
{
    // Time: O(n)
	// Space: O(n)
    public int HIndex(int[] citations)
    {
        int totalPapers = citations.Length;
        int[] counts = new int[totalPapers + 1];

        foreach (int citation in citations)
        {
            counts[Math.Min(citation, totalPapers)]++;
        }

        int papersCount = 0;

        for (int hIndex = totalPapers; hIndex > 0; hIndex--)
        {   
            papersCount += counts[hIndex];

            if (papersCount >= hIndex)
            {
                return hIndex;
            }
        }

        return 0;
    }
}
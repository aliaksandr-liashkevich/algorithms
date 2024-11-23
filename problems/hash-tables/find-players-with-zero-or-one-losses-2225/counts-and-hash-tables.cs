public class Solution
{
    // Time: O(n * log n)
    // Space: O(n)
    public IList<IList<int>> FindWinners(int[][] matches)
    {
        Dictionary<int, int> countsByWinner = new();
        Dictionary<int, int> countsByLoser = new();

        foreach (int[] match in matches)
        {
            int winner = match[0];
            int loser = match[1];

            countsByWinner[winner] = countsByWinner.GetValueOrDefault(winner) + 1;
            countsByLoser[loser] = countsByLoser.GetValueOrDefault(loser) + 1;
        }

        List<int> absoluteWinners = new();
        List<int> exactlyOnceLosers = new();

        foreach (KeyValuePair<int, int> countByWinner in countsByWinner)
        {
            if (!countsByLoser.ContainsKey(countByWinner.Key))
            {
                absoluteWinners.Add(countByWinner.Key);
            }
        }

        foreach (KeyValuePair<int, int> countByLoser in countsByLoser)
        {
            if (countByLoser.Value == 1)
            {
                exactlyOnceLosers.Add(countByLoser.Key);
            }
        }

        absoluteWinners.Sort();
        exactlyOnceLosers.Sort();

        return new List<IList<int>>()
        {
            { absoluteWinners },
            { exactlyOnceLosers },
        };
    }
}

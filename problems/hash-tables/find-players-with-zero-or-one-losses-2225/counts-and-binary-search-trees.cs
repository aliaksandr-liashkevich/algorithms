public class Solution
{
    // Time: O(n * log n)
    // Space: O(n)
    public IList<IList<int>> FindWinners(int[][] matches)
    {
        SortedSet<int> players = new();
        Dictionary<int, int> lossesCountsByPlayer = new();

        foreach (int[] match in matches)
        {
            int winner = match[0];
            int loser = match[1];

            players.Add(winner);
            players.Add(loser);

            if (!lossesCountsByPlayer.ContainsKey(winner))
            {
                lossesCountsByPlayer[winner] = 0;
            }

            lossesCountsByPlayer[loser] = lossesCountsByPlayer.GetValueOrDefault(loser) + 1;
        }

        List<IList<int>> answer = new List<IList<int>>(2)
        {
            new List<int>(),
            new List<int>(),
        };

        foreach (int player in players)
        {
            int lossesCount = lossesCountsByPlayer[player];

            if (lossesCount < 2)
            {
                answer[lossesCount].Add(player);
            }
        }

        return answer;
    }
}

public class Solution
{
    // n - the length of matrix n x n
    // Time: O(n^2)
    // Space: O(n^2)
    public int EqualPairs(int[][] grid)
    {
        int length = grid.Length;

        Dictionary<string, int> countsByRowKey = new();
        Dictionary<string, int> countsByColumnKey = new();

        for (int i = 0; i < length; i++)
        {
            string rowKey = ToRowKey(i);

            countsByRowKey[rowKey] = countsByRowKey.GetValueOrDefault(rowKey) + 1;

            string columnKey = ToColumnKey(i);

            countsByColumnKey[columnKey] = countsByColumnKey.GetValueOrDefault(columnKey) + 1;
        }

        int answer = 0;

        foreach (KeyValuePair<string, int> countByRowKey in countsByRowKey)
        {
            string rowKey = countByRowKey.Key;
            int rowCount = countByRowKey.Value;

            if (countsByColumnKey.TryGetValue(rowKey, out int columnCount))
            {
                answer += (rowCount * columnCount);
            }
        }

        return answer;

        string ToRowKey(int r)
        {
            StringBuilder sb = new();

            for (int c = 0; c < length; c++)
            {
                AppendCell(sb, grid[r][c]);
            }

            return sb.ToString();
        }

        string ToColumnKey(int c)
        {
            StringBuilder sb = new();

            for (int r = 0; r < length; r++)
            {
                AppendCell(sb, grid[r][c]);
            }

            return sb.ToString();
        }
    }

    private void AppendCell(StringBuilder sb, int number)
    {
        sb.Append(number);
        sb.Append(",");
    }
}

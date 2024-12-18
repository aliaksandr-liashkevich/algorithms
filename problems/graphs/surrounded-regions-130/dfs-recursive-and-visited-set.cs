public class Solution
{
    private const char CAPTURED = 'X';
    private const char REGION = 'O';

    // k - the number of 'O' region cells
    // Time: O(n * m)
    // Space: O(k)
    public void Solve(char[][] board)
    {
        int rows = board.Length;
        int columns = board[0].Length;

        HashSet<(int RowIndex, int ColumnIndex)> visitedCells = new();

        for (int c = 0; c < columns; c++)
        {
            Search(r: 0, c);
            Search(r: rows - 1, c);
        }

        for (int r = 0; r < rows; r++)
        {
            Search(r, c: 0);
            Search(r, c: columns - 1);
        }

        for (int r = 1; r < (rows - 1); r++)
        {
            for (int c = 1; c < (columns - 1); c++)
            {
                if (!IsVisited(r, c) && IsRegionCell(r, c))
                {
                    CaptureCell(r, c);
                }
            }
        }

        void Search(int r, int c)
        {
            if (!CanBeVisited(r, c))
            {
                return;
            }

            MarkAsVisited(r, c);

            Search(r + 1, c);
            Search(r, c - 1);
            Search(r - 1, c);
            Search(r, c + 1);
        }

        void CaptureCell(int r, int c)
            => board[r][c] = CAPTURED;

        void MarkAsVisited(int r, int c)
            => visitedCells.Add((r, c));

        bool CanBeVisited(int r, int c)
            => IsValidCell(r, c) && !IsVisited(r, c) && IsRegionCell(r, c);

        bool IsValidCell(int r, int c)
            => IsValidIndex(r, rows) && IsValidIndex(c, columns);

        bool IsVisited(int r, int c)
            => visitedCells.Contains((r, c));

        bool IsRegionCell(int r, int c)
            => board[r][c] == REGION;

        bool IsValidIndex(int index, int length)
            => index >= 0 && index < length;
    }
}

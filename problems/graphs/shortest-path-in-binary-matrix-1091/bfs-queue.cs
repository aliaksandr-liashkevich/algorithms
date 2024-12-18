public class Solution
{
    // Time: O(n * m)
    // Space: O(n * m)
    public int ShortestPathBinaryMatrix(int[][] grid)
    {
        int rows = grid.Length;
        int columns = grid[0].Length;

        bool[,] visited = new bool[rows, columns];

        return FindPath(initialRow: 0, initialCell: 0);

        int FindPath(int initialRow, int initialCell)
        {
            Queue<(int RowIndex, int ColumnIndex, int Path)> visitedQueue = new();
            EnqueueIfCanBeVisited(initialRow, initialCell, path: 1);

            while (visitedQueue.Count > 0)
            {
                (int r, int c, int path) = visitedQueue.Dequeue();

                if (IsEndCell(r, c))
                {
                    return path;
                }

                EnqueueIfCanBeVisited(r - 1, c - 1, path + 1);
                EnqueueIfCanBeVisited(r - 1, c, path + 1);
                EnqueueIfCanBeVisited(r - 1, c + 1, path + 1);
                EnqueueIfCanBeVisited(r, c - 1, path + 1);
                EnqueueIfCanBeVisited(r, c + 1, path + 1);
                EnqueueIfCanBeVisited(r + 1, c - 1, path + 1);
                EnqueueIfCanBeVisited(r + 1, c, path + 1);
                EnqueueIfCanBeVisited(r + 1, c + 1, path + 1);
            }

            return -1;

            void EnqueueIfCanBeVisited(int r, int c, int path)
            {
                if (!CanBeVisited(r, c))
                {
                    return;
                }

                visitedQueue.Enqueue((r, c, path));
                MarkAsVisited(r, c);
            }
        }

        bool IsEndCell(int r, int c)
            => r == (rows - 1) && c == (columns - 1);

        void MarkAsVisited(int r, int c)
            => visited[r, c] = true;

        bool CanBeVisited(int r, int c)
            => IsValidCell(r, c) && !IsVisited(r, c) && IsZero(r, c);

        bool IsValidCell(int r, int c)
            => IsValidIndex(r, rows) && IsValidIndex(c, columns);

        bool IsVisited(int r, int c)
            => visited[r, c];

        bool IsZero(int r, int c)
            => grid[r][c] == 0;

        bool IsValidIndex(int index, int length)
            => index >= 0 && index < length;
    }
}

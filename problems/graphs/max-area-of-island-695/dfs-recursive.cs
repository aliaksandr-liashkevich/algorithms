public class Solution
{
    // Time: O(n * m)
    // Space: O(n * m)
    public int MaxAreaOfIsland(int[][] grid)
    {
        int rows = grid.Length;
        int columns = grid[0].Length;

        bool[,] visited = new bool[rows, columns];

        int maxArea = 0;

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < columns; c++)
            {
                int currArea = FindArea(r, c);
                maxArea = Math.Max(maxArea, currArea);
            }
        }

        return maxArea;

        int FindArea(int r, int c)
        {
            if (!CanBeVisited(r, c))
            {
                return 0;
            }

            MarkAsVisited(r, c);

            return 1 +
                FindArea(r + 1, c) +
                FindArea(r, c - 1) +
                FindArea(r - 1, c) +
                FindArea(r, c + 1);
        }

        void MarkAsVisited(int r, int c)
            => visited[r, c] = true;

        bool CanBeVisited(int r, int c)
            => IsValidCell(r, c) && !IsVisited(r, c) && IsIsland(r, c);

        bool IsValidCell(int r, int c)
            => IsValidIndex(r, rows) && IsValidIndex(c, columns);

        bool IsVisited(int r, int c)
            => visited[r, c];

        bool IsIsland(int r, int c)
            => grid[r][c] == 1;

        bool IsValidIndex(int index, int length)
            => index >= 0 && index < length;
    }
}

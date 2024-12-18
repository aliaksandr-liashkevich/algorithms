public class Solution
{
    // Time: O(n * m)
    // Space: O(n * m)
    public int MinPathSum(int[][] grid)
    {
        int rows = grid.Length;
        int columns = grid[0].Length;

        int[,] pathes = new int[rows + 1, columns + 1];

        for (int r = 0; r <= rows; r++)
        {
            pathes[r, 0] = int.MaxValue;
        }

        for (int c = 0; c <= columns; c++)
        {
            pathes[0, c] = int.MaxValue;
        }

        pathes[1, 1] = grid[0][0];

        for (int r = 1; r <= rows; r++)
        {
            for (int c = 1; c <= columns; c++)
            {
                if (r == 1 && c == 1)
                {
                    continue;
                }

                pathes[r, c] = Math.Min(pathes[r, c - 1], pathes[r - 1, c]) + grid[r - 1][c - 1];
            }
        }

        return pathes[rows, columns];
    }
}

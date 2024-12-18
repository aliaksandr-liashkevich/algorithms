public class Solution
{
    public const int STONE = 1;

    // Time: O(n * m)
    // Space: O(n * m)
    public int UniquePathsWithObstacles(int[][] grid)
    {
        if (grid[0][0] == STONE)
        {
            return 0;
        }

        int rows = grid.Length;
        int columns = grid[0].Length;

        int[,] paths = new int[rows + 1, columns + 1];
        paths[1, 1] = 1;

        for (int r = 1; r <= rows; r++)
        {
            for (int c = 1; c <= columns; c++)
            {
                if ((r == 1 && c == 1) || grid[r - 1][c - 1] == STONE)
                {
                    continue;
                }

                paths[r, c] = paths[r, c - 1] + paths[r - 1, c];
            }
        }

        return paths[rows, columns];
    }
}

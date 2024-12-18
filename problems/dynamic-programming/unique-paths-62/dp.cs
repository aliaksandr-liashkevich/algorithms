public class Solution
{
    // Time: O(n * m)
    // Space: O(n * m)
    public int UniquePaths(int rows, int columns)
    {
        int[,] paths = new int[rows + 1, columns + 1];
        paths[1, 1] = 1;

        for (int r = 1; r <= rows; r++)
        {
            for (int c = 1; c <= columns; c++)
            {
                if (r == 1 && c == 1)
                {
                    continue;
                }

                paths[r, c] = paths[r, c - 1] + paths[r - 1, c];
            }
        }

        return paths[rows, columns];
    }
}

public class Solution
{
    // Time: O(m * n)
    // Space: O(m * n)
    public int NumIslands(char[][] grid)
    {
        int rows = grid.Length;
        int columns = grid[0].Length;

        bool[,] visited = new bool[rows, columns];

        int islands = 0;

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c <columns; c++)
            {
                if (Search(r, c))
                {
                    islands++;
                }
            }
        }

        return islands;

        bool Search(int r, int c)
        {
            if (!CanBeVisited(r, c))
            {
                return false;
            }

            MarkAsVisited(r, c);

            Search(r + 1, c);
            Search(r, c - 1);
            Search(r - 1, c);
            Search(r, c + 1);

            return true;
        }

        void MarkAsVisited(int r, int c)
            => visited[r, c] = true;

        bool CanBeVisited(int r, int c)
            => IsValidCell(r, c) && !IsVisited(r, c) && !IsWater(r, c);

        bool IsValidCell(int r, int c)
            => IsValidIndex(r, rows) && IsValidIndex(c, columns);

        bool IsVisited(int r, int c)
            => visited[r, c];

        bool IsWater(int r, int c)
            => grid[r][c] == '0';

        bool IsValidIndex(int index, int length)
            => index >= 0 && index < length;
    }
}

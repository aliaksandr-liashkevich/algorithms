public class Solution
{
    // Time: O(n * m)
    // Space: O(1)
    public int MinPathSum(int[][] grid)
    {
        PathMatrix paths = new PathMatrix(grid);

        for (int r = 0; r < paths.Rows; r++)
        {
            for (int c = 0; c < paths.Columns; c++)
            {
                if (r == 0 && c == 0)
                {
                    continue;
                }

                paths[r, c] += Math.Min(paths[r, c - 1], paths[r - 1, c]);
            }
        }

        return paths[paths.Rows - 1, paths.Columns - 1];
    }

    private class PathMatrix
    {
        private readonly int[][] _grid;

        public PathMatrix(int[][] grid)
        {
            _grid = grid;
        }

        public int Rows => _grid.Length;

        public int Columns => _grid[0].Length;

        public int this[int r, int c]
        {
            get
            {
                if (!IsValid(r, Rows) || !IsValid(c, Columns))
                {
                    return int.MaxValue;
                }

                return _grid[r][c];
            }
            set
            {
                _grid[r][c] = value;
            }
        }

        private bool IsValid(int index, int length) => index >= 0 && index < length;
    }
}

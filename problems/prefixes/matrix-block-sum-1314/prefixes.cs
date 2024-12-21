public class Solution
{
    // Time: O(r * c)
    // Space: O(r * c)
    public int[][] MatrixBlockSum(int[][] mat, int k)
    {
        SumMatrix sumMatrix = new SumMatrix(mat);
        int rows = sumMatrix.Rows;
        int columns = sumMatrix.Columns;

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < columns; c++)
            {
                int minusRowK = GetIndexOrDefault(r - k, rows, def: 0);
                int minusColumnK = GetIndexOrDefault(c - k, columns, def: 0);
                int plusRowK = GetIndexOrDefault(r + k, rows, def: rows - 1);
                int plusColumnK = GetIndexOrDefault(c + k, columns, def: columns - 1);

                mat[r][c] = sumMatrix.SumRegion(
                    minusRowK,
                    minusColumnK,
                    plusRowK,
                    plusColumnK
                );
            }
        }

        return mat;
    }

    private static bool IsValidIndex(int index, int length)
        => index >= 0 && index < length;

    private static int GetIndexOrDefault(int index, int length, int def = 0)
        => IsValidIndex(index, length) ? index : def;

    private class SumMatrix
    {
        private readonly int[,] _sumMatrix;

        public SumMatrix(int[][] matrix)
        {
            Rows = matrix.Length;
            Columns = matrix.Length > 0 ? matrix[0].Length : 0;
            _sumMatrix = new int[Rows, Columns];

            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Columns; c++)
                {
                    this[r, c] = matrix[r][c] +
                        this[r, c - 1] +
                        this[r - 1, c] -
                        this[r - 1, c - 1];
                }
            }
        }

        public int Rows { get; set; }

        public int Columns { get; set; }

        public int this[int row, int column]
        {
            get
            {
                if (!IsValidIndex(row, Rows) || !IsValidIndex(column, Columns))
                {
                    return 0;
                }

                return _sumMatrix[row, column];
            }
            set => _sumMatrix[row, column] = value;
        }

        public int SumRegion(int r1, int c1, int r2, int c2)
        {
            return this[r2, c2] + this[r1 - 1, c1 - 1] - this[r2, c1 - 1] - this[r1 - 1, c2];
        }
    }
}

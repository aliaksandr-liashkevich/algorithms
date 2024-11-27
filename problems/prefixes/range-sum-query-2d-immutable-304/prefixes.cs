public class NumMatrix
{
    private readonly PrefixSumMatrix _sumMatrix;

    // r - the number of rows
    // n - the number of columns
    // Time: O(r * c)
    // Space: O(r * c)
    public NumMatrix(int[][] matrix)
    {
        int rows = matrix.Length;
        int columns = matrix[0].Length;

        _sumMatrix = new PrefixSumMatrix(rows, columns);

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < columns; c++)
            {
                _sumMatrix[r, c] = matrix[r][c] + _sumMatrix[r, c - 1] + _sumMatrix[r - 1, c] - _sumMatrix[r - 1, c - 1];
            }
        }
    }

    // Time: O(1)
    // Space: O(1)
    public int SumRegion(int r1, int c1, int r2, int c2)
    {
        return _sumMatrix[r2, c2] + _sumMatrix[r1 - 1, c1 - 1] - _sumMatrix[r2, c1 - 1] - _sumMatrix[r1 - 1, c2];
    }

    private class PrefixSumMatrix
    {
        private int[,] _prefixSums;

        public PrefixSumMatrix(int rows, int columns)
        {
            _prefixSums = new int[rows + 1, columns + 1];
        }

        public int this[int r, int c]
        {
            get => _prefixSums[r + 1, c + 1];
            set => _prefixSums[r + 1, c + 1] = value;
        }
    }
}

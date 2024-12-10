public class Solution
{
    // Time: O(log(m * n))
    // Space: O(1)
    public bool SearchMatrix(int[][] matrix, int target)
    {
        if (matrix.Length == 0)
        {
            return false;
        }

        Matrix1D matrix1D = new Matrix1D(matrix);

        int l = 0;
        int r = matrix1D.Rows * matrix1D.Columns;

        while (r - l > 1)
        {
            int m = l + (r - l) / 2;

            if (IsGood(m))
            {
                l = m;
            }
            else
            {
                r = m;
            }
        }

        return matrix1D[l] == target;

        bool IsGood(int i) => matrix1D[i] <= target;
    }

    private class Matrix1D
    {
        private readonly int[][] _matrix2D;

        public Matrix1D(int[][] matrix2D)
        {
            _matrix2D = matrix2D;
        }

        public int Rows => _matrix2D.Length;

        public int Columns => _matrix2D[0].Length;

        public int this[int index]
        {
            get
            {
                int r = index / Columns;
                int c = index % Columns;
                return _matrix2D[r][c];
            }
        }
    }
}

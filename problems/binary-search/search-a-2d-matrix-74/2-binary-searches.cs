public class Solution
{
    // Time: O(log(n)) + O(log(m)) ~ O(log(n * m))
    // Space: O(1)
    public bool SearchMatrix(int[][] matrix, int target)
    {
        if (matrix.Length == 0)
        {
            return false;
        }

        int rows = matrix.Length;
        int columns = matrix[0].Length;

        int r = FindMidRowIndex(columnIndex: 0);
        int c = FindMidColumnIndex(r);

        return matrix[r][c] == target;

        int FindMidRowIndex(int columnIndex)
        {
            int l = 0;
            int r = rows;

            while (r - l > 1)
            {
                int m = l + (r - l) / 2;

                if (IsGood(m, columnIndex))
                {
                    l = m;
                }
                else
                {
                    r = m;
                }
            }

            return l;
        }

        int FindMidColumnIndex(int rowIndex)
        {
            int l = 0;
            int r = columns;

            while (r - l > 1)
            {
                int m = l + (r - l) / 2;

                if (IsGood(rowIndex, m))
                {
                    l = m;
                }
                else
                {
                    r = m;
                }
            }

            return l;
        }

        bool IsGood(int r, int c) => matrix[r][c] <= target;
    }
}

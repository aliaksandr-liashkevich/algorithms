// IList<IList<int>> board = new List<IList<int>>()
// {
//     new List<int>() { 3, 2, 5, 1 },
//     new List<int>() { 4, 9, 1, 3 },
//     new List<int>() { 2, 9, 2, 1 },
// };

// int result = new Solution().MaxQueenSum(board);
// bool isPassed = result == 40;

public class Solution
{
    // r - the number of rows
    // c - the number of columns
    // Time: O(r * c)
    // Space: O(r) + O(c) + O(2 * (r + c - 1)) ~ O(r + c)
    public int MaxQueenSum(IList<IList<int>> board)
    {
        int rows = board.Count;
        int columns = board[0].Count;

        int lastRow = rows - 1;

        int[] rowSums = new int[rows];
        int[] columnSums = new int[columns];
        int[] leftRightDiagonalSums = new int[rows + columns - 1];
        int[] rightLeftDiagonalSums = new int[rows + columns - 1];

        // O(r * c)
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < columns; c++)
            {
                int cell = board[r][c];

                rowSums[r] += cell;
                columnSums[c] += cell;

                leftRightDiagonalSums[(lastRow - r) + c] += cell;
                rightLeftDiagonalSums[r + c] += cell;
            }
        }

        int maxSum = 0;

        // O(r * c)
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < columns; c++)
            {
                int currSum = rowSums[r] + columnSums[c];
                currSum += (leftRightDiagonalSums[(lastRow - r) + c] + rightLeftDiagonalSums[r + c]);
                currSum -= (3 * board[r][c]);

                if (r == 0 && c == 0)
                {
                    maxSum = currSum;
                }
                else
                {
                    maxSum = Math.Max(maxSum, currSum);
                }
            }
        }

        return maxSum;
    }
}

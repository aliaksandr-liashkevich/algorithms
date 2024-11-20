public class Solution
{
    // Time: O(1)
    // Space: O(1)
    public bool IsValidSudoku(char[][] board)
    {
        int length = board.Length;

        int[] rowKeys = new int[length];
        int[] columnKeys = new int[length];
        int[] squareKeys = new int[length];

        for (int r = 0; r < length; r++)
        {
            for (int c = 0; c < length; c++)
            {
                char digit = board[r][c];

                if (IsDot(digit))
                {
                    continue;
                }

                int key = ToKey(digit);

                if (!AddKey(rowKeys, r, key))
                {
                    return false;
                }

                if (!AddKey(columnKeys, c, key))
                {
                    return false;
                }

                if (!AddKey(squareKeys, GetSquareIndex(r, c), key))
                {
                    return false;
                }
            }
        }

        return true;
    }

    private int ToKey(char digit) => 1 << (digit - '0');

    private bool AddKey(int[] keys, int index, int key)
    {
        bool keyExists = (keys[index] & key) != 0;

        if (keyExists)
        {
            return false;
        }

        keys[index] |= key;
        return true;
    }

    private bool IsDot(char @char) => @char == '.';

    private int GetSquareIndex(int row, int column)
    {
        int rowIndex = row / 3;
        int columnIndex = column / 3;
        return rowIndex * 3 + columnIndex;
    }
}
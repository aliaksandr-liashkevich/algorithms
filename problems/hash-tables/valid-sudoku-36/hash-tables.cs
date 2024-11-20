public class Solution {
    // Time: O(1)
    // Space: O(1)
    public bool IsValidSudoku(char[][] board) {
        int length = board.Length;

        HashSet<(KeyType Type, int Index, char Digit)> keys = new();

        for (int r = 0; r < length; r++)
        {
            for (int c = 0; c < length; c++)
            {
                char digit = board[r][c];

                if (IsDot(digit))
                {
                    continue;
                }

                if (!keys.Add(ToRowKey(r, digit)))
                {
                    return false;
                }

                if (!keys.Add(ToColumnKey(c, digit)))
                {
                    return false;
                }

                if (!keys.Add(ToSquareKey(r, c, digit)))
                {
                    return false;
                }
            }
        }

        return true;
    }

    private bool IsDot(char @char) => @char == '.';

    private (KeyType Type, int Index, char Digit) ToRowKey(int row, char digit)
        => (KeyType.Row, row, digit);

    private (KeyType Type, int Index, char Digit) ToColumnKey(int column, char digit)
        => (KeyType.Column, column, digit);

    private (KeyType Type, int Index, char Digit) ToSquareKey(int row, int column, char digit)
    {
        int rowIndex = row / 3;
        int columnIndex = column / 3;
        int index = rowIndex * 3 + columnIndex;

        return (KeyType.Square, index, digit);
    }

    enum KeyType
    {
        Row = 0,
        Column = 1,
        Square = 2,
    }
}
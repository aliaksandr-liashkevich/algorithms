public class Solution
{
    // Time: O(n * m)
    // Space: O(n * m) + O(n * m) ~ O(n * m)
    public int[] FindDiagonalOrder(int[][] mat)
    {
        if (mat.Length == 0)
        {
            return [];
        }

        int rows = mat.Length;
        int columns = mat[0].Length;
        int diagonals = rows + columns - 1;

        Dictionary<int, LinkedList<int>> diagonalListsByIndex = new();

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < columns; c++)
            {
                int diagonalIndex = r + c;

                if (!diagonalListsByIndex.TryGetValue(diagonalIndex, out LinkedList<int> diagonalList))
                {
                    diagonalList = new LinkedList<int>();
                    diagonalListsByIndex[diagonalIndex] = diagonalList;
                }

                bool isLeftToRightDiagonal = (diagonalIndex & 1) == 0;

                if (isLeftToRightDiagonal)
                {
                    diagonalList.AddFirst(mat[r][c]);
                }
                else
                {
                    diagonalList.AddLast(mat[r][c]);
                }
            }
        }

        int[] answer = new int[rows * columns];
        int answerIndex = 0;

        for (int diagonalIndex = 0; diagonalIndex < diagonals; diagonalIndex++)
        {
            foreach (int num in diagonalListsByIndex[diagonalIndex])
            {
                answer[answerIndex] = num;
                answerIndex++;
            }
        }

        return answer;
    }
}

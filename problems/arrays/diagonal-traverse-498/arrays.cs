public class Solution
{
    // Time: O(n * m)
    // Space: O(n * m)
    public int[] FindDiagonalOrder(int[][] mat)
    {
        if (mat.Length == 0)
        {
            return [];
        }

        int rows = mat.Length;
        int columns = mat[0].Length;

        int r = 0;
        int c = 0;
        int d = 1;

        int[] answer = new int[rows * columns];

        for (int i = 0; i < answer.Length; i++)
        {
            answer[i] = mat[r][c];
            r -= d;
            c += d;

            if (c >= columns)
            {
                r += 2;
                c = columns - 1;
                d = -d;
            }

            if (r < 0)
            {
                r += 1;
                d = -d;
            }

            if (r >= rows)
            {
                r = rows - 1;
                c += 2;
                d = -d;
            }

            if (c < 0)
            {
                c += 1;
                d = -d;
            }
        }

        return answer;
    }
}

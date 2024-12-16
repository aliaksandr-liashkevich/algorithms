public class Solution
{
    // n - the length of the square matrix
    // Time: O(n)
    // Space: O(1)
    public int DiagonalSum(int[][] mat)
    {
        int lastIndex = mat.Length - 1;
        int sum = 0;

        for (int leftToRightIndex = 0; leftToRightIndex <= lastIndex; leftToRightIndex++)
        {
            int rightToLeftIndex = lastIndex - leftToRightIndex;

            sum += mat[leftToRightIndex][leftToRightIndex];

            if (leftToRightIndex != rightToLeftIndex)
            {
                sum += mat[leftToRightIndex][rightToLeftIndex];
            }
        }

        return sum;
    }
}

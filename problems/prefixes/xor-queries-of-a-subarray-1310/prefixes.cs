public class Solution
{
    // Time: O(n) + O(q) ~ O(n + q)
    // Space: O(n)
    public int[] XorQueries(int[] nums, int[][] queries)
    {
        int[] pxXors = new int[nums.Length + 1];

        int pxIndex = 1;

        // O(n)
        foreach (int num in nums)
        {
            pxXors[pxIndex] = (pxXors[pxIndex - 1] ^ num);
            pxIndex++;
        }

        int[] answers = new int[queries.Length];

        // O(q)
        for (int index = 0; index < answers.Length; index++)
        {
            int l = queries[index][0];
            int r = queries[index][1];

            answers[index] = pxXors[r + 1] ^ pxXors[l];
        }

        return answers;
    }
}

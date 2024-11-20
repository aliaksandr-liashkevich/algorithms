public class Solution
{
    // Time: O(n^2)
    // Space: O(n)
    public int[] FindThePrefixCommonArray(int[] a, int[] b)
    {
        int length = a.Length;

        if (a.Length != b.Length)
        {
            return [];
        }

        bool[] aSet = new bool[length];
        bool[] bSet = new bool[length];

        int[] answer = new int[length];

        for (int i = 0; i < length; i++)
        {
            aSet[a[i] - 1] = true;
            bSet[b[i] - 1] = true;

            int commonCount = 0;

            for (int j = 0; j < length; j++)
            {
                if (aSet[j] && bSet[j])
                {
                    commonCount++;
                }
            }

            answer[i] = commonCount;
        }

        return answer;
    }
}
public class Solution
{
    // Time: O(n)
    // Space: O(n)
    public int[] FindThePrefixCommonArray(int[] a, int[] b)
    {
        int length = a.Length;

        if (a.Length != b.Length)
        {
            return [];
        }

        int[] frequencies = new int[length];

        int[] answer = new int[length];
        int commonCount = 0;

        for (int i = 0; i < length; i++)
        {
            int aNum = a[i] - 1;
            int bNum = b[i] - 1;

            frequencies[aNum]++;
            frequencies[bNum]++;

            if (aNum == bNum)
            {
                commonCount++;
            }
            else
            {
                if (frequencies[aNum] == 2)
                {
                    commonCount++;
                }

                if (frequencies[bNum] == 2)
                {
                    commonCount++;
                }
            }

            answer[i] = commonCount;
        }

        return answer;
    }
}
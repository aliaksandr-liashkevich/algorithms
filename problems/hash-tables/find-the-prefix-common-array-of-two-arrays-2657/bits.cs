public class Solution
{
    // Time: O(n)
    // Space: O(1)
    public int[] FindThePrefixCommonArray(int[] a, int[] b)
    {
        int length = a.Length;

        if (a.Length != b.Length)
        {
            return [];
        }

        ulong aSet = 0;
        ulong bSet = 0;

        int[] answer = new int[length];

        for (int i = 0; i < length; i++)
        {
            aSet |= (1UL << (a[i] - 1));
            bSet |= (1UL << (b[i] - 1));

            ulong intersectionSet = aSet & bSet;

            int commonCount = 0;

            while (intersectionSet != 0)
            {
                commonCount++;
                intersectionSet &= (intersectionSet - 1);
            }

            answer[i] = commonCount;
        }

        return answer;
    }
}
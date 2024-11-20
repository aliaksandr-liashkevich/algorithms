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

        HashSet<int> unionSet = new(length);

        int[] answer = new int[length];
        int commonCount = 0;

        for (int i = 0; i < length; i++)
        {
            if (!unionSet.Add(a[i]))
            {
                commonCount++;
            }

            if (!unionSet.Add(b[i]))
            {
                commonCount++;
            }

            answer[i] = commonCount;
        }

        return answer;
    }
}
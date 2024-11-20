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

        HashSet<int> aSet = new(length);
        HashSet<int> bSet = new(length);

        int[] answer = new int[length];

        for (int i = 0; i < length; i++)
        {
            aSet.Add(a[i]);
            bSet.Add(b[i]);

            // Best Time: O(n)
            // Worst Time: O(n^2) - in case of collisions -> Time: O(n^3)
            answer[i] = aSet.Intersect(bSet).Count();
        }

        return answer;
    }
}
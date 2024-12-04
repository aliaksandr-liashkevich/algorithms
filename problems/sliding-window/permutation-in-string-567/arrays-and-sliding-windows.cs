public class Solution
{
    // Time: O(n)
    // Space: O(unique(n)) ~ O(1)
    public bool CheckInclusion(string s1, string s2)
    {
        int[] countsByS1Letter = new int['z' + 'a' - 1];

        for (int s1Index = 0; s1Index < s1.Length; s1Index++)
        {
            countsByS1Letter[GetCountIndex(s1, s1Index)]++;
        }

        int[] countsByWindowLetter = new int['z' + 'a' - 1];

        int l = 0;
        int r = -1;

        while (l < s2.Length)
        {
            while ((r + 1) < s2.Length &&
                countsByWindowLetter[GetCountIndex(s2, r + 1)] < countsByS1Letter[GetCountIndex(s2, r + 1)])
            {
                r++;
                countsByWindowLetter[GetCountIndex(s2, r)]++;
            }

            if ((r - l + 1) == s1.Length)
            {
                return true;
            }

            countsByWindowLetter[GetCountIndex(s2, l)]--;
            l++;
        }

        return false;

        int GetCountIndex(string str, int index) => str[index] - 'a';
    }
}

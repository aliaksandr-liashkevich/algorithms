public class Solution
{
    // Time: O(n)
    // Space: O(1)
    public bool CanPermutePalindrome(string s)
    {
        int[] counts = new int['z' - 'a' + 1];

        foreach (char letter in s)
        {
            counts[letter - 'a']++;
        }

        int oddCount = 0;

        foreach (char count in counts)
        {
            bool isOdd = (count & 1) == 1;

            if (isOdd)
            {
                oddCount++;
            }
        }

        return oddCount <= 1;
    }
}
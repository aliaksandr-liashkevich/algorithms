public class Solution
{
    // Time: O(n)
    // Space: O(1)
    public bool CanPermutePalindrome(string s)
    {
        bool[] oddLetters = new bool['z' - 'a' + 1];

        foreach (char letter in s)
        {
            oddLetters[letter - 'a'] = !oddLetters[letter - 'a'];
        }

        return oddLetters.Count(isOdd => isOdd) <= 1;
    }
}
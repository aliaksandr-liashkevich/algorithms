public class Solution
{
    // Time: O(n)
    // Space: O(1)
    public bool IsPalindrome(string s)
    {
        int l = 0;
        int r = s.Length - 1;

        while (r > l)
        {
            if (!IsLetterOrDigit(s[l]))
            {
                l++;
                continue;
            }

            if (!IsLetterOrDigit(s[r]))
            {
                r--;
                continue;
            }

            if (ToLowerCase(s[l]) != ToLowerCase(s[r]))
            {
                return false;
            }

            l++;
            r--;
        }

        return true;
    }

    private bool IsLetterOrDigit(char symbol)
        => (symbol >= 'a' && symbol <= 'z') || (symbol >= 'A' && symbol <= 'Z') ||
            (symbol >= '0' && symbol <= '9');

    private char ToLowerCase(char letter)
    {
        if (letter >= 'A' && letter <= 'Z')
        {
            return (char)(letter - ('A' - 'a'));
        }

        return letter;
    }
}

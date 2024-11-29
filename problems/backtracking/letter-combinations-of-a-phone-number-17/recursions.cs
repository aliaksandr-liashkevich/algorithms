public class Solution
{
    // Time: O(n * 4^n)
    // Space: O(n * 4^n)
    public IList<string> LetterCombinations(string digits)
    {
        int length = digits.Length;

        if (length == 0)
        {
            return new List<string>();
        }

        string[] lettersByDigit = new string[]
        {
            "abc",
            "def",
            "ghi",
            "jkl",
            "mno",
            "pqrs",
            "tuv",
            "wxyz"
        };

        List<string> answer = new();
        Bruteforce(new char[length], 0);
        return answer;

        void Bruteforce(char[] buffer, int bufferIndex)
        {
            if (bufferIndex == length)
            {
                answer.Add(new string(buffer));
                return;
            }

            foreach (char letter in lettersByDigit[digits[bufferIndex] - '2'])
            {
                buffer[bufferIndex] = letter;

                Bruteforce(buffer, bufferIndex + 1);
            }
        }
    }
}

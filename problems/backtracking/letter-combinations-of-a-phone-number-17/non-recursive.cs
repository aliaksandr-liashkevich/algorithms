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

        Queue<char[]> combQueue = new();

        foreach (char letter in GetLetters(0))
        {
            combQueue.Enqueue([letter]);
        }

        while (combQueue.Peek().Length != length)
        {
            char[] currComb = combQueue.Dequeue();
            int currLength = currComb.Length;

            foreach (char letter in GetLetters(currLength))
            {
                char[] newComb = new char[currLength + 1];
                Array.Copy(currComb, newComb, currLength);
                newComb[currLength] = letter;

                combQueue.Enqueue(newComb);
            }
        }

        return combQueue.Select(comb => new string(comb)).ToList();

        string GetLetters(int digitIndex) => lettersByDigit[digits[digitIndex] - '2'];
    }
}

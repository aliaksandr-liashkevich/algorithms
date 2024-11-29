public class Solution
{
    // Time: O(n * 4^n)
    // Space: O(n * 4^n)
    public IList<string> LetterCombinations(string digits)
    {
        int totalDigits = digits.Length;

        if (totalDigits == 0)
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

        // O(n)
        int totalCombinations = GetTotalCombinations();

        char[][] allCombinations = new char[totalCombinations][];

        // O(4^n)
        for (int combIndex = 0; combIndex < totalCombinations; combIndex++)
        {
            allCombinations[combIndex] = new char[totalDigits];
        }

        int cyclesPerLetter = totalCombinations;

        // O(n * 4^n)
        for (int digitIndex = 0; digitIndex < totalDigits; digitIndex++)
        {
            string letters = GetLetters(digitIndex);
            cyclesPerLetter /= letters.Length;

            int combIndex = 0;
            int letterIndex = 0;

            while (combIndex < totalCombinations)
            {
                allCombinations[combIndex][digitIndex] = letters[letterIndex];
                combIndex++;

                bool isLetterCycleFinished = combIndex % cyclesPerLetter == 0;

                if (isLetterCycleFinished)
                {
                    letterIndex = (letterIndex + 1) % letters.Length;
                }
            }
        }

        return allCombinations.Select(comb => new string(comb)).ToList();

        int GetTotalCombinations()
        {
            int totalCombinations = 1;

            for (int digitIndex = 0; digitIndex < totalDigits; digitIndex++)
            {
                totalCombinations *= GetLetters(digitIndex).Length;
            }

            return totalCombinations;
        }

        string GetLetters(int digitIndex) => lettersByDigit[digits[digitIndex] - '2'];
    }
}

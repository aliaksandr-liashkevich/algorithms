public class Solution
{
    // Time: O(n)
    // Space: O(1)
    public int Compress(char[] chars)
    {
        if (chars.Length == 0)
        {
            return 0;
        }

        int l = 0;
        int r = 0;

        int compressedIndex = 0;

        while (l < chars.Length)
        {
            while ((r + 1) < chars.Length && chars[r] == chars[r + 1])
            {
                r++;
            }

            int windowSize = r - l + 1;

            Compress(chars[r]);

            if (windowSize > 1)
            {
                List<char> digits = new();
                int digitSequence = windowSize;

                while (digitSequence > 0)
                {
                    digits.Add((char)((digitSequence % 10) + '0'));
                    digitSequence /= 10;
                }

                digits.Reverse();

                foreach (char digit in digits)
                {
                    Compress(digit);
                }
            }

            r++;
            l = r;
        }

        return compressedIndex;

        void Compress(char symbol)
        {
            chars[compressedIndex] = symbol;
            compressedIndex++;
        }
    }
}

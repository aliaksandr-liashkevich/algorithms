public class Solution
{
    private const char OPEN_BRACKET = '[';
    private const char CLOSE_BRACKET = ']';

    // k - the max. number of repetitions
    // d - the nesting depth
    // m - the length of base string
    // Time: O(k^d * m)
    // Space: O(k^d * m)
    public string DecodeString(string s)
    {
        int digits = 0;
        StringBuilder currBuilder = new();
        Stack<(StringBuilder Builder, int Repetitions)> stack = new();

        int i = 0;

        foreach (char symbol in s)
        {
            if (IsDigit(symbol))
            {
                digits = digits * 10 + (symbol - '0');
            }
            else if (symbol == OPEN_BRACKET)
            {
                stack.Push((currBuilder, digits));
                digits = 0;
                currBuilder = new StringBuilder();
            }
            else if (symbol == CLOSE_BRACKET)
            {
                (StringBuilder prevBuilder, int repetitions) = stack.Pop();

                while (repetitions > 0)
                {
                    prevBuilder.Append(currBuilder);
                    repetitions--;
                }

                currBuilder = prevBuilder;
            }
            else
            {
                currBuilder.Append(symbol);
            }
        }

        return currBuilder.ToString();

        bool IsDigit(char symbol) => symbol >= '0' && symbol <= '9';
    }
}

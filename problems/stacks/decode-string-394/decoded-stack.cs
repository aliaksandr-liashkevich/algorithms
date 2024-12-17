public class Solution
{
    private const char OPEN_BRACKET = '[';
    private const char CLOSE_BRACKET = ']';

    // TODO: Time & Space
    public string DecodeString(string s)
    {
        int digits = 0;
        StringBuilder builder = new();
        Stack<(StringBuilder DecodedBuilder, int Repetitions)> stack = new();

        int i = 0;

        foreach (char symbol in s)
        {
            if (IsDigit(symbol))
            {
                digits = digits * 10 + (symbol - '0');
            }
            else if (symbol == OPEN_BRACKET)
            {
                stack.Push((builder, digits));
                digits = 0;
                builder = new StringBuilder();
            }
            else if (symbol == CLOSE_BRACKET)
            {
                (StringBuilder decodedBuilder, int repetitions) = stack.Pop();

                while (repetitions > 0)
                {
                    decodedBuilder.Append(builder);
                    repetitions--;
                }

                builder = decodedBuilder;
            }
            else
            {
                builder.Append(symbol);
            }
        }

        return builder.ToString();

        bool IsDigit(char symbol) => symbol >= '0' && symbol <= '9';
    }
}

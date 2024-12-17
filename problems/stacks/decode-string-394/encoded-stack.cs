public class Solution
{
    private const char OPEN_BRACKET = '[';
    private const char CLOSE_BRACKET = ']';

    // TODO: Time & Space
    public string DecodeString(string s)
    {
        int digits = 0;
        Stack<(StringBuilder Builder, int Repetitions)> stack = new();
        stack.Push((new StringBuilder(), Repetitions: 0));

        int i = 0;

        foreach (char symbol in s)
        {
            if (IsDigit(symbol))
            {
                digits = digits * 10 + (symbol - '0');
            }
            else if (symbol == OPEN_BRACKET)
            {
                stack.Push((new StringBuilder(), digits));
                digits = 0;
            }
            else if (symbol == CLOSE_BRACKET)
            {
                (StringBuilder encodedBuilder, int repetitions) = stack.Pop();
                StringBuilder decodedBuilder = stack.Peek().Builder;

                while (repetitions > 0)
                {
                    decodedBuilder.Append(encodedBuilder);
                    repetitions--;
                }
            }
            else
            {
                StringBuilder builder = stack.Peek().Builder;
                builder.Append(symbol);
            }
        }

        StringBuilder resultBuilder = stack.Pop().Builder;
        return resultBuilder.ToString();

        bool IsDigit(char symbol) => symbol >= '0' && symbol <= '9';
    }
}

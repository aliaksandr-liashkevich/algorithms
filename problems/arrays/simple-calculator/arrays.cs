// bool isPassed = new Solution().Calculate("2*3*1+2+2+2*0*13+1") == 11;
// isPassed = new Solution().Calculate("1+2+3") == 6;

public class Solution
{
    public int Calculate(string s)
    {
        char sign = '+';
        int prev = 0;
        int curr = 0;

        int result = 0;

        for (int i = 0; i < s.Length; i++)
        {
            char symbol = s[i];

            if (IsDigit(symbol))
            {
                curr = BuildNumber(curr, symbol);
            }

            if (IsSign(symbol) || IsEnd(i))
            {
                if (sign == '*')
                {
                    prev *= curr;
                }
                else if (sign == '+')
                {
                    result += prev;
                    prev = curr;
                }

                sign = symbol;
                curr = 0;

                if (IsEnd(i))
                {
                    result += prev;
                }
            }
        }

        return result;

        int BuildNumber(int num, char digit) => num * 10 + (digit - '0');

        bool IsDigit(char symbol) => symbol >= '0' && symbol <= '9';

        bool IsSign(char symbol) => symbol == '*' || symbol == '+';

        bool IsEnd(int i) => i == (s.Length - 1);
    }
}

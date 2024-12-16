// https://www.interviewbit.com/problems/balanced-parantheses/

class Solution
{
    // Time: O(n)
    // Space: O(1)
    public int solve(string brackets)
    {
        if (brackets.Length == 0)
        {
            return ToAnswer(true);
        }

        bool hasBalancedLength = (brackets.Length & 1) == 0;

        if (!hasBalancedLength)
        {
            return ToAnswer(false);
        }

        int balance = 0;

        foreach (char bracket in brackets)
        {
            balance += (bracket == '(' ? +1 : -1);

            if (balance < 0 || balance > (brackets.Length / 2))
            {
                return ToAnswer(false);
            }
        }

        return ToAnswer(balance == 0);

        int ToAnswer(bool result) => result ? 1 : 0;
    }
}

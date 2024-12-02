public class Solution
{
    // Time: O(2^n)
    // Space: O(2^n)
    public IList<string> GenerateParenthesis(int n)
    {
        int totalBrackets = n * 2;
        int totalCombs = (int)Math.Pow(2, totalBrackets) - 1;

        List<string> allBracketCombs = new();

        for (int comb = 1; comb <= totalCombs; comb++)
        {
            if (IsBalanced(comb))
            {
                allBracketCombs.Add(ToBracketComb(comb));
            }
        }

        return allBracketCombs;

        string ToBracketComb(int comb)
        {
            StringBuilder sb = new();

            while (comb > 0)
            {
                sb.Append((comb & 1) == 0 ? '(' : ')');
                comb >>= 1;
            }

            return sb.ToString();
        }

        bool IsBalanced(int comb)
        {
            int balance = 0;
            int brackets = 0;

            while (comb > 0)
            {
                balance += ((comb & 1) == 0 ? 1 : -1);

                if (balance < 0 || balance > n)
                {
                    return false;
                }

                comb >>= 1;
                brackets++;
            }

            return balance == 0 && brackets == totalBrackets;
        }
    }
}

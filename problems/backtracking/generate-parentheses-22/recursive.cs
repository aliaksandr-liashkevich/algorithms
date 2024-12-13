public class Solution
{
    // Time: O(2^n)
    // Space: O(2^n)
    public IList<string> GenerateParenthesis(int n)
    {
        int totalBrackets = n * 2;

        (char Bracket, int Balance)[] brackets =
        {
            ('(', +1),
            (')', -1),
        };

        List<string> allCombs = new();

        Bruteforce(currComb: new List<char>(totalBrackets), balance: 0);

        return allCombs;

        void Bruteforce(List<char> currComb, int balance)
        {
            // balance < 0 || balance > n || currComb.Count > totalBrackets
            if (balance < 0 || balance > (totalBrackets - currComb.Count))
            {
                return;
            }

            if (balance == 0 && currComb.Count == totalBrackets)
            {
                allCombs.Add(new string(currComb.ToArray()));
                return;
            }

            foreach ((char bracket, int bracketBalance) in brackets)
            {
                currComb.Add(bracket);

                Bruteforce(currComb, balance + bracketBalance);

                currComb.RemoveAt(currComb.Count - 1);
            }
        }
    }
}

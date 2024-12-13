public class Solution
{
    // Time: O(2^n)
    // Space: O(2^n)
    public IList<string> GenerateParenthesis(int n)
    {
        int totalBrackets = n * 2;

        Queue<(string Brackets, int Balance)> bracketQueue = new();
        bracketQueue.Enqueue(("", 0));

        while (bracketQueue.Peek().Brackets.Length < totalBrackets)
        {
            (string brackets, int currBalance) = bracketQueue.Dequeue();

            int openBalance = currBalance + 1;

            if (openBalance <= (totalBrackets - brackets.Length))
            {
                bracketQueue.Enqueue((brackets + "(", openBalance));
            }

            int closedBalance = currBalance - 1;

            if (closedBalance >= 0)
            {
                bracketQueue.Enqueue((brackets + ")", closedBalance));
            }
        }

        List<string> answer = new(bracketQueue.Count);

        while (bracketQueue.Count > 0)
        {
            answer.Add(bracketQueue.Dequeue().Brackets);
        }

        return answer;
    }
}

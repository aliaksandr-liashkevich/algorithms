public class Solution
{
    // Time: O(n)
    // Space: O(n/2) ~ O(n)
    public bool IsValid(string s)
    {
        bool hasBalancedLength = (s.Length & 1) == 0;

        if (!hasBalancedLength)
        {
            return false;
        }

        Dictionary<char, char> closedBracketsByOpenBracket = new()
        {
            { '(', ')' },
            { '{', '}' },
            { '[', ']' }
        };

        Stack<char> openBracketStack = new();

        foreach (char bracket in s)
        {
            if (closedBracketsByOpenBracket.ContainsKey(bracket))
            {
                if (openBracketStack.Count == (s.Length / 2))
                {
                    return false;
                }

                openBracketStack.Push(bracket);
            }
            else
            {
                if (openBracketStack.Count == 0 ||
                    bracket != closedBracketsByOpenBracket[openBracketStack.Pop()])
                {
                    return false;
                }
            }
        }

        return openBracketStack.Count == 0;
    }
}

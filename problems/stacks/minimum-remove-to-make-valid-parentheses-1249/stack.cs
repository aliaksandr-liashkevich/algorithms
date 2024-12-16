public class Solution
{
    private const char DELETE_CHAR = '*';

    // Time: O(n)
    // Space: O(n)
    public string MinRemoveToMakeValid(string s)
    {
        char[] result = s.ToCharArray();

        Stack<int> openBracketIndexStack = new();

        for (int index = 0; index < result.Length; index++)
        {
            char symbol = result[index];

            if (symbol == '(')
            {
                openBracketIndexStack.Push(index);
            }
            else if (symbol == ')')
            {
                if (openBracketIndexStack.Count == 0)
                {
                    result[index] = DELETE_CHAR;
                }
                else
                {
                    openBracketIndexStack.Pop();
                }
            }
        }

        while (openBracketIndexStack.Count > 0)
        {
            result[openBracketIndexStack.Pop()] = DELETE_CHAR;
        }

        return string.Concat(result.Where(c => c != DELETE_CHAR));
    }
}

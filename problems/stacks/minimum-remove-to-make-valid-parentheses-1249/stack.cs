public class Solution
{
    private const char DELETION_MARKER = '*';

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
                    result[index] = DELETION_MARKER;
                }
                else
                {
                    openBracketIndexStack.Pop();
                }
            }
        }

        while (openBracketIndexStack.Count > 0)
        {
            result[openBracketIndexStack.Pop()] = DELETION_MARKER;
        }

        return string.Concat(result.Where(c => c != DELETION_MARKER));
    }
}

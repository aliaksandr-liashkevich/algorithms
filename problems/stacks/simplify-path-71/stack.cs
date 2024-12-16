public class Solution
{
    private const char SLASH = '/';

    // Time: O(n)
    // Space: O(n)
    public string SimplifyPath(string path)
    {
        Stack<string> fileStack = new();
        string[] segments = path.Split(SLASH);

        foreach (string segment in segments)
        {
            if (segment.Length == 0 || segment == ".")
            {
                continue;
            }

            if (segment == "..")
            {
                if (fileStack.Count > 0)
                {
                    fileStack.Pop();
                }
            }
            else
            {
                fileStack.Push(segment);
            }
        }

        if (fileStack.Count == 0)
        {
            return $"{SLASH}";
        }
        else
        {
            StringBuilder resultBuilder = new();

            foreach (string file in fileStack.Reverse())
            {
                resultBuilder.Append(SLASH);
                resultBuilder.Append(file);
            }

            return resultBuilder.ToString();
        }
    }
}

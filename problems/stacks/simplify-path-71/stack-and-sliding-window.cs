public class Solution
{
    private const char DELETION_MARKER = '*';
    private const char SLASH = '/';

    // Time: O(n)
    // Space: O(n)
    public string SimplifyPath(string path)
    {
        char[] result = path.ToCharArray();

        Stack<(int StartIndex, int EndIndex)> pathStack = new();

        int l = 0;
        int r = 0;

        while (l < path.Length)
        {
            while (r + 1 < path.Length && path[r + 1] != SLASH)
            {
                r++;
            }

            if (IsWindowEqualTo(l, r, "/"))
            {
                MarkAsDeleted(l, r);
            }
            else if (IsWindowEqualTo(l, r, "/."))
            {
                MarkAsDeleted(l, r);
            }
            else if (IsWindowEqualTo(l, r, "/.."))
            {
                MarkAsDeleted(l, r);

                if (pathStack.Count > 0)
                {
                    (int startIndex, int endIndex) = pathStack.Pop();
                    MarkAsDeleted(startIndex, endIndex);
                }
            }
            else
            {
                pathStack.Push((l, r));
            }

            r++;
            l = r;
        }

        string answer = string.Concat(result.Where(c => c != DELETION_MARKER));
        return answer == string.Empty ? $"{SLASH}" : answer;

        bool IsWindowEqualTo(int l, int r, string expected)
        {
            int windowLength = (r - l + 1);

            if (windowLength != expected.Length)
            {
                return false;
            }

            for (int i = 0; i < expected.Length; i++)
            {
                if (path[l + i] != expected[i])
                {
                    return false;
                }
            }

            return true;
        }

        void MarkAsDeleted(int startIndex, int endIndex)
        {
            for (int i = startIndex; i <= endIndex; i++)
            {
                result[i] = DELETION_MARKER;
            }
        }
    }
}

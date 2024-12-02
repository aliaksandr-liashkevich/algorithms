public class Solution
{
    // Time: O(n * m)
    // Space: O(m)
    public string LongestCommonPrefix(string[] strs)
    {
        if (strs.Length == 0)
        {
            return string.Empty;
        }

        string prefix = strs[0];
        int prefixLength = prefix.Length;

        foreach (string str in strs)
        {
            prefixLength = Math.Min(prefixLength, str.Length);
            prefixLength = CountCommonPrefix(prefix, str, prefixLength);
        }

        return prefix.Substring(0, prefixLength);
    }

    private int CountCommonPrefix(string left, string right, int length)
    {
        int index = 0;

        while (index < length)
        {
            if (left[index] != right[index])
            {
                return index;
            }

            index++;
        }

        return length;
    }
}

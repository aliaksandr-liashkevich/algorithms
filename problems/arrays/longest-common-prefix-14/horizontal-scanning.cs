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

        string firstStr = strs[0];

        if (strs.Length == 1)
        {
            return firstStr;
        }

        for (int firstStrIndex = 0; firstStrIndex < firstStr.Length; firstStrIndex++)
        {
            foreach (string str in strs.Skip(1))
            {
                if (firstStrIndex == str.Length || firstStr[firstStrIndex] != str[firstStrIndex])
                {
                    return firstStr.Substring(0, firstStrIndex);
                }
            }
        }

        return firstStr;
    }
}

public class Solution
{
    // Time: O(n)
    // Space: O(1)
    public bool CheckIfPangram(string sentence)
    {
        int length = 'z' - 'a' + 1;

        if (sentence.Length < length)
        {
            return false;
        }

        bool[] set = new bool[length];

        foreach (char letter in sentence)
        {
            set[letter - 'a'] = true;
        }

        return set.All(exists => exists);
    }
}

public class Solution
{
    // Time: O(n)
    // Space: O(1)
    public bool BackspaceCompare(string s, string t)
    {
        BackspaceStringIterator sIterator = new(s);
        BackspaceStringIterator tIterator = new(t);

        while (sIterator.HasMore() || tIterator.HasMore())
        {
            if (sIterator.GetNextOrNull() != tIterator.GetNextOrNull())
            {
                return false;
            }
        }

        return true;
    }

    private class BackspaceStringIterator
    {
        private const char BACKSPACE = '#';

        private string _str;
        private int _strIndex;
        private int _backspacesCount;

        public BackspaceStringIterator(string str)
        {
            _str = str;
            _strIndex = str.Length - 1;
        }

        public bool HasMore() => _strIndex >= 0;

        public char? GetNextOrNull()
        {
            while (HasMore())
            {
                char result = _str[_strIndex];
                _strIndex--;

                if (result == BACKSPACE)
                {
                    _backspacesCount++;
                }
                else if (_backspacesCount > 0)
                {
                    _backspacesCount--;
                }
                else
                {
                    return result;
                }
            }

            return null;
        }
    }
}

public class Trie
{
    private readonly TrieNode _root = new();

    public Trie()
    {
    }

    // Time: O(n)
    // Space: O(n)
    public void Insert(string word)
    {
        TrieNode node = _root;

        foreach (char symbol in word)
        {
            node = node.GetOrAddChild(symbol);
        }

        node.MarkAsTerminated();
    }

    // Time: O(n)
    // Space: O(1)
    public bool Search(string word)
    {
        TrieNode node = FindNode(word);
        return node is not null && node.IsTerminated();
    }

    // Time: O(n)
    // Space: O(1)
    public bool StartsWith(string prefix)
    {
        return FindNode(prefix) is not null;
    }

    // Time: O(n)
    // Space: O(1)
    private TrieNode FindNode(string prefix)
    {
        TrieNode node = _root;

        foreach (char symbol in prefix)
        {
            node = node.GetChildOrDefault(symbol);

            if (node is null)
            {
                return null;
            }
        }

        return node;
    }

    private class TrieNode
    {
        private readonly Dictionary<char, TrieNode> _children = new();
        private bool _isTerminatedNode;

        public TrieNode GetChildOrDefault(char symbol)
        {
            return _children.GetValueOrDefault(symbol);
        }

        public TrieNode GetOrAddChild(char symbol)
        {
            if (!_children.TryGetValue(symbol, out TrieNode child))
            {
                child = new();
                _children[symbol] = child;
            }

            return child;
        }

        public void MarkAsTerminated()
        {
            _isTerminatedNode = true;
        }

        public bool IsTerminated() => _isTerminatedNode;
    }
}

/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
 */

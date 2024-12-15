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
        private readonly TrieNodeArray _children = new();
        private bool _isTerminatedNode;

        public TrieNode GetChildOrDefault(char symbol)
        {
            return _children[symbol];
        }

        public TrieNode GetOrAddChild(char symbol)
        {
            _children[symbol] ??= new();
            return _children[symbol];
        }

        public void MarkAsTerminated()
        {
            _isTerminatedNode = true;
        }

        public bool IsTerminated() => _isTerminatedNode;
    }

    private class TrieNodeArray
    {
        private readonly TrieNode[] _nodes = new TrieNode['z' - 'a' + 1];

        public TrieNode this[char symbol]
        {
            get => _nodes[symbol - 'a'];
            set => _nodes[symbol - 'a'] = value;
        }
    }
}

/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
 */

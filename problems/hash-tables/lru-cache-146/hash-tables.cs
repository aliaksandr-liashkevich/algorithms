public class LRUCache
{
    private readonly int _capacity;
    private readonly Dictionary<int, LinkedListNode<(int Key, int Value)>> _cache;
    private readonly LinkedList<(int Key, int Value)> _lruList;

    public LRUCache(int capacity)
    {
        _capacity = capacity;
        _cache = new(capacity);
        _lruList = new();
    }

    public int Get(int key)
    {
        return TryGetFromCache(key, out LinkedListNode<(int Key, int Value)> currentNode)
            ? currentNode.Value.Value
            : -1;
    }

    public void Put(int key, int value)
    {
        if (TryGetFromCache(key, out LinkedListNode<(int Key, int Value)> currentNode))
        {
            currentNode.Value = (key, value);
        }
        else
        {
            bool isCacheFull = _cache.Count >= _capacity;

            if (isCacheFull)
            {
                RemoveLowPriorityNode();
            }

            AddNewNode(key, value);
        }

        void RemoveLowPriorityNode()
        {
            LinkedListNode<(int Key, int Value)> lowPriorityNode = _lruList.First;

            _cache.Remove(lowPriorityNode.Value.Key);
            _lruList.Remove(lowPriorityNode);
        }

        void AddNewNode(int key, int value)
        {
            LinkedListNode<(int Key, int Value)> newNode = new LinkedListNode<(int Key, int Value)>((key, value));

            _lruList.AddLast(newNode);
            _cache[key] = newNode;
        }
    }

    private bool TryGetFromCache(int key, out LinkedListNode<(int Key, int Value)> node)
    {
        if (_cache.TryGetValue(key, out node))
        {
            ReprioritizeNode(node);
            return true;
        }
        else
        {
            return false;
        }

        void ReprioritizeNode(LinkedListNode<(int Key, int Value)> node)
        {
            _lruList.Remove(node);
            _lruList.AddLast(node);
        }
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */

public class LFUCache
{
    private const int INITIAL_FREQUENCY = 1;

    private readonly int _capacity;
    private readonly Dictionary<int, CachedItem> _cache;
    private readonly Dictionary<int, LinkedList<int>> _keysByFrequency;

    private int _minFrequency = INITIAL_FREQUENCY;

    public LFUCache(int capacity)
    {
        _capacity = capacity;
        _cache = new(capacity);
        _keysByFrequency = new();
    }

    public int Get(int key)
    {
        return TryGetFromCache(key, out CachedItem currentItem)
            ? currentItem.Value
            : -1;
    }

    public void Put(int key, int value)
    {
        if (TryGetFromCache(key, out CachedItem currentItem))
        {
            currentItem.Value = value;
        }
        else
        {
            bool isCacheFull = _cache.Count >= _capacity;

            if (isCacheFull)
            {
                RemoveLowFrequencyItem();
            }

            AddNewItem(key, value);
        }

        void RemoveLowFrequencyItem()
        {
            LinkedList<int> minKeys = _keysByFrequency[_minFrequency];
            LinkedListNode<int> lowFrequencyKeyNode = minKeys.First;

            _cache.Remove(lowFrequencyKeyNode.Value);
            minKeys.Remove(lowFrequencyKeyNode);
        }

        void AddNewItem(int key, int value)
        {
            const int frequency = INITIAL_FREQUENCY;

            LinkedListNode<int> keyNode = new LinkedListNode<int>(key);
            CachedItem newItem = new()
            {
                KeyNode = keyNode,
                Frequency = frequency,
                Value = value,
            };

            if (!_keysByFrequency.ContainsKey(frequency))
            {
                _keysByFrequency[frequency] = new();
            }

            _minFrequency = frequency;

            _keysByFrequency[frequency].AddLast(keyNode);
            _cache[key] = newItem;
        }
    }

    private bool TryGetFromCache(int key, out CachedItem item)
    {
        if (_cache.TryGetValue(key, out item))
        {
            IncreaseFrequency(item);
            return true;
        }
        else
        {
            return false;
        }

        void IncreaseFrequency(CachedItem item)
        {
            LinkedList<int> keys = _keysByFrequency[item.Frequency];

            keys.Remove(item.KeyNode);

            int newFrequency = item.Frequency + 1;

            if (_minFrequency == item.Frequency && keys.Count == 0)
            {
                _minFrequency = newFrequency;
            }

            if (!_keysByFrequency.ContainsKey(newFrequency))
            {
                _keysByFrequency[newFrequency] = new();
            }

            item.Frequency = newFrequency;
            _keysByFrequency[newFrequency].AddLast(item.KeyNode);
        }
    }

    private class CachedItem
    {
        public LinkedListNode<int> KeyNode { get; init; }

        public int Frequency { get; set; }

        public int Value { get; set; }
    }
}

/**
 * Your LFUCache object will be instantiated and called as such:
 * LFUCache obj = new LFUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */

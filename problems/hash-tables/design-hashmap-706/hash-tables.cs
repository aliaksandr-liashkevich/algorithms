public class MyHashMap
{
    private const int INITIAL_CAPACITY = 1021;
    private const double LOAD_FACTOR_LIMIT = 0.75;

    private LinkedList<MyHashMapNode>[] _items;
    private int _capacity;
    private int _count;

    public MyHashMap()
    {
        _capacity = INITIAL_CAPACITY;
        _items = new LinkedList<MyHashMapNode>[_capacity];
    }

    public void Put(int key, int value)
    {
        (int index, MyHashMapNode node) = GetNodeOrDefault(key);

        if (node is null)
        {
            _items[index] ??= new LinkedList<MyHashMapNode>();
            _items[index].AddLast(new MyHashMapNode()
            {
                Key = key,
                Value = value,
            });
        }
        else
        {
            node.Value = value;
        }

        if (GetLoadFactor() >= LOAD_FACTOR_LIMIT)
        {
            Resize();
        }
    }

    public int Get(int key)
    {
        (int index, MyHashMapNode node) = GetNodeOrDefault(key);

        return node is null ? -1 : node.Value;
    }

    public void Remove(int key)
    {
        (int index, MyHashMapNode node) = GetNodeOrDefault(key);

        if (node is not null)
        {
            _items[index].Remove(node);
        }
    }

    private (int Index, MyHashMapNode Node) GetNodeOrDefault(int key)
    {
        int index = GetHash(key);
        MyHashMapNode node = _items[index]?.FirstOrDefault(x => x.Key == key);
        return (index, node);
    }

    private int GetHash(int key)
    {
        return Math.Abs(key) % _capacity;
    }

    private void Resize()
    {
        LinkedList<MyHashMapNode>[] _oldItems = _items;

        _capacity = _capacity * 2 + 1;
        _items = new LinkedList<MyHashMapNode>[_capacity];
        _count = 0;

        foreach (MyHashMapNode node in _oldItems.Where(x => x is not null).SelectMany(x => x))
        {
            Put(node.Key, node.Value);
        }
    }

    private double GetLoadFactor()
    {
        return (double)_count / _capacity;
    }

    private class MyHashMapNode
    {
        public int Key { get; init; }

        public int Value { get; set; }
    }
}

/**
 * Your MyHashMap object will be instantiated and called as such:
 * MyHashMap obj = new MyHashMap();
 * obj.Put(key,value);
 * int param_2 = obj.Get(key);
 * obj.Remove(key);
 */

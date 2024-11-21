public class RandomizedSet
{
    private readonly Dictionary<int, int> _indexesByKey;
    private readonly List<int> _keys;
    private readonly Random _random;

    public RandomizedSet()
    {
        _indexesByKey = new();
        _keys = new();
        _random = new();
    }

    public bool Insert(int key)
    {
        if (_indexesByKey.ContainsKey(key))
        {
            return false;
        }

        _indexesByKey[key] = _keys.Count;
        _keys.Add(key);

        return true;
    }

    public bool Remove(int key)
    {
        if (!_indexesByKey.ContainsKey(key))
        {
            return false;
        }

        int lastKey = _keys[_keys.Count - 1];
        int indexToRemove = _indexesByKey[key];

        _keys[indexToRemove] = lastKey;
        _indexesByKey[lastKey] = indexToRemove;

        _keys.RemoveAt(_keys.Count - 1);
        _indexesByKey.Remove(key);

        return true;
    }

    public int GetRandom()
    {
        int index = _random.Next(_keys.Count);
        return _keys[index];
    }
}

/**
 * Your RandomizedSet object will be instantiated and called as such:
 * RandomizedSet obj = new RandomizedSet();
 * bool param_1 = obj.Insert(val);
 * bool param_2 = obj.Remove(val);
 * int param_3 = obj.GetRandom();
 */

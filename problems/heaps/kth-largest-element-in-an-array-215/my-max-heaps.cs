public class Solution
{
    // Time: O(n * log(n))
    // Space: O(n)
    public int FindKthLargest(int[] nums, int k)
    {
        if (k > nums.Length)
        {
            return -1;
        }

        Heap maxHeap = Heap.CreateMaxHeap();

        foreach (int num in nums)
        {
            maxHeap.Push(num);
        }

        while ((k - 1) > 0)
        {
            maxHeap.PopTop();
            k--;
        }

        return maxHeap.PeekTop();
    }

    private class Heap
    {
        private const int ROOT_INDEX = 0;

        private readonly List<int> _items;
        private readonly IComparer<int> _comparer;

        public Heap(IComparer<int> comparer)
        {
            _items = new();
            _comparer = comparer;
        }

        public bool IsEmpty => _items.Count == 0;

        public void Push(int value)
        {
            _items.Add(value);
            ShiftUp(GetLastIndex());
        }

        public int PeekTop()
        {
            return IsEmpty ? -1 : _items[ROOT_INDEX];
        }

        public int PopTop()
        {
            int top = PeekTop();

            if (IsEmpty)
            {
                return top;
            }

            Swap(GetLastIndex(), ROOT_INDEX);
            _items.RemoveAt(GetLastIndex());

            if (!IsEmpty)
            {
                ShiftDown(ROOT_INDEX);
            }

            return top;
        }

        public static Heap CreateMaxHeap()
        {
            return new Heap(Comparer<int>.Create((a, b) => b.CompareTo(a)));
        }

        public static Heap CreateMinHeap()
        {
            return new Heap(Comparer<int>.Create((a, b) => a.CompareTo(b)));
        }

        private void ShiftUp(int i)
        {
            if (i != ROOT_INDEX)
            {
                int parentIndex = GetParentIndex(i);

                if (HasHighPriority(i, parentIndex))
                {
                    Swap(i, parentIndex);
                    ShiftUp(parentIndex);
                }
            }
        }

        private void ShiftDown(int i)
        {
            int leftChildIndex = GetLeftChildIndex(i);
            int rightChildIndex = GetRightChildIndex(i);

            if (leftChildIndex > GetLastIndex())
            {
                return;
            }

            int nextIndex = leftChildIndex;

            if (rightChildIndex <= GetLastIndex() && HasHighPriority(rightChildIndex, nextIndex))
            {
                nextIndex = rightChildIndex;
            }

            if (HasHighPriority(nextIndex, i))
            {
                Swap(nextIndex, i);
                ShiftDown(nextIndex);
            }
        }

        private bool HasHighPriority(int i, int j)
        {
            return _comparer.Compare(_items[i], _items[j]) < 0;
        }

        private void Swap(int i, int j)
        {
            int buffer = _items[i];
            _items[i] = _items[j];
            _items[j] = buffer;
        }

        private int GetLastIndex() => _items.Count - 1;

        private static int GetParentIndex(int i) => (i - 1) / 2;

        private static int GetLeftChildIndex(int i) => i * 2 + 1;

        private static int GetRightChildIndex(int i) => GetLeftChildIndex(i) + 1;
    }
}

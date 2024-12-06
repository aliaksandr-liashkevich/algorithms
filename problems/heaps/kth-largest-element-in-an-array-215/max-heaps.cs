public class Solution
{
    // Time: O(n * log(n))
    // Space: O(n)
    public int FindKthLargest(int[] nums, int k)
    {
        PriorityQueue<int, int> maxHeap = new(
            nums.Select(x => (x, x)),
            Comparer<int>.Create((x, y) => y.CompareTo(x)));

        while ((k - 1) > 0)
        {
            maxHeap.Dequeue();
            k--;
        }

        return maxHeap.Peek();
    }
}

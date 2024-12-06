public class Solution
{
    // Time: O(n * log(k))
    // Space: O(k)
    public int FindKthLargest(int[] nums, int k)
    {
        PriorityQueue<int, int> minHeap = new(
            nums.Select(x => (x, x)).Take(k));

        for (int i = k; i < nums.Length; i++)
        {
            int num = nums[i];

            if (num >= minHeap.Peek())
            {
                minHeap.Dequeue();
                minHeap.Enqueue(num, num);
            }
        }

        return minHeap.Dequeue();
    }
}

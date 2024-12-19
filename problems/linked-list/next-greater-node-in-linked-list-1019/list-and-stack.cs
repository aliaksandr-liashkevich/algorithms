/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution
{
    // Time: O(2n) ~ O(n)
    // Space: O(2n) ~ O(n)
    public int[] NextLargerNodes(ListNode head)
    {
        if (head is null)
        {
            return Array.Empty<int>();
        }

        List<int> nums = new();

        ListNode curr = head;

        while (curr is not null)
        {
            nums.Add(curr.val);
            curr = curr.next;
        }

        Stack<int> indexStack = new();

        int[] answer = new int[nums.Count];

        for (int i = 0; i < nums.Count; i++)
        {
            while (indexStack.Count > 0 && nums[indexStack.Peek()] < nums[i])
            {
                answer[indexStack.Pop()] = nums[i];
            }

            indexStack.Push(i);
        }

        return answer.ToArray();
    }
}

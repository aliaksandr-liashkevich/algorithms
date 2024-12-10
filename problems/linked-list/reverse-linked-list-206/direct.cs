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
    // Time: O(n)
    // Space: O(n)
    public ListNode ReverseList(ListNode head)
    {
        List<int> nums = new();

        ListNode curr = head;

        // O(n)
        while (curr is not null)
        {
            nums.Add(curr.val);
            curr = curr.next;
        }

        // O(n)
        nums.Reverse();

        ListNode dummy = new();
        curr = dummy;

        // O(n)
        foreach (int num in nums)
        {
            curr.next = new ListNode(num);
            curr = curr.next;
        }

        return dummy.next;
    }
}

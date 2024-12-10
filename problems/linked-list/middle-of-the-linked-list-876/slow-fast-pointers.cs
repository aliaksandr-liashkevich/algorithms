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
    // Space: O(1)
    public ListNode MiddleNode(ListNode head)
    {
        ListNode slow = head;
        ListNode fast = head;

        while (fast?.next is not null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }

        return slow;
    }
}

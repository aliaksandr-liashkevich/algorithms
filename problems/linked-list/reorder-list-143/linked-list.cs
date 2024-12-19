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
    // Time: O(3n) ~ O(n)
    // Space: O(1)
    public void ReorderList(ListNode head)
    {
        ListNode preMiddle = FindPreMiddle(head);
        ListNode right = Reverse(preMiddle.next);

        preMiddle.next = null;
        ListNode left = head;

        while (left is not null && right is not null)
        {
            ListNode leftNext = left.next;

            left.next = right;

            left = right;
            right = leftNext;
        }
    }

    // Time: O(n)
    // Space: O(1)
    private static ListNode FindPreMiddle(ListNode head)
    {
        ListNode slow = head;
        ListNode fast = head;

        while (fast?.next?.next is not null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }

        return slow;
    }

    // Time: O(n)
    // Space: O(1)
    private static ListNode Reverse(ListNode head)
    {
        ListNode prev = null;
        ListNode curr = head;

        while (curr is not null)
        {
            ListNode next = curr.next;

            curr.next = prev;
            prev = curr;
            curr = next;
        }

        return prev;
    }
}

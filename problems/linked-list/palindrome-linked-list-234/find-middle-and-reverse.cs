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
    public bool IsPalindrome(ListNode head)
    {
        ListNode middle = FindMiddle(head);
        ListNode right = Reverse(middle);
        ListNode left = head;

        // O(n)
        while (left is not null && right is not null)
        {
            if (left.val != right.val)
            {
                return false;
            }

            left = left.next;
            right = right.next;
        }

        return true;
    }

    // Time: O(n)
    // Space: O(1)
    private static ListNode FindMiddle(ListNode head)
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

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {
 *         val = x;
 *         next = null;
 *     }
 * }
 */
public class Solution
{
    // Time: O(n)
    // Space: O(1)
    public ListNode DetectCycle(ListNode head)
    {
        ListNode slow = head;
        ListNode fast = head;

        while (fast?.next is not null)
        {
            slow = slow.next;
            fast = fast.next.next;

            if (slow == fast)
            {
                slow = head;

                while (slow != fast)
                {
                    slow = slow.next;
                    fast = fast.next;
                }

                return fast;
            }
        }

        return null;
    }
}

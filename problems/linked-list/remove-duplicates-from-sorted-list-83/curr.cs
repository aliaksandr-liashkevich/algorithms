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
    // Spcae: O(1)
    public ListNode DeleteDuplicates(ListNode head)
    {
        ListNode curr = head;

        while (curr?.next is not null)
        {
            if (curr.val == curr.next.val)
            {
                curr.next = curr.next.next;
            }
            else
            {
                curr = curr.next;
            }
        }

        return head;
    }
}

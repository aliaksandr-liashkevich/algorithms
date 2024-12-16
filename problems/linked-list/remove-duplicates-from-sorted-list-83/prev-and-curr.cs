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
        ListNode prev = null;
        ListNode curr = head;

        while (curr is not null)
        {
            if (prev?.val == curr.val)
            {
                prev.next = curr.next;
            }
            else
            {
                prev = curr;
            }

            curr = curr.next;
        }

        return head;
    }
}

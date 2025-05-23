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
    // Time: O(min(p1, p2))
    // Space: O(1)
    public ListNode MergeTwoLists(ListNode p1, ListNode p2)
    {
        ListNode dummy = new();

        ListNode p = dummy;

        // O(min(n1, n2))
        while (p1 is not null && p2 is not null)
        {
            if (p1.val > p2.val)
            {
                p.next = p2;
                p2 = p2.next;
            }
            else
            {
                p.next = p1;
                p1 = p1.next;
            }

            p = p.next;
        }

        p.next = p1 ?? p2;

        return dummy.next;
    }
}

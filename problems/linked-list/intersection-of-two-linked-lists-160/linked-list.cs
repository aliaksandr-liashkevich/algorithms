/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution
{
    // Time: O(a + b)
    // Space: O(1)
    public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
    {
        ListNode pA = headA;
        ListNode pB = headB;

        while (pA != pB)
        {
            pA = pA is null ? headB : pA.next;
            pB = pB is null ? headA : pB.next;
        }

        return pA;
    }
}

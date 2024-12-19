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
    // Time: O(a * b)
    // Space: O(1)
    public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
    {
        ListNode pA = headA;

        while (pA is not null)
        {
            ListNode pB = headB;

            while (pB is not null)
            {
                if (pA == pB)
                {
                    return pA;
                }

                pB = pB.next;
            }

            pA = pA.next;
        }

        return null;
    }
}

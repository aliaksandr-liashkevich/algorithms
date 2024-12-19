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
    // Time: O(max(l1, l2))
    // Space: O(max(l1, l2))
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        ListNode dummy = new();
        ListNode lResult = dummy;

        int carry = 0;

        while (l1 is not null || l2 is not null || carry > 0)
        {
            int sum = GetValueOrZero(l1) + GetValueOrZero(l2) + carry;
            int value = sum % 10;
            carry = sum / 10;

            lResult.next = new(value);
            lResult = lResult.next;

            l1 = l1?.next;
            l2 = l2?.next;
        }

        return dummy.next;

        int GetValueOrZero(ListNode l) => l?.val ?? 0;
    }
}

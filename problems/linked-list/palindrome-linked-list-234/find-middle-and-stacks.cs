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
    // Space: O(n/2)
    public bool IsPalindrome(ListNode head)
    {
        ListNode middle = FindMiddle(head);
        return IsPalindrome(head, middle);
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
    // Space: (n/2)
    private static bool IsPalindrome(ListNode head, ListNode middle)
    {
        Stack<int> rightStack = new();

        // O(n/2)
        while (middle is not null)
        {
            rightStack.Push(middle.val);
            middle = middle.next;
        }

        ListNode left = head;

        // O(n/2)
        while (rightStack.Count > 0)
        {
            int rightValue = rightStack.Pop();

            if (left.val != rightValue)
            {
                return false;
            }

            left = left.next;
        }

        return true;
    }
}

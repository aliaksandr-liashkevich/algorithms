/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution
{
    // Time: O(n)
    // Space: O(h)
    public int KthLargest(TreeNode root, int k)
    {
        if (k <= 0)
        {
            return - 1;
        }

        int kDown = k;
        return InOrderTraverse(root) ?? -1;

        int? InOrderTraverse(TreeNode curr)
        {
            if (curr is null)
            {
                return null;
            }

            int? kLargest = InOrderTraverse(curr.right);

            if (kLargest is not null)
            {
                return kLargest;
            }

            kDown--;

            if (kDown == 0)
            {
                return curr.val;
            }

            return InOrderTraverse(curr.left);
        }
    }
}

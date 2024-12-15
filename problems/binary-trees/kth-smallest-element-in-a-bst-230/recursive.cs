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
    public int KthSmallest(TreeNode root, int k)
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

            int? kSmallest = InOrderTraverse(curr.left);

            if (kSmallest is not null)
            {
                return kSmallest;
            }

            kDown--;

            if (kDown == 0)
            {
                return curr.val;
            }

            return InOrderTraverse(curr.right);
        }
    }
}

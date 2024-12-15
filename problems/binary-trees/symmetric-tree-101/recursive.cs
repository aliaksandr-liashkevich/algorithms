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
    public bool IsSymmetric(TreeNode root)
    {
        return IsSymmetricSubtree(root?.left, root?.right);

        bool IsSymmetricSubtree(TreeNode l, TreeNode r)
        {
            if (l is null || r is null)
            {
                return l is null && r is null;
            }

            if (l.val != r.val)
            {
                return false;
            }

            return IsSymmetricSubtree(l.left, r.right) &&
                IsSymmetricSubtree(l.right, r.left);
        }
    }
}

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
    public bool IsSameTree(TreeNode p, TreeNode q)
    {
        if (p is null || q is null)
        {
            return p is null && q is null;
        }

        if (p.val != q.val)
        {
            return false;
        }

        return IsSameTree(p.left, q.left) &&
            IsSameTree(p.right, q.right);
    }
}

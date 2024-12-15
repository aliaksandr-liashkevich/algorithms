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
    public bool IsValidBST(TreeNode root)
    {
        TreeNode prev = null;
        return InOrderTraverse(root);

        bool InOrderTraverse(TreeNode node)
        {
            if (node is null)
            {
                return true;
            }

            if (!InOrderTraverse(node.left))
            {
                return false;
            }

            if (prev is not null && prev.val >= node.val)
            {
                return false;
            }

            prev = node;

            return InOrderTraverse(node.right);
        }
    }
}

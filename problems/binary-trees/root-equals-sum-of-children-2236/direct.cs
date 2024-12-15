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
    // Time: O(1)
    // Space: O(1)
    public bool CheckTree(TreeNode root)
    {
        if (root is null || root.left is null || root.right is null)
        {
            return false;
        }
        else
        {
            return root.val == (root.left.val + root.right.val);
        }
    }
}

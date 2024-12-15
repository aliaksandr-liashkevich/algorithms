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
    // Time: O(n^2)
    // Space: O(n)
    public bool IsValidBST(TreeNode node)
    {
        if (node is null)
        {
            return true;
        }

        if (node.left is not null && FindMax(node.left) >= node.val)
        {
            return false;
        }

        if (node.right is not null && FindMin(node.right) <= node.val)
        {
            return false;
        }

        return IsValidBST(node.left) && IsValidBST(node.right);

        static int FindMin(TreeNode node)
        {
            if (node is null)
            {
                return int.MaxValue;
            }

            return Math.Min(node.val, Math.Min(FindMin(node.left), FindMin(node.right)));
        }

        static int FindMax(TreeNode node)
        {
            if (node is null)
            {
                return int.MinValue;
            }

            return Math.Max(node.val, Math.Max(FindMax(node.left), FindMax(node.right)));
        }
    }
}

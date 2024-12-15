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
    public bool HasPathSum(TreeNode root, int targetSum)
    {
        return PreOrderTraverse(root, downSum: targetSum);

        bool PreOrderTraverse(TreeNode node, int downSum)
        {
            if (node is null)
            {
                return false;
            }

            downSum -= node.val;

            if (IsLeaf(node))
            {
                return downSum == 0;
            }

            return PreOrderTraverse(node.left, downSum) ||
                PreOrderTraverse(node.right, downSum);
        }

        bool IsLeaf(TreeNode node) => node.left is null && node.right is null;
    }
}

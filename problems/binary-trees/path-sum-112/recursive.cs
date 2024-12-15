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
        return PreOrderTraverse(root, currSum: 0);

        bool PreOrderTraverse(TreeNode node, int currSum)
        {
            if (node is null)
            {
                return false;
            }

            int nodeSum = currSum + node.val;

            if (IsLeaf(node))
            {
                return targetSum == nodeSum;
            }

            return PreOrderTraverse(node.left, nodeSum) ||
                PreOrderTraverse(node.right, nodeSum);
        }

        bool IsLeaf(TreeNode node) => node.left is null && node.right is null;
    }
}

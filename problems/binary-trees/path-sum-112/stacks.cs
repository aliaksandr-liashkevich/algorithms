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
        if (root is null)
        {
            return false;
        }

        Stack<(TreeNode Node, int DownSum)> nodeStack = new();
        nodeStack.Push((root, targetSum - root.val));

        while (nodeStack.Count > 0)
        {
            (TreeNode node, int downSum) = nodeStack.Pop();

            if (IsLeaf(node) && downSum == 0)
            {
                return true;
            }

            if (node.left is not null)
            {
                nodeStack.Push((node.left, downSum - node.left.val));
            }

            if (node.right is not null)
            {
                nodeStack.Push((node.right, downSum - node.right.val));
            }
        }

        return false;

        bool IsLeaf(TreeNode node) => node.left is null && node.right is null;
    }
}

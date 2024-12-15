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
    public int MaxDepth(TreeNode root)
    {
        if (root is null)
        {
            return 0;
        }

        Stack<(TreeNode Node, int Depth)> nodeStack = new();
        nodeStack.Push((root, 1));

        int maxDepth = 0;

        while (nodeStack.Count > 0)
        {
            (TreeNode node, int depth) = nodeStack.Pop();

            maxDepth = Math.Max(maxDepth, depth);

            if (node.left is not null)
            {
                nodeStack.Push((node.left, depth + 1));
            }

            if (node.right is not null)
            {
                nodeStack.Push((node.right, depth + 1));
            }
        }

        return maxDepth;
    }
}

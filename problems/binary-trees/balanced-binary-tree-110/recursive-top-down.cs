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
    public bool IsBalanced(TreeNode node)
    {
        if (node is null)
        {
            return true;
        }

        return Math.Abs(FindMaxDepth(node.left) - FindMaxDepth(node.right)) <= 1 &&
            IsBalanced(node.left) &&
            IsBalanced(node.right);
    }

    private int FindMaxDepth(TreeNode node)
    {
        if (node is null)
        {
            return 0;
        }

        return 1 + Math.Max(FindMaxDepth(node.left), FindMaxDepth(node.right));
    }
}

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
    private static readonly (bool IsBalanced, int Depth) ZERO_BALANCED = (IsBalanced: true, Depth: 0);

    private static readonly (bool IsBalanced, int Depth) NOT_BALANCED = (IsBalanced: false, Depth: -1);

    // Time: O(n)
    // Space: O(h)
    public bool IsBalanced(TreeNode root)
    {
        return PostOrderTraverse(root).IsBalanced;

        (bool IsBalanced, int Depth) PostOrderTraverse(TreeNode node)
        {
            if (node is null)
            {
                return ZERO_BALANCED;
            }

            (bool isLeftBalanced, int leftDepth) = PostOrderTraverse(node.left);

            if (!isLeftBalanced)
            {
                return NOT_BALANCED;
            }

            (bool isRightBalanced, int rightDepth) = PostOrderTraverse(node.right);

            if (!isRightBalanced)
            {
                return NOT_BALANCED;
            }

            bool isBalanced = Math.Abs(leftDepth - rightDepth) <= 1;

            if (!isBalanced)
            {
                return NOT_BALANCED;
            }
            else
            {
                int maxDepth = 1 + Math.Max(leftDepth, rightDepth);
                return (IsBalanced: true, maxDepth);
            }
        }
    }
}

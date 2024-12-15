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
    public int DiameterOfBinaryTree(TreeNode root)
    {
        int diameter = 0;
        PostOrderTraverse(root);
        return diameter;

        (int Depth, int Diameter) PostOrderTraverse(TreeNode node)
        {
            if (node is null)
            {
                return (Depth: 0, Diameter: 0);
            }

            int leftDepth = PostOrderTraverse(node.left);
            int rightDepth = PostOrderTraverse(node.right);

            diameter = Math.Max(diameter, leftDepth + rightDepth);

            return 1 + Math.Max(leftDepth, rightDepth);
        }
    }
}

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
    public int SumOfLeftLeaves(TreeNode root)
    {
        int sumLeaves = 0;
        PreOrderTraverse(root, isLeft: false);
        return sumLeaves;

        void PreOrderTraverse(TreeNode node, bool isLeft)
        {
            if (node is null)
            {
                return;
            }

            if (IsLeaf(node))
            {
                if (isLeft)
                {
                    sumLeaves += node.val;
                }

                return;
            }

            PreOrderTraverse(node.left, isLeft: true);
            PreOrderTraverse(node.right, isLeft: false);

            static bool IsLeaf(TreeNode node) => node.left is null && node.right is null;
        }
    }
}

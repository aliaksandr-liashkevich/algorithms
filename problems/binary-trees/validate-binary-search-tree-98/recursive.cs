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
    public bool IsValidBST(TreeNode root)
    {
        return IsValidBST(root, min: null, max: null);

        bool IsValidBST(TreeNode node, int? min, int? max)
        {
            if (node is null)
            {
                return true;
            }

            bool isValid = (min is null || min < node.val) &&
                (max is null || node.val < max);

            if (!isValid)
            {
                return false;
            }

            return IsValidBST(node.left, min, node.val) &&
                IsValidBST(node.right, node.val, max);
        }
    }
}

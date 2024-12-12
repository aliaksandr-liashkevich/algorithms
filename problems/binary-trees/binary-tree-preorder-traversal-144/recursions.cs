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
    public IList<int> PreorderTraversal(TreeNode root)
    {
        List<int> nums = new();
        Traverse(root);
        return nums;

        void Traverse(TreeNode node)
        {
            if (node is null)
            {
                return;
            }

            nums.Add(node.val);
            Traverse(node.left);
            Traverse(node.right);
        }
    }
}

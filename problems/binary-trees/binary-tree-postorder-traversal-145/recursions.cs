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
    // Space: O(n+h)
    public IList<int> PostorderTraversal(TreeNode root)
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

            Traverse(node.left);
            Traverse(node.right);
            nums.Add(node.val);
        }
    }
}

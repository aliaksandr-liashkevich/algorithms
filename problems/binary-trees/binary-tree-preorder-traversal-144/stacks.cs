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
    public IList<int> PreorderTraversal(TreeNode root)
    {
        List<int> nums = new();

        if (root is null)
        {
            return nums;
        }

        Stack<TreeNode> outStack = new();
        outStack.Push(root);

        while (outStack.Count > 0)
        {
            TreeNode node = outStack.Pop();

            nums.Add(node.val);

            if (node.right is not null)
            {
                outStack.Push(node.right);
            }

            if (node.left is not null)
            {
                outStack.Push(node.left);
            }
        }

        return nums;
    }
}

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
    // Space: O(n)
    public IList<int> PostorderTraversal(TreeNode root)
    {
        List<int> nums = new();

        if (root is null)
        {
            return nums;
        }

        Stack<TreeNode> inStack = new();
        Stack<TreeNode> outStack = new();
        inStack.Push(root);

        while (inStack.Count > 0)
        {
            TreeNode node = inStack.Pop();
            outStack.Push(node);

            if (node.left is not null)
            {
                inStack.Push(node.left);
            }

            if (node.right is not null)
            {
                inStack.Push(node.right);
            }
        }

        while (outStack.Count > 0)
        {
            TreeNode node = outStack.Pop();
            nums.Add(node.val);
        }

        return nums;
    }
}

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
    public IList<int> InorderTraversal(TreeNode root)
    {
        List<int> nums = new();

        if (root is null)
        {
            return nums;
        }

        Stack<TreeNode> outStack = new();
        TreeNode node = root;

        while (outStack.Count > 0 || node is not null)
        {
            while (node is not null)
            {
                outStack.Push(node);
                node = node.left;
            }

            node = outStack.Pop();
            nums.Add(node.val);

            node = node.right;
        }

        return nums;
    }
}

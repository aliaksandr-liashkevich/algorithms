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
    public bool IsSymmetric(TreeNode root)
    {
        if (root is null)
        {
            return true;
        }

        Stack<(TreeNode L, TreeNode R)> nodeStack = new();
        nodeStack.Push((root.left, root.right));

        while (nodeStack.Count > 0)
        {
            (TreeNode l, TreeNode r) = nodeStack.Pop();

            if (l is null && r is null)
            {
                continue;
            }

            if (l?.val != r?.val)
            {
                return false;
            }

            nodeStack.Push((l.left, r.right));
            nodeStack.Push((l.right, r.left));
        }

        return true;
    }
}

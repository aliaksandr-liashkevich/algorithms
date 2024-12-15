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
    public bool IsSameTree(TreeNode pRoot, TreeNode qRoot)
    {
        Stack<(TreeNode P, TreeNode Q)> nodeStack = new();
        nodeStack.Push((pRoot, qRoot));

        while (nodeStack.Count > 0)
        {
            (TreeNode p, TreeNode q) = nodeStack.Pop();

            if (p is null && q is null)
            {
                continue;
            }

            if (p?.val != q?.val)
            {
                return false;
            }

            nodeStack.Push((p.left, q.left));
            nodeStack.Push((p.right, q.right));
        }

        return true;
    }
}

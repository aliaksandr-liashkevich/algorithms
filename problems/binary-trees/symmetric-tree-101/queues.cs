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

        Queue<(TreeNode L, TreeNode R)> nodeQueue = new();
        nodeQueue.Enqueue((root.left, root.right));

        while (nodeQueue.Count > 0)
        {
            (TreeNode l, TreeNode r) = nodeQueue.Dequeue();

            if (l is null && r is null)
            {
                continue;
            }

            if (l?.val != r?.val)
            {
                return false;
            }

            nodeQueue.Enqueue((l.left, r.right));
            nodeQueue.Enqueue((l.right, r.left));
        }

        return true;
    }
}

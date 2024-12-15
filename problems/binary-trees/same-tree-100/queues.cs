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
        Queue<(TreeNode P, TreeNode Q)> nodeQueue = new();
        nodeQueue.Enqueue((pRoot, qRoot));

        while (nodeQueue.Count > 0)
        {
            (TreeNode p, TreeNode q) = nodeQueue.Dequeue();

            if (p is null && q is null)
            {
                continue;
            }

            if (p?.val != q?.val)
            {
                return false;
            }

            nodeQueue.Enqueue((p.left, q.left));
            nodeQueue.Enqueue((p.right, q.right));
        }

        return true;
    }
}

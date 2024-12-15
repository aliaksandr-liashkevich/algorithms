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
    // Time: O(h)
    // Space: O(h)
    public int ClosestValue(TreeNode root, double target)
    {
        int closest = root.val;
        ClosestTraverse(root);
        return closest;

        void ClosestTraverse(TreeNode node)
        {
            if (node is null)
            {
                return;
            }

            double closestDelta = Math.Abs(target - closest);
            double nodeDelta = Math.Abs(target - node.val);

            if (closestDelta > nodeDelta)
            {
                closest = node.val;
            }
            else if (closestDelta == nodeDelta)
            {
                closest = Math.Min(closest, node.val);
            }

            if (node.val > target)
            {
                ClosestTraverse(node.left);
            }
            else if (node.val < target)
            {
                ClosestTraverse(node.right);
            }
        }
    }
}

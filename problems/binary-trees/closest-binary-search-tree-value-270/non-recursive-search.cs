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
    // Space: O(1)
    public int ClosestValue(TreeNode root, double target)
    {
        TreeNode curr = root;
        int closest = curr.val;

        while (curr is not null)
        {
            int currValue = curr.val;

            double closestDelta = Math.Abs(target - closest);
            double currDelta = Math.Abs(target - currValue);

            if (closestDelta > currDelta)
            {
                closest = currValue;
            }
            else if (closestDelta == currDelta)
            {
                closest = Math.Min(closest, currValue);
            }

            if (currValue > target)
            {
                curr = curr.left;
            }
            else if (currValue < target)
            {
                curr = curr.right;
            }
            else
            {
                curr = null;
            }
        }

        return closest;
    }
}

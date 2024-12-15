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
    public TreeNode SortedArrayToBST(int[] nums)
    {
        return BuildTree(l: 0, r: nums.Length - 1);

        TreeNode BuildTree(int l, int r)
        {
            if (l > r)
            {
                return null;
            }

            int m = l + (r - l) / 2;
            TreeNode node = new TreeNode(nums[m]);

            node.left = BuildTree(l, m - 1);
            node.right = BuildTree(m + 1, r);

            return node;
        }
    }
}

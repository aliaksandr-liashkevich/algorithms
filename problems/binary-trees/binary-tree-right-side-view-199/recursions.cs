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
    // w - the width of the tree
    // k - the total number of levels
    // h - the heigh of the tree
    // Time: O(n)
    // Space: O(max(w, k, h))
    public IList<int> RightSideView(TreeNode root)
    {
        return LevelOrderOfLastLevels(root);
    }

    private static IList<int> LevelOrderOfLastLevels(TreeNode root)
    {
        IList<int> lastLevels = new List<int>();
        PreOrderTraverse(root, level: 0);
        return lastLevels;

        void PreOrderTraverse(TreeNode node, int level)
        {
            if (node is null)
            {
                return;
            }

            if (level == lastLevels.Count)
            {
                lastLevels.Add(0);
            }

            lastLevels[level] = node.val;
            PreOrderTraverse(node.left, level + 1);
            PreOrderTraverse(node.right, level + 1);
        }
    }
}

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
    public IList<IList<int>> LevelOrder(TreeNode root)
    {
        IList<IList<int>> levels = new List<IList<int>>();
        PreOrderTraverse(root, level: 0);
        return levels;

        // It seems like that the type of order does not matter.
        void PreOrderTraverse(TreeNode node, int level)
        {
            if (node is null)
            {
                return;
            }

            if (level == levels.Count)
            {
                levels.Add(new List<int>());
            }

            levels[level].Add(node.val);
            PreOrderTraverse(node.left, level + 1);
            PreOrderTraverse(node.right, level + 1);
        }
    }
}

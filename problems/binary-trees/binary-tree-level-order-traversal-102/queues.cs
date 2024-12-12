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
        // Space: O(n)
        IList<IList<int>> nums = new List<IList<int>>();

        if (root is null)
        {
            return nums;
        }

        // Space: O(n/2) when the balanced tree
        Queue<TreeNode> outQueue = new();
        outQueue.Enqueue(root);

        while (outQueue.Count > 0)
        {
            int levelCount = outQueue.Count;
            List<int> levelNums = new(levelCount);

            while (levelCount > 0)
            {
                TreeNode node = outQueue.Dequeue();
                levelNums.Add(node.val);

                if (node.left is not null)
                {
                    outQueue.Enqueue(node.left);
                }

                if (node.right is not null)
                {
                    outQueue.Enqueue(node.right);
                }

                levelCount--;
            }

            nums.Add(levelNums);
        }

        return nums;
    }
}

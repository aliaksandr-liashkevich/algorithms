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
    // Time: O(n)
    // Space: O(max(w, k))
    public IList<int> RightSideView(TreeNode root)
    {
        return LevelOrderOfLastNums(root);
    }

    private static IList<int> LevelOrderOfLastNums(TreeNode root)
    {
        IList<int> lastNums = new List<int>();

        if (root is null)
        {
            return lastNums;
        }

        Queue<TreeNode> outQueue = new();
        outQueue.Enqueue(root);

        while (outQueue.Count > 0)
        {
            int levelCount = outQueue.Count;
            int lastNum = 0;

            while (levelCount > 0)
            {
                TreeNode node = outQueue.Dequeue();
                lastNum = node.val;

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

            lastNums.Add(lastNum);
        }

        return lastNums;
    }
}

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
    public IList<IList<int>> LevelOrderBottom(TreeNode root)
    {
        IList<IList<int>> nums = LevelOrder(root);
        Reverse(nums);
        return nums;
    }

    // Time: O(n)
    // Space: O(1)
    private static void Reverse(IList<IList<int>> nums)
    {
        int l = 0;
        int r = nums.Count - 1;

        while (r > l)
        {
            Swap(l, r);

            l++;
            r--;
        }

        void Swap(int i, int j)
        {
            IList<int> buffer = nums[i];
            nums[i] = nums[j];
            nums[j] = buffer;
        }
    }

    // Time: O(n)
    // Space: O(n)
    private static IList<IList<int>> LevelOrder(TreeNode root)
    {
        IList<IList<int>> nums = new List<IList<int>>();

        if (root is null)
        {
            return nums;
        }

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

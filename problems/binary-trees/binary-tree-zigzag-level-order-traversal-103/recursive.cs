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
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
    {
        IList<IList<int>> nums = LevelOrder(root);
        ReverseOdd(nums);
        return nums;
    }

    // Time: O(n)
    // Space: O(n)
    private void ReverseOdd(IList<IList<int>> nums)
    {
        ReverseOdd(nums, i: 1);

        static void ReverseOdd(IList<IList<int>> nums, int i)
        {
            if (i >= nums.Count)
            {
                return;
            }

            Reverse(nums[i], l: 0, r: nums[i].Count - 1);
            ReverseOdd(nums, i + 2);
        }

        static void Reverse(IList<int> nums, int l, int r)
        {
            if (l >= r)
            {
                return;
            }

            Swap(nums, l, r);
            Reverse(nums, l + 1, r - 1);
        }

        static void Swap(IList<int> nums, int i, int j)
        {
            int buffer = nums[i];
            nums[i] = nums[j];
            nums[j] = buffer;
        }
    }

    // Time: O(n)
    // Space: O(n)
    private static IList<IList<int>> LevelOrder(TreeNode root)
    {
        IList<IList<int>> levels = new List<IList<int>>();
        PreOrderTraverse(root, level: 0);
        return levels;

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

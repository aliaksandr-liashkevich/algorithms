// TreeNode root = new TreeNode(
//     val: 10,
//     left: new TreeNode(
//         val: 5,
//         left: new TreeNode(val: -2),
//         right: new TreeNode(val: 7)
//     ),
//     right: new TreeNode(
//         val: 11,
//         right: new TreeNode(val: 15)
//     )
// );

// bool isValid = new Solution().ValidateTreeLeaves(root, min: -5, max: 15);
// bool isPassed = isValid == true;

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
    public bool ValidateTreeLeaves(TreeNode root, int min, int max)
    {
        if (root is null)
        {
            return true;
        }

        return IsValid(FindLeftMostValue(root)) &&
            IsValid(FindRightMostValue(root));

        bool IsValid(int value) => min <= value && value <= max;
    }

    private static int FindLeftMostValue(TreeNode root)
    {
        TreeNode node = root;

        while (node.left is not null)
        {
            node = node.left;
        }

        return node.val;
    }

    private static int FindRightMostValue(TreeNode root)
    {
        TreeNode node = root;

        while (node.right is not null)
        {
            node = node.right;
        }

        return node.val;
    }
}

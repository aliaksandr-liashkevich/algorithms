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
    // Space: O(n + h)
    public int PathSum(TreeNode root, int targetSum)
    {
        Dictionary<long, int> countsByPrefixSum = new();
        countsByPrefixSum.Add(0, 1);

        int totalPaths = 0;

        PreOrderTraverse(root, prefixSum: 0);

        return totalPaths;

        void PreOrderTraverse(TreeNode node, long prefixSum)
        {
            if (node is null)
            {
                return;
            }

            prefixSum += node.val;

            totalPaths += countsByPrefixSum.GetValueOrDefault(prefixSum - targetSum);

            if (!countsByPrefixSum.ContainsKey(prefixSum))
            {
                countsByPrefixSum[prefixSum] = 0;
            }

            countsByPrefixSum[prefixSum]++;

            PreOrderTraverse(node.left, prefixSum);

            PreOrderTraverse(node.right, prefixSum);

            countsByPrefixSum[prefixSum]--;
        }
    }
}

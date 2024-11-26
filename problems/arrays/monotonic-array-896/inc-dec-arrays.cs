public class Solution {
    // Time: O(n)
    // Space: O(1)
    public bool IsMonotonic(int[] nums) {
        bool isIncreased = true;
        bool isDecreased = true;

        for (int i = 0; i < (nums.Length - 1); i++)
        {
            isIncreased = isIncreased && (nums[i] <= nums[i + 1]);
            isDecreased = isDecreased && (nums[i] >= nums[i + 1]);
        }

        return isIncreased || isDecreased;
    }
}

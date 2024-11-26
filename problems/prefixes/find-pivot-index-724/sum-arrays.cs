public class Solution {
    // Time: O(n)
    // Space: O(1)
    public int PivotIndex(int[] nums) {
        if (nums.Length == 0)
        {
            return -1;
        }

        int totalSum = nums.Sum();
        int currSum = 0;

        for (int numIndex = 0; numIndex < nums.Length; numIndex++)
        {
            int num = nums[numIndex];

            if (currSum == (totalSum - num - currSum))
            {
                return numIndex;
            }

            currSum += num;
        }

        return -1;
    }
}

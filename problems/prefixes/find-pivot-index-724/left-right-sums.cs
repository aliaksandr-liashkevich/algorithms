public class Solution
{
    // Time: O(n)
    // Space: O(1)
    public int PivotIndex(int[] nums)
    {
        if (nums.Length == 0)
        {
            return -1;
        }

        int leftSum = 0;
        int rightSum = nums.Sum();

        for (int numIndex = 0; numIndex < nums.Length; numIndex++)
        {
            int num = nums[numIndex];

            rightSum -= num;

            if (leftSum == rightSum)
            {
                return numIndex;
            }

            leftSum += num;
        }

        return -1;
    }
}

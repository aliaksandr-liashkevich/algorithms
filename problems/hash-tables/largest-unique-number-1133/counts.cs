public class Solution {
    private const int MAX_NUMBER = 1000;

    // Time: O(n)
    // Space: O(1000) ~ O(1)
    public int LargestUniqueNumber(int[] nums) {
        if (nums.Length == 0)
        {
            return -1;
        }

        int[] counts = new int[MAX_NUMBER + 1];
        int maxNumber = 0;

        foreach (int num in nums)
        {
            counts[num]++;
            maxNumber = Math.Max(maxNumber, num);
        }

        for (int i = maxNumber; i >= 0; i--)
        {
            if (counts[i] == 1)
            {
                return i;
            }
        }

        return -1;
    }
}

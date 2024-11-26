public class Solution {
    // Time: O(n)
    // Space: O(n)
    public int PivotIndex(int[] nums) {
        int length = nums.Length;

        if (length == 0)
        {
            return -1;
        }

        int[] pxSums = new int[length + 1];
        int pxIndex = 1;

        foreach (int num in nums)
        {
            pxSums[pxIndex] = pxSums[pxIndex - 1] + num;
            pxIndex++;
        }

        int[] sxSums = new int[length + 1];
        int sxIndex = length - 1;

        foreach (int num in nums.Reverse())
        {
            sxSums[sxIndex] = sxSums[sxIndex + 1] + num;
            sxIndex--;
        }

        for (int numIndex = 0; numIndex < length; numIndex++)
        {
            if (pxSums[numIndex + 1] == sxSums[numIndex])
            {
                return numIndex;
            }
        }

        return -1;
    }
}

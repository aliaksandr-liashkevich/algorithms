public class Solution
{
    // Time: O(n)
    // Space: O(1)
    public int Trap(int[] height)
    {
        int l = 0;
        int r = height.Length - 1;

        int leftMax = 0;
        int rightMax = 0;

        int waterBlocks = 0;

        while (r > l)
        {
            if (height[l] < height[r])
            {
                leftMax = Math.Max(leftMax, height[l]);
                waterBlocks += leftMax - height[l];
                l++;
            }
            else
            {
                rightMax = Math.Max(rightMax, height[r]);
                waterBlocks += rightMax - height[r];
                r--;
            }
        }

        return waterBlocks;
    }
}

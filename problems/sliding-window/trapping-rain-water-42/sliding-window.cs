public class Solution
{
    // Time: O(n)
    // Space: O(1)
    public int Trap(int[] height)
    {
        int l = 0;
        int r = 0;

        int waterBlocks = 0;

        while (l < height.Length)
        {
            while ((r + 1) < height.Length && height[l] > height[r + 1])
            {
                r++;
            }

            int leftHeight = height[l];
            int rightHeight = height[(r + 1) < height.Length ? (r + 1) : r];

            for (int i = r; i > l; i--)
            {
                int waterBlock = Math.Min(leftHeight, rightHeight) - height[i];

                if (waterBlock > 0)
                {
                    waterBlocks += waterBlock;
                }

                if (height[i] > rightHeight)
                {
                    rightHeight = height[i];
                }
            }

            r++;
            l = r;
        }

        return waterBlocks;
    }
}

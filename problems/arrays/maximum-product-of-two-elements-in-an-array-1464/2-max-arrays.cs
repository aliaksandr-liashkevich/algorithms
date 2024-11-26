public class Solution
{
    // Time: O(n)
    // Space: O(1)
    public int MaxProduct(int[] nums)
    {
        int primaryMax = 0;
        int secondaryMax = 0;

        foreach (int num in nums)
        {
            if (num > primaryMax)
            {
                secondaryMax = primaryMax;
                primaryMax = num;
            }
            else
            {
                secondaryMax = Math.Max(secondaryMax, num);
            }
        }

        return (primaryMax - 1) * (secondaryMax - 1);
    }
}

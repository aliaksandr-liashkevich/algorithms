public class Solution
{
    // Time: O(n^2)
    // Space: O(sorting-array)
    public int ThreeSumClosest(int[] nums, int target)
    {
        int closestSum = nums.Take(3).Sum();

        if (nums.Length <= 3)
        {
            return closestSum;
        }

        // Space: O(sorting-array)
        Array.Sort(nums);

        int i = 0;

        while (i <= (nums.Length - 3))
        {
            int l = i + 1;
            int r = nums.Length - 1;

            while (r > l)
            {
                int sum = nums[i] + nums[l] + nums[r];

                if (Math.Abs(target - closestSum) > Math.Abs(target - sum))
                {
                    closestSum = sum;
                }

                if (sum > target)
                {
                    r--;
                }
                else if (sum < target)
                {
                    l++;
                }
                else
                {
                    return sum;
                }
            }

            i++;
        }

        return closestSum;
    }
}

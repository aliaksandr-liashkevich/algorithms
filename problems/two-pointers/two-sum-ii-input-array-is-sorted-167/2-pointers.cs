public class Solution
{
    // Time: O(n)
    // Space: O(1)
    public int[] TwoSum(int[] numbers, int target)
    {
        int l = 0;
        int r = numbers.Length - 1;

        while (r > l)
        {
            int sum = numbers[l] + numbers[r];

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
                return [l + 1, r + 1];
            }
        }

        return [];
    }
}

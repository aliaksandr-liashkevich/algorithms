public class Solution
{
    // Time: O(n)
    // Space: O(1)
    public void Rotate(int[] nums, int k)
    {
        int length = nums.Length;

        // O(n)
        Reverse(nums, 0, length - 1);
        // O(k)
        Reverse(nums, 0, k % length - 1);
        // O(n - k)
        Reverse(nums, k % length, length - 1);
    }

    private void Reverse(int[] nums, int l, int r)
    {
        while (r > l)
        {
            Swap(nums, l, r);
            l++;
            r--;
        }
    }

    private void Swap(int[] nums, int l, int r)
    {
        int buffer = nums[l];
        nums[l] = nums[r];
        nums[r] = buffer;
    }
}

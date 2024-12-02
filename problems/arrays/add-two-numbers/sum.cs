// int[] nums1 = [9, 9, 9, 9];
// int[] nums2 = [9, 9, 9];

// int[] answer = new Solution().AddTwoNumbers(nums1, nums2);

// bool isPassed = answer.SequenceEqual([1, 0, 9, 9, 8]);

public class Solution
{
    // n - the max length between nums1 and nums2
    // Time: O(n)
    // Space: O(n)
    public int[] AddTwoNumbers(int[] nums1, int[] nums2)
    {
        int index1 = nums1.Length - 1;
        int index2 = nums2.Length - 1;

        int carry = 0;
        int[] answer = new int[Math.Max(nums1.Length, nums2.Length) + 1];
        int indexAnswer = answer.Length - 1;

        while (indexAnswer >= 0)
        {
            int num1 = GetValueOrZero(nums1, index1);
            int num2 = GetValueOrZero(nums2, index2);

            int sum = num1 + num2 + carry;

            answer[indexAnswer] = sum % 10;
            carry = sum / 10;

            index1--;
            index2--;
            indexAnswer--;
        }

        return answer;
    }

    private int GetValueOrZero(int[] nums, int index)
        => index >= 0 && index < nums.Length ? nums[index] : 0;
}

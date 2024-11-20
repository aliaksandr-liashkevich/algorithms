public class Solution
{
    // Time: O(n)
    // Space: O(n)
    public int[] TwoSum(int[] nums, int target)
    {
        Dictionary<int, int> indexesByNum = new();

        for (int i = 0; i < nums.Length; i++)
        {
            int secondNum = nums[i];

            if (indexesByNum.TryGetValue(target - secondNum, out int firstIndex))
            {
                return [firstIndex, i];
            }
            else
            {
                indexesByNum[secondNum] = i;
            }
        }

        return [];
    }
}
public class Solution {
    // Time: O(n)
    // Space: O(n)
    public int FindMaxLength(int[] nums) {
        if (nums.Length <= 1)
        {
            return 0;
        }

        Dictionary<int, int> indexesByCount = new()
        {
            { 0, -1 }
        };

        int count = 0;
        int answer = 0;

        for (int index = 0; index < nums.Length; index++)
        {
            count += nums[index] == 1 ? 1 : -1;

            if (indexesByCount.TryGetValue(count, out int previousIndex))
            {
                answer = Math.Max(answer, index - previousIndex);
            }
            else
            {
                indexesByCount[count] = index;
            }
        }

        return answer;
    }
}

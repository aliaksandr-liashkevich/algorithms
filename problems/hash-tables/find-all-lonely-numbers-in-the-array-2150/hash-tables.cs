public class Solution
{
    // Time: O(n)
    // Space: O(n)
    public IList<int> FindLonely(int[] nums)
    {
        Dictionary<int, bool> duplicatesByNum = new();

        foreach (int num in nums)
        {
            if (duplicatesByNum.TryGetValue(num, out bool isDuplicated))
            {
                isDuplicated = true;
            }

            duplicatesByNum[num] = isDuplicated;
        }

        List<int> answer = new();

        foreach (int num in nums)
        {
            bool isUnique = !duplicatesByNum[num];

            if (isUnique &&
                !duplicatesByNum.ContainsKey(num - 1) &&
                !duplicatesByNum.ContainsKey(num + 1))
            {
                answer.Add(num);
            }
        }

        return answer;
    }
}

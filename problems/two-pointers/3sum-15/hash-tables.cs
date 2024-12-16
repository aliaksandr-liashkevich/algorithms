public class Solution
{
    // Time: O(n^2)
    // Space: O(sorting-array) + O(n)
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        Array.Sort(nums);

        IList<IList<int>> answer = new List<IList<int>>();

        int i = 0;

        while (i <= (nums.Length - 3))
        {
            bool isDuplicated = i != 0 && nums[i] == nums[i - 1];

            if (!isDuplicated)
            {
                HashSet<int> numSet = new();

                int j = i + 1;

                while (j < nums.Length)
                {
                    int numK = -(nums[i] + nums[j]);

                    if (numSet.Contains(numK))
                    {
                        answer.Add(new List<int> { nums[i], nums[j], numK });
                        j++;

                        while (j < nums.Length && nums[j] == nums[j - 1])
                        {
                            j++;
                        }
                    }
                    else
                    {
                        numSet.Add(nums[j]);
                        j++;
                    }
                }
            }

            i++;
        }

        return answer;
    }
}

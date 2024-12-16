public class Solution
{
    // k - the nunber of triple pairs
    // Time: O(n^2)
    // Space: O(n^2) or O(k)
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        // Space: O(sorting-array)
        Array.Sort(nums);

        // Space: O(n^2/constant) or O(k)
        IList<IList<int>> answer = new List<IList<int>>();

        int i = 0;

        while (i <= (nums.Length - 3))
        {
            bool isDuplicated = i != 0 && nums[i] == nums[i - 1];

            if (!isDuplicated)
            {
                int l = i + 1;
                int r = nums.Length - 1;

                while (r > l)
                {
                    int sum = nums[i] + nums[l] + nums[r];

                    if (sum > 0)
                    {
                        r--;
                    }
                    else if (sum < 0)
                    {
                        l++;
                    }
                    else
                    {
                        answer.Add(new List<int> { nums[i], nums[l], nums[r] });
                        l++;
                        r--;

                        while (r > l && nums[l] == nums[l - 1])
                        {
                            l++;
                        }
                    }
                }
            }

            i++;
        }

        return answer;
    }
}

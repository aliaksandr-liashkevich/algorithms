public class Solution
{
    // k = 4
    // Time: O(n^(k-1)) ~ O(n^3)
    // Space: O(sort) + O(n)
    public IList<IList<int>> FourSum(int[] nums, int target)
    {
        Array.Sort(nums);

        IList<IList<int>> answer = new List<IList<int>>();

        int i = 0;

        while (i <= (nums.Length - 4))
        {
            // filter duplicates
            if (i != 0 && nums[i] == nums[i - 1])
            {
                i++;
                continue;
            }

            int j = i + 1;

            while (j <= (nums.Length - 3))
            {
                // filter duplicates
                if (j != (i + 1) && nums[j] == nums[j - 1])
                {
                    j++;
                    continue;
                }

                int l = j + 1;
                int r = nums.Length - 1;

                while (r > l)
                {
                    long diff = target;
                    diff -= nums[i];
                    diff -= nums[j];
                    diff -= nums[l];
                    diff -= nums[r];

                    if (diff < 0)
                    {
                        r--;
                    }
                    else if (diff > 0)
                    {
                        l++;
                    }
                    else
                    {
                        answer.Add(new List<int> { nums[i], nums[j], nums[l], nums[r] });
                        l++;
                        r--;

                        // filter duplicates
                        while (r > l && nums[l] == nums[l - 1])
                        {
                            l++;
                        }

                        // filter duplicates
                        while (r > l && nums[r] == nums[r + 1])
                        {
                            r--;
                        }
                    }
                }

                j++;
            }

            i++;
        }

        return answer;
    }
}

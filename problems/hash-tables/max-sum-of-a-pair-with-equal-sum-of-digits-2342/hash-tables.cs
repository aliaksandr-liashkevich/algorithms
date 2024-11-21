public class Solution
{
    // Time: O(n)
    // Space: O(n)
    public int MaximumSum(int[] nums)
    {
        Dictionary<int, int> maxNumsBySumOfDigits = new();

        int answer = -1;

        foreach (int num in nums)
        {
            int sumOfDigits = GetSumOfDigits(num);

            if (maxNumsBySumOfDigits.TryGetValue(sumOfDigits, out int maxNum))
            {
                answer = Math.Max(answer, maxNum + num);
                maxNumsBySumOfDigits[sumOfDigits] = Math.Max(num, maxNum);
            }
            else
            {
                maxNumsBySumOfDigits[sumOfDigits] = num;
            }
        }

        return answer;
    }

    private int GetSumOfDigits(int num)
    {
        int sumOfDigits = 0;

        while (num > 0)
        {
            sumOfDigits += (num % 10);
            num /= 10;
        }

        return sumOfDigits;
    }
}

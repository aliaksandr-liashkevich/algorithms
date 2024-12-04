public class Solution
{
    private const int TARGET = 0;

    // Time: O(n)
    // Space: O(1)
    public void MoveZeroes(int[] nums)
    {
        int freeIndex = 0;

        for (int numIndex = 0; numIndex < nums.Length; numIndex++)
        {
            int num = nums[numIndex];

            if (num != TARGET)
            {
                Swap(numIndex, freeIndex);
                freeIndex++;
            }
        }

        void Swap(int i, int j)
        {
            if (i != j)
            {
                int buffer = nums[i];
                nums[i] = nums[j];
                nums[j] = buffer;
            }
        }
    }
}

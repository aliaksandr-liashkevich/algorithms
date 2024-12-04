public class Solution
{
    // Time: O(n)
    // Space: O(1)
    public int MaxArea(int[] heights)
    {
        int l = 0;
        int r = heights.Length - 1;

        int answer = 0;

        while (r > l)
        {
            int height = Math.Min(heights[l], heights[r]);
            int width = r - l;
            int area = height * width;

            answer = Math.Max(answer, area);

            if (heights[l] > heights[r])
            {
                r--;
            }
            else
            {
                l++;
            }
        }

        return answer;
    }
}

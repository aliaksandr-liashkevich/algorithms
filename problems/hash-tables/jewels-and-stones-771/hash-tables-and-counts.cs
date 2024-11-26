public class Solution
{
    // n - the length of jewels, m - the length of stones
    // Time: O(max(n, m))
    // Space: O(n)
    public int NumJewelsInStones(string jewels, string stones)
    {
        HashSet<char> jewelSet = new(jewels);

        int answer = 0;

        foreach (char stone in stones)
        {
            if (jewelSet.Contains(stone))
            {
                answer++;
            }
        }

        return answer;
    }
}

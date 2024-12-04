// https://www.interviewbit.com/problems/intersection-of-sorted-arrays/

class Solution
{
    // Time: O(a + b)
    // Space: O(min(a, b))
    public List<int> intersect(List<int> a, List<int> b)
    {
        int pA = 0;
        int pB = 0;

        List<int> answer = new List<int>(Math.Min(a.Count, b.Count));

        while (pA < a.Count && pB < b.Count)
        {
            if (a[pA] > b[pB])
            {
                pB++;
            }
            else if (a[pA] < b[pB])
            {
                pA++;
            }
            else
            {
                answer.Add(a[pA]);
                pA++;
                pB++;
            }
        }

        return answer;
    }
}

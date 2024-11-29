public class Solution
{
    // Time: O(n)
    // Space: O(1)
    public void ReverseString(char[] s)
    {
        int l = 0;
        int r = s.Length - 1;

        while (r > l)
        {
            Swap(l, r);
            l++;
            r--;
        }

        void Swap(int l, int r)
        {
            char buffer = s[l];
            s[l] = s[r];
            s[r] = buffer;
        }
    }
}

public class Solution
{
    // n1 - the length of nums1
    // n2 - the length of nums2
    // Time: O(n1 + n2)
    // Space: O(1)
    public void Merge(int[] nums1, int n1, int[] nums2, int n2)
    {
        int p1 = n1 - 1;
        int p2 = n2 - 1;
        int pLast = (n1 + n2) - 1;

        while (p1 >= 0 && p2 >= 0)
        {
            if (nums1[p1] > nums2[p2])
            {
                nums1[pLast] = nums1[p1];
                p1--;
            }
            else
            {
                nums1[pLast] = nums2[p2];
                p2--;
            }

            pLast--;
        }

        while (p1 >= 0)
        {
            nums1[pLast] = nums1[p1];
            p1--;
            pLast--;
        }

        while (p2 >= 0)
        {
            nums1[pLast] = nums2[p2];
            p2--;
            pLast--;
        }
    }
}

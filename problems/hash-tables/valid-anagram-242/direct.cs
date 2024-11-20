public class Solution {
    // Time: O(n * log n)
    // Space: O(n)
    public bool IsAnagram(string s, string t) {
        string orderedS = new string(s.OrderBy(x => x).ToArray());
        string orderedT = new string(t.OrderBy(x => x).ToArray());
        return orderedS == orderedT;
    }
}
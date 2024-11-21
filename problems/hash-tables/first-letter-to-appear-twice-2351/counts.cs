public class Solution {
    // Time: O(n)
    // Space: O(1)
    public char RepeatedCharacter(string s) {
        int[] counts = new int['z' - 'a' + 1];

        foreach (char letter in s)
        {
            int i = letter - 'a';
            counts[i]++;

            if (counts[i] == 2)
            {
                return letter;
            }
        }

        return default(char);
    }
}

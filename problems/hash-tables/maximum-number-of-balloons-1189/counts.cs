public class Solution {
    // Time: O(n)
    // Space: O(1)
    public int MaxNumberOfBalloons(string text) {
        Dictionary<char, int> countsByBallonChar = new Dictionary<char, int>()
        {
            { 'b', 0 },
            { 'a', 0 },
            { 'l', 0 },
            { 'o', 0 },
            { 'n', 0 },
        };

        foreach (char letter in text)
        {
            if (countsByBallonChar.ContainsKey(letter))
            {
                countsByBallonChar[letter]++;
            }
        }

        countsByBallonChar['l'] /= 2;
        countsByBallonChar['o'] /= 2;

        return countsByBallonChar.Select(x => x.Value).Min();
    }
}

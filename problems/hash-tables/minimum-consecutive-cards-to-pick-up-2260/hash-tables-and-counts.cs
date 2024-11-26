public class Solution {
    // Time: O(n)
    // Space: O(n)
    public int MinimumCardPickup(int[] cards) {
        Dictionary<int, int> indexByCard = new();

        int answer = int.MaxValue;

        for (int index = 0; index < cards.Length; index++)
        {
            int card = cards[index];

            if (indexByCard.TryGetValue(card, out int previousIndex))
            {
                answer = Math.Min(answer, index - previousIndex + 1);
            }

            indexByCard[card] = index;
        }

        return answer == int.MaxValue ? -1 : answer;
    }
}

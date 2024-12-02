// string[] answer = new Solution().GenerateCombinations("abc");

// bool isPassed = answer.SequenceEqual(["a", "b", "c", "ab", "ac", "bc", "abc"]);

public class Solution
{
    // Time: O(2^n) + O(2^n * log(2^n)) ~ O(2^n * log(2^n))
    // Space: O(2^n)
    public string[] GenerateCombinations(string s)
    {
        if (s.Length == 0)
        {
            return new string[0];
        }

        int numberOfAllCombinations = (int)Math.Pow(2, s.Length) - 1;
        string[] answer = new string[numberOfAllCombinations];

        // O(2^n)
        for (int index = 0; index < numberOfAllCombinations; index++)
        {
            StringBuilder sb = new();
            int sIndex = 0;
            int sequence = index + 1;

            while (sequence > 0)
            {
                if ((sequence & 1) == 1)
                {
                    sb.Append(s[sIndex]);
                }

                sequence >>= 1;
                sIndex++;
            }

            answer[index] = sb.ToString();
        }

        // O(2^n * log(2^n))
        Array.Sort(answer, (a, b) =>
        {
            return a.Length == b.Length
                ? a.CompareTo(b)
                : a.Length - b.Length;
        });

        return answer;
    }
}

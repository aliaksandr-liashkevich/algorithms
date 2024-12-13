// var answer = new Solution().GenerateCombinations("abc");

// bool isPassed = answer.SequenceEqual(["a", "b", "c", "ab", "ac", "bc", "abc"]);

public class Solution
{
    // Time: O(2^n) + O(2^n * log(2^n)) ~ O(2^n * log(2^n))
    // Space: O(2^n) + O(n)
    public string[] GenerateCombinations(string s)
    {
        if (s.Length == 0)
        {
            return new string[0];
        }

        List<string> answer = new();

        // O(2^n)
        Bruteforce(index: 0, currComb: new StringBuilder());

        // O(2^n * log(2^n))
        answer.Sort((a, b) =>
        {
            return a.Length == b.Length
                ? a.CompareTo(b)
                : a.Length - b.Length;
        });

        return answer.ToArray();

        void Bruteforce(int index, StringBuilder currComb)
        {
            if (index == s.Length)
            {
                if (currComb.Length > 0)
                {
                    answer.Add(currComb.ToString());
                }

                return;
            }

            currComb.Append(s[index]);
            Bruteforce(index + 1, currComb);
            currComb.Remove(currComb.Length - 1, 1);

            Bruteforce(index + 1, currComb);
        }
    }
}

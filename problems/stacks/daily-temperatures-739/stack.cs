public class Solution
{
    // Time: O(n)
    // Space: O(n)
    public int[] DailyTemperatures(int[] temperatures)
    {
        if (temperatures.Length == 0)
        {
            return new int[0];
        }

        Stack<int> prevIndexStack = new();

        int[] answer = new int[temperatures.Length];

        for (int currIndex = 0; currIndex < temperatures.Length; currIndex++)
        {
            int curr = temperatures[currIndex];

            while (prevIndexStack.Count > 0 && curr > temperatures[prevIndexStack.Peek()])
            {
                int prevIndex = prevIndexStack.Pop();
                answer[prevIndex] = currIndex - prevIndex;
            }

            prevIndexStack.Push(currIndex);
        }

        while (prevIndexStack.Count > 0)
        {
            answer[prevIndexStack.Pop()] = 0;
        }

        return answer.ToArray();
    }
}

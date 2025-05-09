public class Solution
{
    // Time: O(n)
    // Space: O(n)
    public bool CanFinish(int numCourses, int[][] prerequisites)
    {
        List<int>[] matrix = new List<int>[numCourses];

        for (int course = 0; course < numCourses; course++)
        {
            matrix[course] = new List<int>();
        }

        for (int i = 0; i < prerequisites.Length; i++)
        {
            int to = prerequisites[i][0];
            int from = prerequisites[i][1];

            matrix[from].Add(to);
        }

        State[] states = new State[numCourses];

        return !HasCycle();

        bool HasCycle()
        {
            Stack<int> courseStack = new();

            int course = 0;

            while (course < numCourses)
            {
                int currentCourse = courseStack.Count > 0 ? courseStack.Pop() : course++;

                courseStack.Push(currentCourse);
                MarkAs(currentCourse, State.Visiting);

                bool hasUnvisitedNeighbor = false;

                foreach (int nextCourse in matrix[currentCourse])
                {
                    if (states[nextCourse] == State.Visiting)
                    {
                        return true;
                    }

                    if (states[nextCourse] == State.NotVisited)
                    {
                        courseStack.Push(nextCourse);
                        hasUnvisitedNeighbor = true;
                        break;
                    }
                }

                if (!hasUnvisitedNeighbor)
                {
                    courseStack.Pop();
                    MarkAs(currentCourse, State.Visited);
                }
            }

            return false;
        }

        void MarkAs(int course, State state)
            => states[course] = state;
    }

    private enum State
    {
        // White
        NotVisited = 0,
        // Grey
        Visiting = 1,
        // Black
        Visited = 2
    }
}

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

        for (int course = 0; course < numCourses; course++)
        {
            if (HasCycle(course))
            {
                return false;
            }
        }

        return true;

        bool HasCycle(int course)
        {
            if (states[course] == State.Visiting)
            {
                return true;
            }

            if (states[course] == State.Visited)
            {
                return false;
            }

            MarkAs(course, State.Visiting);

            foreach (int nextCourse in matrix[course])
            {
                if (HasCycle(nextCourse))
                {
                    return true;
                }
            }

            MarkAs(course, State.Visited);

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

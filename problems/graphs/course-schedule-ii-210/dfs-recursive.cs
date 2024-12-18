public class Solution
{
    // Time: O(n)
    // Space: O(n)
    public int[] FindOrder(int numCourses, int[][] prerequisites)
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

        IList<int> orderedCourses = new List<int>();

        for (int course = 0; course < numCourses; course++)
        {
            if (!FillOrderedCoursesIfNoCycles(course))
            {
                return Array.Empty<int>();
            }
        }

        return orderedCourses.Reverse().ToArray();

        bool FillOrderedCoursesIfNoCycles(int course)
        {
            bool hasCycle = states[course] == State.Visiting;

            if (hasCycle)
            {
                return false;
            }

            if (states[course] == State.Visited)
            {
                return true;
            }

            MarkAs(course, State.Visiting);

            foreach (int nextCourse in matrix[course])
            {
                if (!FillOrderedCoursesIfNoCycles(nextCourse))
                {
                    return false;
                }
            }

            MarkAs(course, State.Visited);
            orderedCourses.Add(course);

            return true;
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

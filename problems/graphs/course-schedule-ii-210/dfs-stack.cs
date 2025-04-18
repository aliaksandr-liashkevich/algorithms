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

        return FillOrderedCoursesIfNoCycles()
            ? orderedCourses.Reverse().ToArray()
            : Array.Empty<int>();

        bool FillOrderedCoursesIfNoCycles()
        {
            Stack<int> courseStack = new();

            for (int course = 0; course < numCourses; course++)
            {
                if (states[course] == State.NotVisited)
                {
                    courseStack.Push(course);
                }

                while (courseStack.Count > 0)
                {
                    int currentCourse = courseStack.Peek();

                    MarkAs(currentCourse, State.Visiting);

                    bool allNeighborsVisited = true;

                    foreach (int nextCourse in matrix[currentCourse])
                    {
                        bool hasCycle = states[nextCourse] == State.Visiting;

                        if (hasCycle)
                        {
                            return false;
                        }

                        if (states[nextCourse] == State.NotVisited)
                        {
                            courseStack.Push(nextCourse);
                            allNeighborsVisited = false;
                            break;
                        }
                    }

                    if (allNeighborsVisited)
                    {
                        courseStack.Pop();
                        MarkAs(currentCourse, State.Visited);
                        orderedCourses.Add(currentCourse);
                    }
                }
            }

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

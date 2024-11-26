// IList<IList<IList<int>>> stats = new List<IList<IList<int>>>()
// {
//     new List<IList<int>>()
//     {
//         new List<int>() { 2, 4000 }, new List<int>() { 1, 500 }, new List<int>() { 3, 2500 },
//     },
//     new List<IList<int>>()
//     {
//         new List<int>() { 1, 5000 }, new List<int>() { 3, 150 }, new List<int>() { 2, 1000 },
//     },
//     new List<IList<int>>()
//     {
//         new List<int>() { 2, 3420 }, new List<int>() { 1, 10_000 }, new List<int>() { 3, 12_850 },
//     }
// };

// IList<int> result = new Solution().FindCompetitionWinners(stats);
// bool isPassed = result.SequenceEqual([1, 3]);

public class Solution
{
    // n - the total number of days
    // m - the max. number of participants per day
    // Time: O(n * m) + O(m) + O(m log m) ~ O(n * m) + O(m log m)
    // k - the total number of participants
    // Space: O(k)
    public IList<int> FindCompetitionWinners(IList<IList<IList<int>>> stats)
    {
        int totalDays = stats.Count;
        int maxStepsForTotalDays = 0;
        Dictionary<int, (int Days, int Steps)> dayStepsByParticipantId = new();

        // O(n * m)
        foreach (IList<IList<int>> dayStats in stats)
        {
            foreach (IList<int> participantStat in dayStats)
            {
                int participantId = participantStat[0];
                int completedSteps = participantStat[1];

                (int currDays, int currSteps) = dayStepsByParticipantId.GetValueOrDefault(participantId);

                int days = currDays + 1;
                int steps = currSteps + completedSteps;

                dayStepsByParticipantId[participantId] = (days, steps);

                if (days == totalDays)
                {
                    maxStepsForTotalDays = Math.Max(maxStepsForTotalDays, steps);
                }
            }
        }

        if (maxStepsForTotalDays == 0)
        {
            return new List<int>();
        }

        List<int> answer = new();

        // O(m)
        foreach (KeyValuePair<int, (int Days, int Steps)> dayStepByParticipantId in dayStepsByParticipantId)
        {
            int participantId = dayStepByParticipantId.Key;
            (int days, int steps) = dayStepByParticipantId.Value;

            if (days == totalDays && steps == maxStepsForTotalDays)
            {
                answer.Add(participantId);
            }
        }

        // O(m log m)
        answer.Sort();

        return answer;
    }
}

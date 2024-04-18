namespace LeetCodeProblems.Intervals;
public class InsertInterval
{
    // intuition
    // because we don't need to modify the array in place this should be fairly straight forward
    // iterate over the intervals array adding the intervals to a new array
    // if we find any interval whose start overlaps with the new interval, merge them
    // if we reach an interval whose start is larger than the new interval, first insert the new interval

    // this should be O(n) time and space complexity 
    // because we'll be interating over the array only once and we'll be storing a new array the size of the input array plus one

    // edge case - handle intervals being empty
    // edge case - handle new interval being empty
    // edge case - handle new interval being the largest interval
    // edge case - handle new interval being the smallest interval
    // edge case - handle new interval with the only interval in intervals

    public int[][] Insert(int[][] intervals, int[] newInterval)
    {
        if (intervals.Length == 0) return [newInterval];
        if (newInterval.Length == 0) return intervals;

        List<int[]> output = new();

        foreach (int[] interval in intervals)
        {
            if (interval[0] > newInterval[1])
            {
                output.Add(newInterval);
                newInterval = interval;
            }
            else if (interval[1] < newInterval[0])
            {
                output.Add(interval);
            }
            else
            {
                newInterval[0] = Math.Min(newInterval[0], interval[0]);
                newInterval[1] = Math.Max(newInterval[1], interval[1]);
            }
        }

        output.Add(newInterval);

        return output.ToArray();
    }

    public int[][] InsertB(int[][] intervals, int[] newInterval)
    {
        if (intervals.Length == 0) return [newInterval];
        if (newInterval.Length == 0) return intervals;

        List<int[]> output = new();

        for (int i = 0; i < intervals.Length; i++)
        {
            int[] interval = intervals[i];

            if (interval[0] > newInterval[1])
            {
                output.Add(newInterval); 
                output.AddRange(intervals[i..].ToList());
                return output.ToArray(); // this approach actually seems slower. Maybe the tolist and addrage are slower than simply finishing iterating through the intervals
            }
            else if (interval[1] < newInterval[0])
            {
                output.Add(interval);
            }
            else
            {
                newInterval[0] = Math.Min(newInterval[0], interval[0]);
                newInterval[1] = Math.Max(newInterval[1], interval[1]);
            }
        }

        output.Add(newInterval);

        return output.ToArray();
    }
}

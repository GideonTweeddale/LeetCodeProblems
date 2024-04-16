namespace LeetCodeProblems.Intervals;
public class MergeIntervals
{
    // intuition
    // we need to store each interval in a way that can be efficiently looked up
    // we need to know when our starting value is lower than an existing ending value

    // first we sort the intervals by starting value

    // then we put the first interval in our output array

    // then we iterate over the intervals
    // for each inteval, we compare it with the last interval in the output list
    // if the first value of the interval is smaller than or equal to the last value in the output pair
    // we update the the pair in the output array with the smaller first value and larger last value
    // if it is not, then we add the pair to the array

    // question - is it possible to have a super interval that fully wraps another interval? - we handle this just in case
    // question - are the intervals sorted? They appear to be. // They are not.
    // are the lower values always first in an interval? I am going to assume that they are. // Aparently they are.

    public int[][] Merge(int[][] intervals)
    {
        List<int[]> output = [];
        if (intervals.Length == 0) return output.ToArray();

        Array.Sort(intervals, (a, b) => a[0] - b[0]);

        output.Add(intervals[0]);

        foreach (int[] interval in intervals)
        {
            int start = interval[0];
            int end = interval[1];
            int lastEnd = output[^1][1];

            if (start <= lastEnd)
                output[^1][1] = Math.Max(output[^1][1], end);
            else
                output.Add(interval);
        }

        return output.ToArray();
    }
}

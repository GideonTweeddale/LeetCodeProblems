namespace LeetCodeProblems.Intervals;
public class NonOverlappingIntervals
{
    // intuition
    // once we have sorted the intervals
    // we can find the minimum number of intervals to remove by comparing the start value of each interval to the lowest possible end value of our remaining intervals
    // in other words, when we have an overlap, starting with the first two intervals, we can remove the one with the higher end value
    // thus keeping the lower of the two end values to compare with our next interval
    // if there is no overlap, then we simply take the end value of the current interval as the new end value to compare with the next interval
    // in this case, we don't actually need to remove any intervals, we just need to keep track of the count of intervals that we would have removed
    // and keep track of the last lowest possible end value

    // intervals [1,2] and [2,3] aren't considered overlapping 

    // is the intervals array sorted? I don't think it is.

    // time complexity is O(n log n) becuase we sort the intervals first

    public int EraseOverlapIntervals(int[][] intervals)
    {
        int count = 0;

        if (intervals.Length == 0)
        {
            return count;
        }

        Array.Sort(intervals, (a, b) => a[0] - b[0]);

        int lastEnd = intervals[0][1];

        foreach (int[] interval in intervals[1..])
        {
            int start = interval[0];
            int end = interval[1];

            if (start >= lastEnd)
            {
                lastEnd = end;
            }
            else
            {
                count++;
                lastEnd = Math.Min(lastEnd, end);
            }
        }

        return count;
    }
}

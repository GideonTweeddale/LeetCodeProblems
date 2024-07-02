namespace LeetCodeProblems.Intervals;
public class MinimumNumberOfArrowsToBurstBalloons
{
    // intuition
    // this is an interval problem
    // we need to find the set of disjointed intervals 
    // we can do this by removing all the overlaps 
    // the minimum number of arrows, will be the same as the count of non overlapping intervals

    // to find the disjointed intervals 
    // we can sort the input array by the start value of each interval
    // then for each interval
    // we check if its start value is less than the end value of the previous interval in our disjointed intervals set
    // if it is, we merge it with the previous interval by taking the smaller of the two end values
    // if it is not, we add the interval to the disjointed interval set
    // then we check the next interval
    // when we reach the end of our intervals array, we can return the count of the disjointed intervals

    // note - we don't actually need to keep track of the disjointed intervals for this example
    // we just need to keep track of the count of disjointed intervals
    // and the end value of the last disjointed interval

    // do intervals with overlapping points only, count as overlapping intervals? For example, [1,2] and [2,3]. Yes they do.

    // time complexity is O(n log n) because we sort the intervals first

    public static int FindMinArrowShots(int[][] points)
    {
        if (points.Length == 0)
        {
            return 0;
        }

        Array.Sort(points, (a, b) => a[0].CompareTo(b[0]));

        foreach (int[] point in points)
        {
            Console.WriteLine($"[{point[0]},{point[1]}]");
        }

        int previousEnd = points[0][1];
        int count = 1;

        foreach (int[] interval in points[1..])
        {
            (int start, int end) = (interval[0], interval[1]);

            if (start <= previousEnd)
            {
                previousEnd = Math.Min(previousEnd, end);
            }
            else
            {
                count++;
                previousEnd = end;
            }
        }

        return count;
    }


    // debugging statements
    // foreach (int[] point in points) Console.WriteLine($"[{point[0]},{point[1]}]");
    // Console.WriteLine($"[{start},{end}] - {previousEnd}");
}

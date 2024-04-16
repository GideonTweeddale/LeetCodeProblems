﻿namespace LeetCodeProblems.Intervals;
public class IntervalListIntersections
{
    // intuition
    // this is a suprisingly real world problem. We'd need this for any kind of scheduling.

    // if either list is empty, return an empty list because there can be no intersections with nothing

    // combine the lists into a single list and sort it by the start value of the intervals
    // add the first element to a new overlap list
    // create a result list
    // for each element in the combined sorted list
    // compare it to the most recent element in the overlap list
    // if the start value of the interval is less than or equal to the end value of the last value in the overlap list, we have an overlap
    // update the value in the overlap list with the greater end value
    // add the inner values as a new interval to the result list

    // what does pairwise disjoint mean? It means that none of the intervals within each set overlap any other intervals within the same set.
    // do we include the outer elements? Yes. Sets [1,2] and [2,3] are considered to overlap at [2].
    // are the lists already sorted?

    // time complexity is O(n log n) where n is the combined firstList.length + secondList.Length becuase we sort the intervals first

    public int[][] IntervalIntersection(int[][] firstList, int[][] secondList)
    {
        List<int[]> results = [];

        if (firstList.Length == 0 || secondList.Length == 0) return [];

        int[][] combined = firstList.Concat(secondList).ToArray();

        Array.Sort(combined, (a, b) => a[0] - b[0]);

        List<int[]> temp = [combined[0]];

        for (int i = 1; i < combined.Length; i++) 
        {
            int[] interval = combined[i];
            int start = interval[0];
            int end = interval[1];
            int lastEnd = temp[^1][1];

            if (start <= lastEnd)
            {
                temp[^1][1] = Math.Max(end, lastEnd);
                results.Add([start, Math.Min(end, lastEnd)]);
            }
            else
            {
                temp.Add(interval);
            }
        }

        return results.ToArray();
    }
}

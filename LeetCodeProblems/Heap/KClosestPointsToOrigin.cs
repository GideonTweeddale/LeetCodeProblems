namespace LeetCodeProblems.Heap;
public class KClosestPointsToOrigin
{
    // intuition
    // the square root because if the square root of x is greater than the square root of y then x is greater than y
    // we only need to know which uclidiean distance is greater, not the actual distance, so we don't need to take the square root

    // if we iterate through our points adding them to a heap
    // we can return the first k elements from the heap.
    // Once our heap is k elements, we could also remove the furthest element with each iteration, so that adding future elements is more efficient

    // the time complexity is O(n log k) because we are iterating over n elements and adding to the heap is O(log k)
    // the space complexity is O(k) because we are only storing k elements in the heap

    public int[][] KClosest(int[][] points, int k)
    {
        // sanity check
        if (points == null || points.Length == 0 || k == 0)
        {
            return [];
        }

        // if we need all the points, then we don't need to do anything
        if (points.Length == k)
        {
            return points;
        }

        PriorityQueue<int[], int> heap = new();

        foreach (int[] point in points)
        {
            // add the negative to reverse the order of the heap - effectively turning it into a max heap
            heap.Enqueue(point, -(point[0] * point[0] + point[1] * point[1]));

            // keep the heap size at k
            if (heap.Count > k)
            {
                heap.Dequeue();
            }
        }

        List<int[]> result = new();

        for (int i = 0; i < k; i++)
        {
            result.Add(heap.Dequeue());
        }

        return result.ToArray();
    }
}
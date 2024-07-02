namespace LeetCodeProblems.Heap;
public class FindKPairsWithSmallestSums
{
    // intuition
    // because the arrays are already sorted and we can only use items from the arrays once we shouldn't need to iterate over the entire arrays
    // in fact, becuase each value must be larger than or equal to the previous value in both arrays, it isn't possible for a later pair to be smaller than a previous pair
    // meaning that we only need to consider k elemnts from each array

    // examples
    // k=3, [1,2,3], [1,7,8] -> [1,1], [1,2], [1,7], [1,3], [1,8], [2,7], [2,8], [7,3], [3,8] -> [1,1], [1,2], [1,3]
    // k=5, [1,2,3], [1,7,8] -> [1,1], [1,2], [1,7], [1,3], [1,8], [2,7], [2,8], [7,3], [3,8] -> [1,1], [1,2], [1,3], [1,7], [2,7]

    // the smallest sum is always index i,j where i=0 and j=0 
    // the smallest remaining sum is either i+i,j or i,j+1

    // to solve this we initialise a heap and a set with 0,0
    // we can iterate over the arrays k times
    // and then pop the lowest value from the heap and add it to our results and save it's idices as i,j
    // we then take i+i,j and i,j+1 indices to the heap and the set if we haven't already added them to the set (this will add both on the first iteration and only one on each subsequent iteration)
    // then decrement k by 1

    // observation
    // I tried initialising the heap and the result list with k+1 and k length respectively
    // this was slower and slightly more memory efficient
    // weird

    // time complexity is O(klogk) because we are only iterating k times and adding to the heap is O(logk)

    public static IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k)
    {
        IList<IList<int>> result = [];

        // sanity check
        if (nums1 == null || nums2 == null || k == 0)
        {
            return result;
        }

        PriorityQueue<(int, int), int> heap = new();
        HashSet<(int, int)> visited = new();

        heap.Enqueue((0, 0), nums1[0] + nums2[0]);
        visited.Add((0, 0));

        while (k > 0 && heap.Count > 0)
        {
            (int i, int j) = heap.Dequeue();
            result.Add(new List<int> { nums1[i], nums2[j] });

            if (i + 1 < nums1.Length && !visited.Contains((i + 1, j)))
            {
                heap.Enqueue((i + 1, j), nums1[i + 1] + nums2[j]);
                visited.Add((i + 1, j));
            }

            if (j + 1 < nums2.Length && !visited.Contains((i, j + 1)))
            {
                heap.Enqueue((i, j + 1), nums1[i] + nums2[j + 1]);
                visited.Add((i, j + 1));
            }

            k--;
        }

        return result;
    }
}
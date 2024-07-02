namespace LeetCodeProblems.Heap;
public class KthLargestElementInAnArray
{
    // intuition
    // the naive solutions all involve sorting - so the do it without sorting requirement is interesting
    // using a heap is the obvious solution which would be O(n + k log n) time complexity

    // this is O(n log n) time complexity
    public static int FindKthLargestNaive(int[] nums, int k)
    {
        return nums.OrderByDescending(x => x).ElementAt(k - 1);
    }

    // using heap - this is O(n + k log n) time complexity, but somehow almost 50% slower than the naive solution
    public static int FindKthLargestHeap(int[] nums, int k)
    {
        PriorityQueue<int, int> heap = new();

        foreach (int num in nums)
        {
            heap.Enqueue(num, num);

            if (heap.Count > k)
            {
                heap.Dequeue();
            }
        }

        return heap.Dequeue(); // this will be the kth largest element because we are using a min heap and we are removing the smallest element when the heap size is greater than k
    }

    // using quick select - this is O(n) time complexity in the average case but O(n^2) in the worst case
    // I'm not 100% I understand why this is O(n) time complexity in the average case not (log n) time complexity
    // leetcode has also added a test case that deliberatly causes the worst case time complexity to be triggered and therefore times this solution out
    public static int FindKthLargestQuickSelect(int[] nums, int k)
    {
        return QuickSelect(0, nums.Length - 1);

        // helper function to do the quick select
        int QuickSelect(int left, int right)
        {
            int pivot = nums[right];
            int i = left;

            // partition the array around the pivot by swapping all elements less than or equal to the pivot to the left of the pivot
            for (int j = left; j < right; j++)
            {
                if (nums[j] <= pivot)
                {
                    // swap nums[i] and nums[j]
                    (nums[i], nums[j]) = (nums[j], nums[i]);
                    i += 1;
                }
            }

            // swap the pivot with the element at index i
            (nums[i], nums[right]) = (nums[right], nums[i]);

            // select our recursion
            if (i > nums.Length - k) // if our index is greater than the index we are looking for go left
            {
                return QuickSelect(left, i - 1);
            }
            else if(i < nums.Length - k) // if our index is less than the index we are looking for go right
            {
                return QuickSelect(i + 1, right);
            }
            else // our index must be the kth largest element - and we know that the index is now in the correct place in the sort order so we can return it
            {
                return nums[i];
            }
        }
    }
}
namespace LeetCodeProblems.BinarySearch;
public class FindPeakElement162
{
    // intuition
    // the O(log n) requirement means that we need to use binary search
    // because we don't need to find all, or even the highest, peaks we just need to be sure that we pick the half of the search space
    // that is guaranteed to have a local maximum with each iteration
    // we can do this by comparing our midpoint with the elements either side of it
    // if it is larger than both, excellent, we have a peak
    // if the left element is the largest, it will either be larger than its own left element or it won't all the way to the edge which will itself be a peak 
    // (due to the fact that all elements are considered larger than out of bounds and no neighbouring elements are the same)
    // the same is true for the right element
    // so we can always go in the direction of the larger of the two elements and be guaranteed to find a local maximum

    public int FindPeakElement(int[] nums)
    {
        int peak = 0;
        int leftIndex = 0;
        int rightIndex = nums.Length - 1;   
        
        while (leftIndex <= rightIndex)
        {
            int mid = leftIndex + (rightIndex - leftIndex) / 2;

            if (mid > 0 && nums[mid] < nums[mid - 1])
            {
                rightIndex = mid - 1;
            }
            else if (mid < nums.Length - 1 && nums[mid] < nums[mid + 1])
            {
                leftIndex = mid + 1;
            }
            else
            {
                return mid;
            }
        }

        return peak;
    }
}


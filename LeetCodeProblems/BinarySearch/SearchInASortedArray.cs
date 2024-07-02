namespace LeetCodeProblems.BinarySearch;
public class SearchInAsortedArray
{
    // intuition
    // the search in O(log n) time requirement suggests binary search
    // we can tell if we need to search to the left or right of our midpoint by the comparing to the last element on the right
    // our values will be in ascending order except between the highest and the lowest values
    // therefore, if the right value is smaller than our value, we need to search to the right
    // and if it is larger, we need to search to the left
    // we return the index if our midpoint value equals our target
    // if we reach leftIndex == rightIndex, the value isn't in the array, so return -1

    public static int Search(int[] nums, int target)
    {
        int left = 0;
        int right = nums.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (nums[mid] == target)
            {
                return mid;
            }

            else if (nums[left] <= nums[mid])
            {
                if (nums[left] <= target && target < nums[mid])
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            else
            {
                if (nums[mid] < target && target <= nums[right])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
        }

        return -1; // target not found in array
    }
}


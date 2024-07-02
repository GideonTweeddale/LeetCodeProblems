namespace LeetCodeProblems.BinarySearch;
public class FindFirstAndLastPositionOfElementInSortedArray
{
    // we could do binary search and then some sort of expand function
    // but in the worst case that could be O(n) where all elements in the array are the same

    // we need to do binary search here
    // we could search for one less and one more
    // and then check the inedexes immidiately to the left and right
    // but that would run into the same issue with duplicates in arrays with multiple sets of duplicates

    // we could make this a recursive search
    // if we find our value, we check the idexes left and right of it
    // if neither equal our target, we can return our current index
    // if the left is less, we can set our left index
    // if the right is more, we can set out right index
    // if the left equals our target, call the binary search on the left subarray
    // if the right equals our target, call the binary search on the right subarray
    // do this recursively, until we have both a left and right index

    // huh. So the way to solve this is to search for the rightmost and the leftmost pointer in two separate searches
    // to do that, we keep searching left and right on each respective search
    // even after we've found a value
    // and only update the return index if we find another index further in the direction we are looking

    public static int[] SearchRange(int[] nums, int target) {
        int leftIndex = BinarySearch(nums, target, true);
        int rightIndex = BinarySearch(nums, target, false);
        return [leftIndex, rightIndex];
    }

    private static int BinarySearch(int[] nums, int target, bool findLeftmost)
    {
        int left = 0;
        int right = nums.Length - 1;
        int index = -1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (nums[mid] == target)
            {
                index = mid;
            }
            
            if (nums[mid] > target) 
            {
                right = mid - 1;
            }
            else if (nums[mid] < target)
            {
                left = mid + 1;
            }
            else if (findLeftmost)
            {
                right = mid - 1;
            }
            else 
            {
                left = mid + 1;
            }
        }

        return index;
    }
}


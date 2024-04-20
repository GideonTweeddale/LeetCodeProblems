namespace LeetCodeProblems.BinarySearch;
public class SearchInAsortedArrayII
{
    // intuition
    // yuck. Because of the duplicate values, we need to move our left pointer one step to the right if the value at the left pointer is the same as the value at the mid pointer.
    // meaning that in the worst case, where all values are duplicate and our target isn't in the array, we'll ahve to check every index making the time complexity O(n)
    // however, if the array hans't got duplicate values, the time complexity will be O(log n)
    // and if it only has some duplicates, it will be pretty close to O(log n) as well

    // to solve this we have a few different cases on each iteration
    // if the mid value is the same as the target, we have found the target
    // if our left and right pointers are the same, the target is not in the array
    // if the left value is the same as the mid value, we need to move the left pointer one step to the right
    // if the left value is less than the mid value, we that we are in the left sorted array
    //        if the target is also in the left sorted array, we search left otherwise we search right
    // if the left value is greater than the mid value, we are in the right sorted array
    //        if the target is also in the right sorted array, we search right otherwise we search left


    public bool Search(int[] nums, int target)
    {
        int left = 0;
        int right = nums.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (nums[mid] == target)
            {
                return true;
            }
            
            if (nums[left] < nums[mid]) // we are in the left sorted array
            {
                if (nums[left] <= target && target < nums[mid]) // our target is in the left sorted array
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            else if (nums[left] > nums[mid]) // we must be in the right sorted array
            {
                if (nums[mid] < target && target <= nums[right]) // our target is in the right sorted array
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            } 
            else // we can't know if we are in the left sorted array or the right sorted array
            {
                left++;
            }
        }

        return false; // target not found
    }
}


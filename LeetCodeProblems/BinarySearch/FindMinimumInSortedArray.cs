namespace LeetCodeProblems.BinarySearch;
public class FindMinimumInSortedArray
{
    // intuition
    // the O(log n) restriction means that we need to use binary search
    // this is complicated by the rotations, but it is still a sorted array
    // I don't think that there is any way unrotate the array efficiently
    // most importantly, the minimum element will still be recognisable because it will be lower than both of the surrounding elements
    // for all other elements, we compare to the last element in seach space
    // if the mid element is less than the last element seach left
    // if the mid element is greater than the last element search right
    // for example [3,4,5,6,7,1,2]
    // 6 > 2 so the min must be right
    // left becomes mid + 1, and mid becomes right - left / 2 or 1
    // mid is less than mid + 1, so return mid

    public int FindMin(int[] nums)
    {
        int min = nums[0];
        int leftIndex = 0;
        int rightIndex = nums.Length - 1;

        while (leftIndex <= rightIndex)
        {
            if (nums[leftIndex] < nums[rightIndex])
            {
                min = Math.Min(min, nums[leftIndex]);
                break;
            }

            int mid = (leftIndex + rightIndex) / 2;
            min = Math.Min(min, nums[mid]);

            if (nums[mid] >= nums[leftIndex])
            {
                leftIndex = mid + 1;
            }
            else
            {
                rightIndex = mid - 1;
            }
        }

        return min;
    }
}


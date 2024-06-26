namespace LeetCodeProblems.BinarySearch;
public class SearchInsertPosition
{
    // this is a binary search problem, where instead of returning false, we return the index where the item should be inserted
    // if the last item we look at is smaller than our target our left pointer will be one after the index
    // and if the last item is larger than our left pointer will be one before the index
    // meaning that we can just return our left pointer as the index to insert at if we don't find the index

    // this solution is O(log n) time with O(1) extra memory
    // because we use binary search and we use no extra memory    
    public int SearchInsert(int[] nums, int target) {
        int left = 0;
        int right = nums.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            
            if (nums[mid] < target)
            {
                left = mid + 1;
            }
            else if (nums[mid] > target)
            {
                right =  mid - 1;
            }
            else if (nums[mid] == target)
            {
                return mid; 
            }
        }
        
        return left;
    }
}


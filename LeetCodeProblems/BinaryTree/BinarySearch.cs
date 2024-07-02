namespace LeetCodeProblems.BinaryTree;
public class BinarySearch
{
    public int Search(int[] nums, int target)
    {
        int left = 0;
        int right = nums.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            int num = nums[mid];

            if (num == target)
            {
                return mid;
            }
            else if (num > target) // move left
            {
                right = mid - 1;
            }
            else // move right
            {
                left = mid + 1;
            }
        }

        return -1;
    }
}


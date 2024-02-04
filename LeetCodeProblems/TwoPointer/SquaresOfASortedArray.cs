namespace LeetCodeProblems.TwoPointer;
public class SquaresOfASortedArray
{
    public int[] SortedSquares(int[] nums)
    {
        // intuitively this problem can be solved in two steps
        // the first to square the numbers
        // and the second to sort them

        // this approach should be O(N)
        // using two pointers this inserts the square of the larger absolute number at the end of the array
        // and moves the pointer for the index of that number one place
        // this should give the result in a single pass of the array
        int left = 0;
        int right = nums.Length - 1;
        int i = right;
        int[] result = new int[nums.Length];
        int indexOfGreaterAbsolute;

        while (left <= right)
        {
            indexOfGreaterAbsolute = (Math.Abs(nums[left]) > Math.Abs(nums[right]))
                ? left++
                : right--;
            result[i--] = nums[indexOfGreaterAbsolute] * nums[indexOfGreaterAbsolute];
        }

        return result;
    }

    public int[] SortedSquaresB(int[] nums)
    {
        // this same approach should be possible with a for loop
        // I've also used an if instead of ternary to remove a weirdly scoped variable and because I think it is clearer
        int[] result = new int[nums.Length];
        int left = 0, right = nums.Length - 1;

        for (int i = nums.Length - 1; i >= 0; i--)
        {
            if (Math.Abs(nums[left]) > Math.Abs(nums[right]))
            {
                result[i] = nums[left] * nums[left];
                left++;
            } 
            else
            {
                result[i] = nums[right] * nums[right];
                right--;
            }
        }

        return result;
    }

    public int[] SortedSquaresC(int[] nums)
    {
        // is it also possible to fill the new array from the start instead of the end?
        // no - the ends work because we know that the largest absolute numbers will be at the ends of the array and so get compared first
        // we could start from the index of smallest value in the middle of the array, but we'd need to do a pass to identify that first
        int[] result = new int[nums.Length];
        int left = nums.Length / 2, right = (nums.Length / 2) + 1;

        for (int i = 0; i <= nums.Length - 1; i++)
        {
            if (Math.Abs(nums[left]) < Math.Abs(nums[right]))
            {
                result[i] = nums[left] * nums[left];
                left++;
            }
            else
            {
                result[i] = nums[right] * nums[right];
                right--;
            }
        }

        return result;
    }
}


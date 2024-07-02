namespace LeetCodeProblems.TwoPointer;
public class TwoSumIIInputArrayIsSorted
{
    // intuition
    // because the array is sorted in ascending order
    // we can use the two pointer approach
    // starting with the outer indexes, if the sum of the values is greater than the target we need to move the right pointer inwards
    // if the sum is smaller then we need to move the left pointer inwards

    // this will run in O(n) time in the worst case where the most inner pair of numbers is the solution
    // and in O(1) time because we don't need any additional data structures

    public static int[]? TwoSum(int[] numbers, int target)
    {
        int left = 0;
        int right = numbers.Length - 1;

        while (left < right)
        {
            // base case
            if (numbers[left] + numbers[right] == target)
            {
                return [left+1, right+1]; // add one becuase the return array is supposed to be 1-indexed
            }

            if (numbers[left] + numbers[right] > target)
            {
                right--;
            }
            else
            {
                left++;
            }
        }

        // we should never reach this - ideally the method definition should be changed to reflect the fact that we are guaranteed to have a valid sum
        // at the very least we should be throwing an error 
        return null; 
    }
}

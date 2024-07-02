namespace LeetCodeProblems.TwoPointer;
public class MoveZeroes283
{
    public static void MoveZeroes(int[] nums)
    {
        // the brute force solution would be to iterate through the list until we find a zero
        // and then to swap it forward one by one until the end

        // however, if we work through the array from the beginning and swap the each number we find to the earliest free index
        // it should maintain the ordering and move all the zeros to the end of the array in a single pass

        // this solution is O(N) time and O(1) space
        int freeIndex = 0;

        for (int currentIndex = 0; currentIndex < nums.Length; currentIndex++)
        {
            if (nums[currentIndex] != 0)
            {
                // move the number (zero) at the free index to the current index
                // set the free index to the number from the current index
                (nums[currentIndex], nums[freeIndex]) = (nums[freeIndex], nums[currentIndex]);
                
                freeIndex++;
            }
        }
    }
}


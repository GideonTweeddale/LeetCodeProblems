namespace LeetCodeProblems.Other;
public class FindMissingPositive41
{
    // intuition
    // this problem can be solved in O(n) time and space using a hashet
    // this is kinda a set intersection problem

    // we are trying to find the smallest non present positive integer
    // if we ordered the list, or had an array or set to mark off the integers we find this would be relatively simple
    // these options would break the O(n) time and O(1) space requirements

    // we could try to reuse our existing array by going through the array and for every positive integer marking the value at that index negative
    // then loop through the array and return the first positive index we find
    // however, the array contains negative numbers and they might happen to be at the index we need to be positive

    // it doesn't say that we need to preserve the array. So as we loop through it, we mark the indexes that are negative to be the max int value

    // will there always be a positive integer that isn't present in nums?
    public int FirstMissingPositive(int[] nums)
    {
        // remove our negatives so that we can use the negative to mark the found values
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] <= 0) nums[i] = nums.Length + 1;
        }

        for (int i = 0; i < nums.Length; i++) 
        {
            int num = Math.Abs(nums[i]);

            // shift the num to zero base the index
            num--;

            if (num < nums.Length && nums[num] > 0)
            {
                nums[num] = -nums[num];
            }
        }

        // loop though the indexes in nums and return the first positive index
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] > 0) return i + 1;
        }

        return nums.Length + 1;
    }
}

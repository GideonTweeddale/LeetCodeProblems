using System.Runtime.InteropServices;

namespace LeetCodeProblems.DP;
public class MaximumSubarray
{
    public int MaxSubArray(int[] nums)
    {
        // intuition
        // we need to keep track of the largest sum so far
        // and the current sum
        // for each new index
        // if the current sum is negative, start a new sum
        // add the next number to the current sum
        // if the current sum is larger than the largest sum so far, update the largest sum so far

        // this should be O(N) time and O(1) space

        // edit - nice
        // this solution is faster than 98.58% of C# submissions
        // and uses less memory than 57.71% of C# submissions
        // and solved quickly completely without help based on my initial intuition - feels good

        int max = nums[0];
        int sum = 0;

        foreach (int num in nums)
        {
            // if the sum is negative, start a new sum
            if (sum < 0) sum = 0;

            sum += num;

            // if the current sum is larger than the largest sum so far, update the largest sum so far
            max = Math.Max(max, sum);
        }

        return max;
    }
}


namespace LeetCodeProblems.DP;
public class MaximumSumCircularSubarray
{
    // we can find the linear array maximum using kadanes algorithm
    // and we can find the linear array minimum using kadanes algorithm

    // the answer will either be the linear array maximum
    // or the total minus the linear array minimum

    // this means that we can find the solution in a single pass using no extra memory
    // in other words, in O(n) time and O(1) space

    public static int MaxSubarraySumCircular(int[] nums) {
        int max = nums[0], min = nums[0];
        int localMax = 0, localMin = 0, total = 0;

        foreach (int num in nums)
        {
            total += num;
            localMax = Math.Max(localMax + num, num);
            localMin = Math.Min(localMin + num, num);
            max = Math.Max(max, localMax);
            min = Math.Min(min, localMin);
        }

        if (max > 0)
        {
            return Math.Max(max, total - min);
        }
        
        return max;
    }
}


namespace LeetCodeProblems.DP;
public class CombinationSumIV
{
    public static int CombinationSum4(int[] nums, int target)
    {
        // intuition
        // we can bottom up fill a dp array with the number of combinations that add up to the current number

        int[] dp = new int[target + 1];
        dp[0] = 1;

        for (int i = 1; i <= target; i++)
        {
            foreach (int num in nums)
            {
                if (i - num >= 0)
                {
                    dp[i] += dp[i - num];
                }
            }
        }

        return dp[target];
    }

    public static int CombinationSum4B(int[] nums, int target)
    {
        // intuition
        // we can use memoization to reduce the actual number of computations we need to do

        // sort the nums array so that we can iterate over the numbers in ascending order
        // this means that we can return early if the current number is greater than the remainder
        Array.Sort(nums);

        Dictionary<int, int> memo = [];

        int helper(int t)
        {
            if (memo.ContainsKey(t))
            {
                return memo[t];
            }

            if (t == 0)
            {
                return 1;
            }

            int count = 0;

            foreach (int num in nums)
            {
                if (t - num < 0)
                {
                    break;
                }

                count += helper(t - num);
            }

            memo[t] = count;
            return count;
        }

        return helper(target);
    }


}


namespace LeetCodeProblems.DP;
public class LongestIncreasingSubsequence
{
    public static int LengthOfLIS(int[] nums)
    {
        // this doesn't work becuase in a strict subsequence we aren't allowed to reorder the elements
        // are we allowed to loop?
        int length = 1;

        // a naive soluion would be to sort the array
        Array.Sort(nums);

        // and then to iterate over the array and check if the current element is greater than the previous element
        // if it is, then we increment the count
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] > nums[i - 1])
            {
                // increment the count
                length++;
            }
        }

        return length;
    }

    public static int LengthOfLISB(int[] nums)
    {
        if (nums.Length <= 1)
        {
            return 1;
        }

        // create a dp array to store the max length of the subsequence
        int[] dp = new int[nums.Length];

        // set all the values to 1 because the minimum length of a subsequence is 1
        Array.Fill(dp, 1);

        int max = 1;


        for (int i = 1; i < nums.Length; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (nums[i] > nums[j] && dp[i] <= dp[j])
                {
                    dp[i] = dp[j] + 1;
                    max = Math.Max(max, dp[i]);
                }
            }
        }

        return max;
    }
}


namespace LeetCodeProblems.DP;
public class PartitionToKEqualSumSubsets
{
    // intuition
    // 1. if the sum of the array is not divisible by k, return false
    // 2. this is a dp problem where we need to find all possible sums that can be formed from the array
    // 3. and also how many different ways they can be formed

    // this intuition was wrong
    // 4. we can use a dictionary whose keys are the possible sums and values are the number of ways they can be formed
    // we can iterate backwards through the array and for each number add it to all the previous possible sums
    // if the value is already a key in the dictionary, increment its count by 1
    // 6. if any one value is greater than the target the array can't be partitioned into k subsets - return false early
    public static bool CanPartitionKSubsets(int[] nums, int k)
    {
        // this doesn't work becuase it counts the same sum multiple times
        int sum = nums.Sum();
        int target = sum / k;

        if (sum % k != 0)
        {
            return false;
        }

        Dictionary<int, int> dp = new Dictionary<int, int> { { 0, 1 } };

        for (int i = nums.Length - 1; i >=0; i--)
        {
            if (nums[i] > target)
            {
                return false;
            }

            foreach (int t in dp.Keys.ToArray())
            {
                if (dp.ContainsKey(t + nums[i]))
                {
                    dp[t + nums[i]]++;
                }
                else
                {
                    dp[t + nums[i]] = 1;
                }
            }
        }

        return dp[target] >= k;
    }

    // 7. it is apparently possible to solve this problem using dp and a bitmask or using backtracking
    // here is the backtracking solution
    public static bool CanPartitionKSubsetsB(int[] nums, int k)
    {
        int sum = nums.Sum();
        int target = sum / k;

        if (sum % k != 0)
        {
            return false;
        }

        bool[] used = new bool[nums.Length];

        // sort descending - there has to be an easier way to do this in C#
        Array.Sort(nums, (int a, int b) => b.CompareTo(a));

        return Backtrack(0, k, 0);

        bool Backtrack(int i, int k, int subsetSum)
        {
            if (k == 0)
            {
                return true;
            }

            if (subsetSum == target)
            {
                return Backtrack(0, k - 1, 0);
            }

            for (int j = i; j < nums.Length; j++)
            {
                if (used[j] || subsetSum + nums[j] > target)
                {
                    continue;
                }

                used[j] = true;

                if (Backtrack(j + 1, k, subsetSum + nums[j]))
                {
                    return true;
                }

                used[j] = false;
            }

            return false;
        }
    }
}


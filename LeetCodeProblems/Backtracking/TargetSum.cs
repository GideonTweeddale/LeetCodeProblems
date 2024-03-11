namespace LeetCodeProblems.Backtracking;
public class TargetSum
{
    // backtracking solution
    public int FindTargetSumWaysBacktracking(int[] nums, int target)
    {
        // like most of the backtracking solutions, this would be O(N^2) time and space roughly

        int count = 0;

        void Backtrack(int i, int sum)
        {
            if (i == nums.Length)
            {
                if (sum == target) count++;
                return;
            }

            // add nums at i, increment i, and call backtrack
            Backtrack(i + 1, sum + nums[i]);

            // subtract nums at i, increment i, and call backtrack
            Backtrack(i + 1, sum - nums[i]);
        }

        Backtrack(0, 0);

        return count;
    }

    public int FindTargetSumWaysB(int[] nums, int target)
    {
        // this shoud be O(N * target) where n is number of elements in nums

        Dictionary<(int, int), int> dp = new();

        int Backtrack(int i, int current)
        {
            // the basecase
            if (i >= nums.Length)
            {
                return target == current ? 1 : 0;
            }

            // if we have already computed the subtree, return that instead
            if (dp.ContainsKey((current, i)))
            {
                return dp[(current, i)];
            }

            // call the backtrack function for the next index positive and negative
            dp[(current, i)] = Backtrack(i + 1, current - nums[i]) +
                                    Backtrack( i + 1, current + nums[i]);

            return dp[(current, i)];
        }

        return Backtrack(0, 0);
    }
}

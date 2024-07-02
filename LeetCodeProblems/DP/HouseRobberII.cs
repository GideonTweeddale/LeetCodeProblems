namespace LeetCodeProblems.DP;
public class HouseRobberII
{
    public int Rob(int[] nums)
    {
        // intuition
        // the solution can only include one of the first and last index 
        // so we can solve this by running the solution twice, once with the first index and once with the last index
        // this is then two subproblems with no circles in the them
        // the answer is the larger of the two subproblems
        // this means that we can reuse the solution to the HouseRobber problem
        
        // making this a O(2N) time and O(1) space solution

        if (nums.Length == 1)
        {
            return nums[0];
        }

        return Math.Max(rob(nums, 0, nums.Length - 2), rob(nums, 1, nums.Length - 1));
    }

    private int rob(int[] nums, int lo, int hi)
    {
        // this is O(N) time and O(1) space
        // for each index, chooses the larger of the previous largest sum plus the next num or the current num
        int previous = 0;
        int current = 0;

        for (int i = lo; i <= hi; i++)
        {
            int temp = Math.Max(previous + nums[i], current);
            previous = current;
            current = temp;
        }

        return current;
    }
}


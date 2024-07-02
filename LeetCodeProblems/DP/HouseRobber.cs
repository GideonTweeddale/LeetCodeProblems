namespace LeetCodeProblems.DP;
public class HouseRobber
{
    public int Rob(int[] nums)
    {
        // this naive solution is incorrect, because it does not account for situations where it is better to skip two or more indexes in a row

        // the naive solution to this problem is to iterate through the list, getting the sum of ever second number, starting at the first two indexes
        // this will complete in O(N) time and O(1) space
        // becase it needs only a single iteration through nums
        // and it needs only constant space 

        //int sum1, sum2 = 0;

        //for (int i1 = 0, i2 = 1; i2 <= nums.Length; i1 += 2, i2 += 2)
        //{
        //    sum1 += nums[i1];
        //    sum2 += nums[i2];
        //}

        // we could use a for loop here for brevity, but I feel that the while is more explicit
        int index = 0;
        int sum1 = 0;
        int sum2 = 0;

        while (index <= nums.Length - 1)
        {
            sum1 += nums[index];

            index += 2;
        }

        index = 1;

        while (index <= nums.Length - 1)
        {
            sum2 += nums[index];

            index += 2;
        }

        return Math.Max(sum1, sum2);

        // now we can aproach this as a DP problem
    }
    
    public int RobB(int[] nums)
    {
        // we need to add all possible sums
        // this would be really slow O(2^N)
        // we can use memoization to store the results of the subproblems, making this a DP problem

        Dictionary<(int, int), int> dp = new();

        int Backtrack(int sum, int index)
        {
            // base case is when we reach the end of the array
            if (index >= nums.Length)
            {
                return sum;
            }

            // if we have already computed the subproblem, return that instead
            if (dp.ContainsKey((sum, index)))
            {
                return dp[(sum, index)];
            }

            // call the backtrack function for the index + 2 and index + 1
            dp[(sum, index)] = Math.Max(Backtrack(sum + nums[index], index + 2), Backtrack(sum, index + 1));

            return dp[(sum, index)];
        }
        
        return Backtrack(0, 0);
    }

    public int RobC(int[] nums)
    {
        // this is O(N) time and O(1) space
        // for each index, chooses the larger of the previous largest sum or the current index

        int max = nums[0];
        int sum = 0;

        for (int i = 1; i < nums.Length; i++)
        {
            (max, sum) = (Math.Max(nums[i] + sum, max), max);
        }

        return max;
    }

    // rewrite again for better understanding
    public int RobD(int[] nums)
    {
        // this is O(N) time and O(1) space
        // for each index, chooses the larger of the previous largest sum plus the next num or the current num
        int previous = 0;
        int current = 0;

        foreach (int next in nums)
        {
            int temp = Math.Max(previous + next, current);
            previous = current;
            current = temp;
        }

        return current;
    }
}


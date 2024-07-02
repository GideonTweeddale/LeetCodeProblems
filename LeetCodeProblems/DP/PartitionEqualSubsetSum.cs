namespace LeetCodeProblems.DP;
public class PartitionEqualSubsetSum
{
    // intuition
    // 1. if sum of all elements is odd, then we can't divide the array into two equal sum subsets
    // 2. if the largest element is greater than half of the sum, then we can't divide the array into two equal sum subsets
    // 3. which also means that if we can add elements to get half of the sum, then we can divide the array into two equal sum subsets
    // 4. if start subtracting elements from the sum, and if we can reach 0, then we can divide the array into two equal sum subsets (this is true, but doesn't work for all cases because it is possible to back ourselves into a corner)
    // 5. it seems that the only way to solve this problem is to find all possible sums that can be formed from the given elements, and then check if half of the sum is present in the set of sums
    // this is a problem we can optimally solve with dynamic programming
    // we need to iterate through the array and for each element add it to all values in the dp set and if it creates a new value add it to the set

    public bool CanPartition(int[] nums)
    {
        int sum = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
        }

        if (sum % 2 != 0)
        {
            return false;
        }

        Array.Sort(nums);

        int target = sum / 2;

        for (int i = nums.Length - 1; i >= 0; i--)
        {
            Console.WriteLine(target);
            Console.WriteLine(nums[i]);

            // if any element is greater than half of the sum, then we can't divide the array into two equal sum subsets
            if (nums[i] > (sum / 2))
            {
                return false;
            }

            if (nums[i] <= target)
            {
                target -= nums[i];
            }
        }

        return target == 0;
    }

    public bool CanPartitionDP(int[] nums)
    {
        int sum = nums.Sum();
        int target = sum / 2;

        if (sum % 2 != 0)
        {
            return false;
        }

        HashSet<int> dp = new HashSet<int> { 0 };

        for (int i = nums.Length - 1; i >= 0; i--)
        {
            foreach (int t in dp.ToArray())
            {
                if (t + nums[i] == target)
                {
                    return true;
                }

                dp.Add(t + nums[i]);
            }
        }

        return dp.Contains(target);
    }
}


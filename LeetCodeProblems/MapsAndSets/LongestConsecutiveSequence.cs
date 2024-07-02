namespace LeetCodeProblems.Other;
public class LongestConsecutiveSequence
{
    public static int LongestConsecutive(int[] nums)
    {
        // very naive solution that uses sort to order the elements first
        // this will run in something like O(log N) time and therefore doesn't satisfy the requirements

        // weirdly this solution is very very fast - beating almost 96% of other solutions in C#

        if (nums == null || nums.Length == 0)
        {
            return 0;
        }

        int consecutive = 1;
        int currentRun = 1;

        Array.Sort(nums);

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] == nums[i - 1] + 1)
            {
                currentRun++;
            }
            else if (nums[i] != nums[i - 1])
            {
                currentRun = 1;
            }

            if (currentRun > consecutive)
            {
                consecutive = currentRun;
            }
        }

        return consecutive;
    }
    public static int LongestConsecutiveB(int[] nums)
    {
        // I'm not sure that this is truly O(N) 
        // but if creating the hashset is O(N)
        // and we only iterate over each number in a sequence maximum of twice
        // once when we reach it in the foreach and once as part of the sequence starting with the lowest number
        // and our hashset lookups are O(1) then I think this is as close to O(N) as we can reaonably get
        // without an extremely complex solution

        // interestingly the naive solution was faster and used less memory using the leetcode test cases
        // the difference was well within the margin of error / natural variability
        // and I suspect would invert with a large input for nums

        if (nums == null || nums.Length == 0)
        {
            return 0;
        }

        HashSet<int> set = new HashSet<int>(nums);

        int consecutive = 1;

        foreach (int number in set)
        {
            // if number isn't the first in a sequence, skip it
            if (set.Contains(number-1))
            {
                continue;
            }

            int currentRun = 1;
            while (set.Contains(number + currentRun))
            {
                currentRun++;
            }

            consecutive = Math.Max(currentRun, consecutive);
        }

        return consecutive;
    }
}

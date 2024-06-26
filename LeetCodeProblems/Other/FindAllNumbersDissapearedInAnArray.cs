﻿namespace LeetCodeProblems.Other;
public class FindAllNumbersDissapearedInAnArray
{
    // this should run in O(n) time and O(1) space
    public static IList<int> FindDisappearedNumbers(int[] nums)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            int index = Math.Abs(nums[i]) - 1;
            if (nums[index] > 0)
            {
                nums[index] = -nums[index];
            }
        }

        List<int> result = [];
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] > 0)
            {
                result.Add(i + 1);
            }
        }
        return result;
    }
}

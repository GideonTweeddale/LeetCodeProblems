namespace LeetCodeProblems.TwoPointer;
public class TwoSumA
{
    public int[]? TwoSum(int[] nums, int target)
    {
        Dictionary<int, int> dict = new();

        for (int i = 0; i < nums.Length; i++)
        {
            int complement = target - nums[i];

            if (dict.ContainsKey(complement))
            {
                return new int[] { dict[complement], i};
            }

            dict[nums[i]] = i;
        }

        return null;
    }
}


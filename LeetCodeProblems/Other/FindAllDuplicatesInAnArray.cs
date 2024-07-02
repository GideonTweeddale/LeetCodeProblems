namespace LeetCodeProblems.Other;
public class FindAllDuplicatesInAnArray
{
    public static IList<int> FindDuplicates(int[] nums)
    {
        // because all number in the array have values from 1 to N we can treat them as indices in the array
        // we can iterate over the array and check in the index that matches each value
        // if it is the first time we've seen a value, we can set it to the negative of the value
        // if the value is already negative, we can add the value to our return list
        // the question specifies that we see each number once or twice, so we shouldn't add any item more than once
        // this should run in O(N) time and, excluding the return list, O(1) space

        List<int> result = [];

        for (int i = 0; i < nums.Length; i++)
        {
            int index = Math.Abs(nums[i]) - 1;

            if (nums[index] > 0)
            {
                nums[index] = -nums[index];
            }
            else
            {
                result.Add(Math.Abs(nums[i]));
            }
        }

        return result;
    }
}

namespace LeetCodeProblems.MapsAndSets;
public class TwoSum1
{
    // intuition
    // iterate through our nums
    //      generate the complement by subracting the num from the target
    //      if our hashmap contains the complement, it means that our num and the complement both exists: we have found the answer and can return the indicies
    //      otherwise add the num to the hashmap in the hopes that it will be the complement for a future num

    // this implementation is O(n) time and space where n is the length of nums
    // O(n) time because we iterate through nums only once
    // and O(n) space becuase, in the case where our complement includes the last num in nums, we would add n-1 or n items to our hashmap
    public static int[]? TwoSum(int[] nums, int target)
    {
        Dictionary<int, int> dict = [];

        for (int i = 0; i < nums.Length; i++)
        {
            int complement = target - nums[i];

            if (dict.ContainsKey(complement))
            {
                return new int[] { dict[complement], i };
            }

            dict[nums[i]] = i;
        }

        return null;
    }
}


namespace LeetCodeProblems.TwoPointer;
public class ThreeSum15
{
    // intuition
    // sort the array, so that we can skip duplicates with a look back at the previous index
    // for every unique num in nums, do a two pointer search for all the combinations that equal zero
    // in each case (because we have sorted our list),
    //      if the value is greater than 0 we need to move our right pointer back
    //      if it is less than 0 we need to move our left pointer forwards
    //      and if it equals 0 we have found a match, so we can add it to our ouput 
    //          and move our left pointer forwards one (or more if we have a duplicate)

    // using inplace sort and not including the output list this runs in O(1) space
    // this runs in O(n^2) time becuase we iterate over every num in nums
    // and within that we iterate over ever num again (potentially twice) with the two pointer search
    // the sort should take O(n log n) time 
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        List<IList<int>> output = [];

        // first we need to sort our input nums so that we can skip duplicates
        Array.Sort(nums);

        for (int i  = 0; i < nums.Length; i++)
        {
            int num1 = nums[i];

            // if we have a previous index and its value is the same as our current index, skip the duplicate
            if (i > 0 && num1 == nums[i - 1])
            {
                continue;
            }

            int left = i + 1;
            int right = nums.Length - 1;

            while (left < right) 
            {
                int threeSum = num1 + nums[left] + nums[right];

                if (threeSum > 0)
                {
                    right--; // move our right pointer back
                }
                else if (threeSum < 0)
                {
                    left++; // move our left pointer forwards
                }
                else
                {
                    output.Add([num1, nums[left], nums[right]]);
                    left++;

                    while (nums[left] == nums[left - 1] && left < right)
                    {
                        left++;
                    }
                }
            }
        }

        return output;
    }
}


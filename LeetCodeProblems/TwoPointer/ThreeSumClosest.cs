namespace LeetCodeProblems.TwoPointer;
public class ThreeSumClosest16
{
    // intuition
    // we can complete this in O(n^2) time and O(1) space
    // first we sort the input array to allow us to avoid duplicates by skipping any num that is the same as the previous num
    // then we iterate over the nums in nums. For each num:
    //      we run a two pointer outwards to inwards search of the sorted nums looking for the lowest distance 
    public int ThreeSumClosest(int[] nums, int target)
    {
        int distance = int.MaxValue;
        int sum = 0;

        Array.Sort(nums);

        for (int i = 0; i < nums.Length; i++)
        {
            int numA = nums[i];

            // skip duplicates
            if (i > 0 && numA == nums[i-1])
            {
                continue;
            }

            int left = i + 1;
            int right = nums.Length - 1;

            while (left < right) 
            {
                int threeSum = numA + nums[left] + nums[right];
                int currentDistance = target - threeSum;

                // update our distance if needed
                if (Math.Abs(currentDistance) < distance)
                {
                    distance = Math.Abs(currentDistance);
                    sum = threeSum;
                }

                // to get the smallest difference
                // we need to get the absolute value of the target - threeSum to as close to 0 as possible
                // because the list is sorted, the increments will get smaller as we move inwards - therefore zeroing in on the best value

                // if we have a negative difference (target - threeSum < 0) it means that our threeSum is too large
                // and we need to move our right pointer left to reduce our threeSum
                if (currentDistance < 0)
                {
                    right--; // move our right pointer left to reduce our value and zero in
                }
                // if we have a large positive difference (target - threeSum > 0) it means that our three sum is too small
                // and we need to momve our left pointer right to increase our threeSum
                else if (currentDistance > 0)
                {
                    left++; // move our left point right to increase our value and zero in
                }
                // if we ever hit the else, we have found an exact match and there is no point continuing to evaluate
                else
                {
                    return sum;
                }
            }
        }

        return sum;
    }
}


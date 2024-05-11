namespace LeetCodeProblems.SlidingWindow;
public class SubarrayProductLessThanK
{
    // intuition
    // this is a classic sliding window problem
    // we initialise both pointers to the left side of the list
    // and while our left pointer is less < right pointer and our right pointer is less than the length of the list we iterate our pointers over the list

    // in this case we don't actually need to track the subarrays, just how many there are
    // so we don't need an output list, just variables to track the product and the count of valid subarrays

    // if the product is less than k shift the right pointer right
    // if the product is greater than k shift the left pointer right

    // if the product is less than k we have found some valid subarrays, so add to our count

    // we need to add the length of our window/subarray to our count
    // because if we were actually tracking the subarrays, we would need to include all the new subarrays of our subarray that include the new value
    // this is because if the combined product is less than k then the individual products must be less than k

    // for example if we add  1 to the subarray [5,2] and the product is less than k, we need to add [5,2,1] to our output, but also, [1], and [2,1]

    // this will run in O(n) time where n is the length of nums
    // because we iterate through the array max 2n times (once for each value with the left and right pointers)
    // this will use O(1) space including the output because we don't create any additional structures and only track a handful of variables

    public int NumSubarrayProductLessThanK(int[] nums, int k)
    {
        int count = 0;
        int product = 1;
        int left = 0;
        int right = 0;

        while (right < nums.Length)
        {
            product *= nums[right];

            while (left <= right && product >= k)
            {
                product /= nums[left];
                left++;
            }

            count += right - left + 1;

            right++;
        }

        return count;
    }
}

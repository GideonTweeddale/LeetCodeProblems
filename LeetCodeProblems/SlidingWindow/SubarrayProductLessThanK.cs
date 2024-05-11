namespace LeetCodeProblems.SlidingWindow;
public class SubarrayProductLessThanK
{
    // intuition
    // this is a classic two pointer problem
    // we initialise both pointers to the left side of the list
    // and while our left pointer is less < right pointer and our right pointer is less than the length of the list
    // if the product is less than the k, add it to the output list, and shift the right pointer right
    // if the product is greater than the k, shift the left pointer right
    // note, if we shift our right pointer right, and our subarray product is still less than the target
    // we are actually adding more than one item to the output, because our subarray must be added, but also the new value we added must be less than the product
    // because if the combined product is less than the target then the individual products must be less than the target also
    // in fact, we are actually adding elements equal to the length of our subarray to the output
    // for example if we add  1 to the subarray [5,2] and the product is less than our target, we need to add [5,2,1] to our output, but also, [1], and [2,1]
    // all must be less than our product and all will be new subarrays we haven't seen before because they include our new value
    // because we only need the count, not the actual subarrays, the logic will be pretty easy

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

namespace LeetCodeProblems.SlidingWindow;
public class MinimumSizeSubArraySum
{
    // intuition
    // this is a sliding window problem where the window varies in the number of indicies included in it
    // we start with the first and last indicies at index 0 and the sum equal to the value at index 0
    // if the sum of the indicies in the window is less than the target, we add the next index and increment the last pointer
    // if the sum if the indicies in the window is greater than the target, the last pointer is less than the length of nums -1, and the last index - first index is greater than 0, we subtract the value at the left index and increment the left index
    // if at any point the left index equales the right index and sum >= target return 1 because it is not possible to find a shorter sub array

    // this has a time complexity of O(n) because we iterate over each item a maximum of 2 times, once when the left index is incremented and once when the right index is incremented
    // it is O(1) space because we only use a few extra constant space variables

    public int MinSubArrayLen(int target, int[] nums)
    {
        int sum = 0, min = int.MaxValue, left = 0;

        for (int right = 0; right < nums.Length; right++)
        {
            sum += nums[right];

            while (sum >= target)
            {
                min = Math.Min(min, right + 1 - left);
                sum -= nums[left];
                left++;
            }
        }

        if (min == int.MaxValue) return 0;

        return min;
    }
}

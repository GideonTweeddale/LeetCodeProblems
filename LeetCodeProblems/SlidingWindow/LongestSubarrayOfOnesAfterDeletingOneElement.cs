namespace LeetCodeProblems.SlidingWindow;
public class LongestSubarrayOfOnesAfterDeletingOneElement
{
    // intuition
    // This is another sliding window problem
    // it is basically the same as the MaxConsecutiveOnesIII problem, except that instead of k 0's being allowed, we can only have 1
    // another difference is that we are deleting the zero instead of flipping it to be a one, so we need to subtract one from the answer 
    // we expand the window if we have less than one zero in our window
    // we shrink it if we have more
    // the maximum number of consecutive 1's will be the longest window

    // this should run in O(n) time, because we will see each value in our array a maximum of twice: once for each pointer
    // this should run in O(1) space because we will only create a few variables and no datastructures 
    public static int LongestSubarray(int[] nums)
    {
        int left = 0, right = 0, max = 0, k = 1;

        while (right < nums.Length)
        {
            if (nums[right] == 0)
            {
                k--;
            }

            if (k < 0)
            {
                if (nums[left] == 0)
                {
                    k++;
                }

                left++;
            }
            else
            {
                max = Math.Max(max, right - left);
            }

            right++;
        }

        return max;
    }
}

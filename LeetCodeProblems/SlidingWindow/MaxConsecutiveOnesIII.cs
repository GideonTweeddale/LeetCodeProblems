namespace LeetCodeProblems.SlidingWindow;
public class MaxConsecutiveOnesIII
{
    // intuition
    // This is another sliding window problem
    // we expand the window if we have less than k 0s in our window
    // we shrink it if we have more
    // the maximum number of consecutive 1's will be the longest window

    // this should run in O(n) time, because we will see each value in our array a maximum of twice: once for each pointer
    // this should run in O(1) space because we will only create a few variables and no datastructures 
    public int LongestOnes(int[] nums, int k)
    {
        int left = 0, right = 0, max = 0;

        while (right < nums.Length)
        {
            // if right is 0 decrement k
            if (nums[right] == 0) k--;

            if (k < 0)
            {
                if (nums[left] == 0) k++;

                left++;
            }
            else
            {
                max = Math.Max(max, right - left + 1);
            }

            right++;
        }

        return max;
    }
}

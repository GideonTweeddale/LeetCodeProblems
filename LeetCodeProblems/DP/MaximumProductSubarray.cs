namespace LeetCodeProblems.DP;
public class MaximumProductSubarray
{
    public static int MaxProduct(int[] nums)
    {
        // intuition
        // we need to keep track of the largest product so far
        // the solution will be one of either the left or the right product when there is no zero
        // when there is a zero, we need to reset the product to 1

        // this should be O(N) time and O(1) space

        int max = nums[0];
        int leftP = 1;
        int rightP = 1;
        int length = nums.Count();

        for (int i = 0; i < length; i++)
        {
            // the left product 
            if (leftP == 0)
            {
                leftP = 1;
            }

            leftP *= nums[i];

            // the right product
            if (rightP == 0)
            {
                rightP = 1;
            }

            rightP *= nums[length - 1 - i];

            // if the larger of the two current products is larger than the largest product so far, update it
            max = Math.Max(max, Math.Max(leftP, rightP));
        }

        return max;
    }
}


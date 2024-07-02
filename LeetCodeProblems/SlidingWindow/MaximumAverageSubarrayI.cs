namespace LeetCodeProblems.SlidingWindow;
public class MaximumAverageSubarrayI
{
    public static double FindMaxAverage(int[] nums, int k)
    {
        // add the first k items of the list together and save the average
        // remove the value of the each element from the back of the array
        // and add the value at the next index
        // take the average and if it is larger save it
        // return the largest average once we have run through the array
        // this should be O(N) time and O(1) space

        double currentAverage = 0;
        int right = k;

        // init the siding window
        for (int i = 0; i < k; i++)
        {
            currentAverage += ((double)nums[i] / k);
        }

        double maxAverage = currentAverage;

        for (int left = 0; left < nums.Length - k; left++)
        {
            // remove the left index
            currentAverage -= ((double)nums[left] / k);

            // add the right index
            currentAverage += ((double)nums[right] / k);

            // if the average is higher than the max
            if (currentAverage > maxAverage)
            {
                maxAverage = currentAverage;
            }

            // shift the window
            right++;
        }

        return maxAverage;
    }

    public static double FindMaxAverageB(int[] nums, int k)
    {
        // add the first k items of the list together and save the average
        // remove the value of the each element from the back of the array
        // and add the value at the next index
        // take the average and if it is larger save it
        // return the largest average once we have run through the array
        // this should be O(N) time and O(1) space

        double currentSum = 0;
        int right = k;

        // init the siding window
        for (int i = 0; i < k; i++)
        {
            currentSum += nums[i];
        }

        double maxSum = currentSum;

        for (int left = 0; left < nums.Length - k; left++)
        {
            // remove the left index and add the right index
            currentSum =  currentSum - nums[left] + nums[right];

            // if the average is higher than the max
            if (currentSum > maxSum)
            {
                maxSum = currentSum;
            }

            // shift the window
            right++;
        }

        return maxSum / k;
    }
}

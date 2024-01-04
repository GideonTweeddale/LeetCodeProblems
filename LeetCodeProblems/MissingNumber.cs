namespace LeetCodeProblems;
public class MissingNumber1
{
    // this should run in O(n) time and O(1) space
    public int MissingNumber(int[] nums)
    {
        int sum = 0;
        int expectedSum = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
            expectedSum += (i + 1);
        }

        return expectedSum - sum;
    }
}

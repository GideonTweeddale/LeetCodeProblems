namespace LeetCodeProblems;
public static class RemoveElement2
{
    public static int RemoveElement(int[] nums, int val)
    {
        int rm = 0;

        for(int i = 0; i < nums.Length; i++)
        {
            if (nums[i] != val)
            {
                nums[rm] = nums[i];
                rm++;
            }
        }

        return rm;
    }
}

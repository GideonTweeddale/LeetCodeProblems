namespace LeetCodeProblems.ArraysAndStrings;
public class RemoveElement2
{
    public int RemoveElement(int[] nums, int val)
    {
        int rm = 0;

        for (int i = 0; i < nums.Length; i++)
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

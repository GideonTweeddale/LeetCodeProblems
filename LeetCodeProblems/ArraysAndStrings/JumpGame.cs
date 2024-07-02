namespace LeetCodeProblems.ArraysAndStrings;
public class JumpGame
{
    public static bool CanJump(int[] nums)
    {
        int localGoal = nums.Length - 1;

        for (int i = nums.Length - 2; i >= 0; i--)
        {
            if (nums[i] >= localGoal - i)
            {
                localGoal = i;
            }
        }

        return localGoal == 0;
    }
    public static bool CanJumpB(int[] nums)
    {
        int maxDistance = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            maxDistance--;
            maxDistance = Math.Max(maxDistance, nums[i]);

            if (maxDistance == 0 && i != nums.Length - 1)
            {
                return false;
            }
        }

        return true;
    }
}

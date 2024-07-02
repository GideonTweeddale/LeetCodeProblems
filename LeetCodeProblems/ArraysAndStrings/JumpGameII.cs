namespace LeetCodeProblems.ArraysAndStrings;
public class JumpGameII
{
    public static int CanJump(int[] nums)
    {
        int jumps = 0, jumpPos = 0, jumpDistance = 0;

        for (int i = 0; i < nums.Length - 1; i++)
        {
            jumpDistance = Math.Max(jumpDistance, i + nums[i]);
            if (i == jumpPos)
            {
                jumps++;
                jumpPos = jumpDistance;
            }
        }
        return jumps;
    }
}

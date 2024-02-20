namespace LeetCodeProblems.Matrix;
public class RotateArray
{
    public void Rotate(int[] nums, int k)
    {
        if (nums.Length == 1)
        {
            return;
        }

        k = k % nums.Length;

        if (k == 0)
        {
            return;
        }

        int ni;
        int[] nums2 = (int[])nums.Clone();

        for (int i = 0; i < nums.Length; i++)
        {
            ni = i + k;

            if (ni > nums.Length - 1)
            {
                ni = ni - nums.Length;
            }

            nums[ni] = nums2[i];
        }
    }

    public void Rotate2(int[] nums, int k)
    {
        if (nums.Length == 1) return;

        k = k % nums.Length;
        if (k == 0) return;

        int ni;
        int[] buffer = new int[nums.Length];

        for (int i = 0; i < k; i++)
        {
            buffer[i] = nums[i];
        }

        for (int i = 0; i < nums.Length; i++)
        {
            ni = i + k;

            if (ni > nums.Length - 1)
            {
                ni = ni - nums.Length;
            }

            buffer[ni] = nums[i];
            nums[ni] = buffer[i];
        }
    }
}

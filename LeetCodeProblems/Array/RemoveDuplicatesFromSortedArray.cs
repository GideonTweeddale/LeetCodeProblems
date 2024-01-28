namespace LeetCodeProblems.Array;
public static class RemoveDuplicatesFromSortedArray
{
    public static int RemoveDuplicates(int[] nums)
    {
        int u = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] != nums[u])
            {
                u++;
                nums[u] = nums[i];
            }
        }

        return u;
    }
}

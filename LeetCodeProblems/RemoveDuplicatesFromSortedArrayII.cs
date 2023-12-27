namespace LeetCodeProblems;
public static class RemoveDuplicatesFromSortedArrayII
{
    public static int RemoveDuplicates(int[] nums)
    {
        int u = 0;

        foreach (int i in nums)
        {
            if (u < 2 || i > nums[u - 2])
            {
                nums[u++] = i;
            }
        }

        return u;
    }
}

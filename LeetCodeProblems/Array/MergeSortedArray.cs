namespace LeetCodeProblems.Array;
public static class MergeSortedArray
{
    public static void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        int pos1 = m - 1;
        int pos2 = n - 1;

        Console.WriteLine("[{0}]", string.Join(", ", nums1));

        for (int i = m + n - 1; i > -1; i--)
        {
            Console.WriteLine($"Positions: {pos1} {pos2}");

            if (pos1 >= 0 && (pos2 < 0 || nums1[pos1] > nums2[pos2]))
            {
                nums1[i] = nums1[pos1];
                pos1--;
            }
            else
            {
                nums1[i] = nums2[pos2];
                pos2--;
            }
        }

        Console.WriteLine("[{0}]", string.Join(", ", nums1));
    }
}

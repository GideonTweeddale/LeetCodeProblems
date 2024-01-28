namespace LeetCodeProblems.Array;
public static class MajorityElement5
{
    public static int MajorityElement(int[] nums)
    {
        Dictionary<int, int> map = new Dictionary<int, int>();
        int largest = nums[0];

        foreach (int i in nums)
        {
            if (map.ContainsKey(i))
            {
                map[i] = map[i] + 1;

                if (map[i] > map[largest] || i == largest)
                {
                    largest = i;
                }
            }
            else
            {
                map[i] = 1;
            }
        }

        return largest;
    }
}
namespace LeetCodeProblems.ArraysAndStrings;
public class MajorityElement5
{
    public static int MajorityElement(int[] nums)
    {
        Dictionary<int, int> map = [];
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
    public static int MajorityElementB(int[] nums)
    {
        // this works because the element must appear more than half of the time
        // therefore any other element will eventually have a count of zero and be replaced
        // inevitably selecting the correct element
        // if we get lucky and the correct element is selected early enough and appears more in the first half of the nums array
        // we can return early
        // this will run in O(N) time or better and O(1) space
        int count = 0;
        int candidate = 0;

        foreach (int num in nums)
        {
            if (count == 0)
            {
                candidate = num;
            }

            count += num == candidate ? 1 : -1;

            if (count > nums.Length / 2)
            {
                return candidate;
            }
        }

        return candidate;
    }
}
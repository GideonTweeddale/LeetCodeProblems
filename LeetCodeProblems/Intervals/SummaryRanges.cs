namespace LeetCodeProblems.Intervals;
public class SummaryRanges228
{
    // intuition
    // if I understand this problem correctly, we are returning the set of intervals that covers all the integers in a sorted array
    // given that the array is sorted in ascending order 
    // and all values are unique
    // we culd simply return the first and last value as the range
    // except that there may be gaps
    // instead, we iterate over the array until we find a non-consecutive integer
    // then we add the previous set of integers as a new interval and continue

    // this will run in O(n) time and space where n is the length of nums

    public IList<string> SummaryRanges(int[] nums)
    {
        if (nums.Length == 0) return [];

        IList<string> ranges = new List<string>();

        int startIndex = 0;

        for (int i = 1; i < nums.Length; i++)
        {
            // if the num at the previous index + 1 is not equal to the num at the current index
            if (nums[i-1] + 1 != nums[i])
            {
                if (nums[startIndex] == nums[i - 1])
                    ranges.Add(nums[startIndex].ToString());
                else
                    ranges.Add($"{nums[startIndex]}->{nums[i - 1]}");
                
                startIndex = i;
            }
        }

        // add the last range
        if (nums[startIndex] == nums[nums.Length - 1])
            ranges.Add(nums[startIndex].ToString());
        else
            ranges.Add($"{nums[startIndex]}->{nums[nums.Length - 1]}");

        return ranges;
    }
}

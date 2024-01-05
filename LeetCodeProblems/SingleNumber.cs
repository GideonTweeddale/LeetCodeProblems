namespace LeetCodeProblems;
public class SingleNumber136
{
    public int SingleNumber(int[] nums)
    {
        // the easiest solution would be to sort the array and then iterate through it two indexes at a time until a number isn't followed by itself
        Array.Sort(nums);

        for (int i = 0; i < nums.Length; i += 2)
        {
            if (nums[i] != nums[i + 1])
            {
                return nums[i];
            }
        }

        return -1; // if the description is correct, this should never be hit
    }
    public int SingleNumberB(int[] nums)
    {
        // using the xor operator to select the bits that are set to 1 an odd number of times giving us the number that isn't set twice
        // in other words the set bits in each number that is set twice cancel eachother out
        // I would have never come up with this on my own, but it is very clever 
        // and it saves the need for the sort operation
        int n = 0;
        foreach (int i in nums) n ^= i;
        return n;
    }
}


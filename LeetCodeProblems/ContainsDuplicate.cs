namespace LeetCodeProblems;
public class ContainsDuplicate1
{
    // this solution should be O(n) because that's how long it takes to add the unqique items to the hashset
    public bool ContainsDuplicate(int[] nums)
    {
        return new HashSet<int>(nums).Count < nums.Length;
    }
}

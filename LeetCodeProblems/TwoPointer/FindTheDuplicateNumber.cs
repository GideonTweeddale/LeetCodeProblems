namespace LeetCodeProblems.TwoPointer;
public class FindTheDuplicateNumber
{
    public int FindDuplicate(int[] nums)
    {
        // intuitively the easiest way to solve this would be with a hashset where we return if a number is already in the set
        // we can't use this approach because of the constant space requirement

        // because the array contains n+1 integers and the integers are all from 1 to n
        // we can safely treat them as a linked list where all values are valid indexes in the array 
        // this makes this a cycle problem - and we can use fast and slow pointers to find a if there is a cycle
        
        // the next bit I don't really understand, but apparently if we reset the slow pointer, it is a mathematical fact
        // that moving both pointers one element at a time will cause them to meet at the duplicate value

        // this solution will run on O(N) time and O(1) space

        // I need to review this because I don't fully understand it
        int slow = nums[0];
        int fast = nums[0];

        do
        {
            slow = nums[slow];
            fast = nums[nums[fast]];
        } while (slow != fast);

        slow = nums[0];

        while (slow != fast)
        {
            slow = nums[slow];
            fast = nums[fast];
        }

        return slow;
    }
}


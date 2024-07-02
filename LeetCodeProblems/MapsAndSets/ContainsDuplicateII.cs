namespace LeetCodeProblems.MapsAndSets;
public class ContainsDuplicateII
{
    // intuition
    // I think the question is asking if there are any two indices in the array that are both:
    //          - less than or equal to k positions apart
    //          - and equal to each other

    // we could solve this by iterating through the indicies and adding them to a map whose keys are the value at the index 
    // as we add each index to the map we check if any of the other indicies are less than or equal to k positions different

    // we can make this more efficient using a sliding window
    // we move our first pointer k times, adding the indicies to the map
    // then for each move, we first remove the index at the left pointer and then increment it
    // then we don't need to check the values in the map, if we already have a key when we add a new one, it must be less than or equal to k positions distant
    // and we can return true

    // this will solve the problem in O(n) time and O(k) space where n is the length of the nums array
    // because we will iterate through the nums array once and our map will contain at most k values

    public static bool ContainsNearbyDuplicate(int[] nums, int k)
    {
        int left = 0;

        HashSet<int> map = [];

        for (int right = 0; right < nums.Length; right++)
        {
            if (map.Contains(nums[right]))
            {
                return true;
            }

            map.Add(nums[right]);

            if (right - left == k) 
            {
                map.Remove(nums[left]);
                left++;
            }
        }

        return false;
    }
}


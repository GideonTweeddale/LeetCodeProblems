namespace LeetCodeProblems.SlidingWindow;
public class SortColors75
{
    // intuition
    // the requirement for a one pass algorithm with only constant extra space suggests some kind of two pointer solution
    // we can do this outside in
    // initialise the two poitners to the outermost values
    // and then we iterate over the array
    //      if we find a two we swap it with the right pointer index and move the right pointer inwards
    //      if we find a zero we swap it with the left pointer index and move the left pointer inwards
    public static void SortColors(int[] nums)
    {
        int left = 0;
        int right = nums.Length - 1;
        int i = 0;

        while (i <= right)
        {
            // if we move our right pointer we need to recheck the index against our left pointer in case it is a 0
            // so we don't want to increment i
            // in all other situations, we want to increment i
            if (nums[i] == 2)
            {
                // swap the values
                (nums[right], nums[i]) = (nums[i], nums[right]);
                right--;
            }
            else
            {
                if (nums[i] == 0)
                {
                    // swap the values
                    (nums[left], nums[i]) = (nums[i], nums[left]);
                    left++;
                }

                i++;
            }
        }
    }

    // using bucket sort
    // a "cheat" way to do this is to count the occurences of each of the three possible values in the nums array
    // and then overwrite the array with the count of those occurences in order
    // this will be O(2n) or O(n) time and constant space
    // because we will iterate of the values in the array once to count them
    // and then once more over the array to overwrite the values
    // it will be constant space because we know that we only have three possible distinct values in our nums array
    // we could record these in variables or use a hashmap that will never exceed three keys
    public static void SortColorsBucketSort(int[] nums)
    {
        Dictionary<int, int> colourCounts = [];

        // count the colours
        foreach (int i in nums)
        {
            if (!colourCounts.ContainsKey(i))
            {
                colourCounts.Add(i, 0);
            }
            colourCounts[i]++;
        }

        int colour = 0;

        // overwrite the array with the values
        for (int i = 0; i < nums.Length; i++)
        {
            // if our colour isn't in the dictionary or the count is zero, move to the next colour
            // the sum of the counts of the colours should equal the length of the nums array
            while (!colourCounts.ContainsKey(colour) || colourCounts[colour] == 0)
            {
                colour++;
            }

            colourCounts[colour]--;
            nums[i] = colour;
        }
    }
}

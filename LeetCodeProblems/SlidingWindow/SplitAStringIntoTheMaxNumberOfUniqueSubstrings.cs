namespace LeetCodeProblems.SlidingWindow;
public class SplitAStringIntoTheMaxNumberOfUniqueSubstrings
{
    // intuition
    // we can use a greedy approach
    // the substrings must be unique and concatenate into the original string - in otherwords we can't use a char in the string twice
    // I think this means that it is optimal to split the string into the shortest possible substrings 
    // working from right to left, we can use two pointers and a hashset
    // if our substring isn't in our hashset
    //      add it to our hashset
    //      move our right pointer right 
    //      and set our left pointer to match our right pointer
    // otherwise move our right pointer right
    // do this until we reach the end of the string
    // return the count of items in our hashset

    // one nice thing about this solution is that it could be very easily adapted to actually return the set of unique substrings instead of their count

    // this solution works because we need to include all characters in our final set of substrings in order
    // which means we can't skip any chars
    // so if string[1] isn't unique, but string[2] is, we can't simply add string[2] because our final concatenated string would be missing string[1]

    // this should complete in O(n) time because of we iterate over the array only once and our hashset operations are O(1)
    // and only use O(n) space because our hashset will have a maximum of n keys in the case where each char in our string is unique

    // this didn't work in just one instance and I'm not really sure why.
    // TODO return and work out why this solution doesn't work intuitvely... it is so close.
    public static int MaxUniqueSplitGreedy(string s)
    {
        HashSet<string> uniqueSubstrings = [];

        int left = 0;
        int right = 1;

        while (right <= s.Length)
        {
            string substring = s[left..right];
            if (!uniqueSubstrings.Contains(substring))
            {
                uniqueSubstrings.Add(substring);
                right++;
                left = right - 1;
            }
            else
            {
                right++;
            }
        }

        return uniqueSubstrings.Count;
    }

    public static int maxUniqueSplit(string S)
    {
        return maxUnique(S, []);
    }

    // this is more of a brute force solution, although it takes advantage of the shrinking problem space
    // it does a keep of dp, to add all unique substrings of length one starting at each index
    // and then length two, and so on for the entire length of the string
    // Utility function to find maximum count of
    // unique substrings by splitting the string
    public static int maxUnique(string S, HashSet<string> set)
    {
        // Stores maximum count of unique substring
        // by splitting the string into substrings
        int max = 0;

        // Iterate over the characters of the string
        for (int i = 1; i <= S.Length; i++)
        {
            // Stores prefix substring
            string tmp = S.Substring(0, i);

            // Check if the current substring already exists
            if (!set.Contains(tmp))
            {
                set.Add(tmp);

                // Recursively call for remaining
                // characters of string
                max = Math.Max(max, maxUnique(
                  S.Substring(i), set)
                               + 1);

                set.Remove(tmp);
            }
        }
        return max;
    }
}

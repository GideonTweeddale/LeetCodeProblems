namespace LeetCodeProblems.SlidingWindow;
public class LongestSubstringWithoutRepeatingCharacters
{
    // intuition
    // this is a sliding window problem where we need to keep track of which characters we've included in our sub array
    // we move our right pointer, adding each character to a HashSet until we find a duplicate
    // we move our left pointer, removing characters from the HashSet, until we no longer have a duplicate
    // if our HashSet is longer than our previously observed longest HashSet, update max
    // return max

    // adding items to and looking up items in a unique HashSet is O(1) except in some very specific cases
    // we will iterate through our array maximum twice, once for each of our pointers, which is O(n)
    // this gives us a time complexity of O(n)

    // our memory complexity will be also be constant O(1), given that there are a fixed number of English letters, digits, symbols, and spaces

    public int LengthOfLongestSubstring(string s)
    {
        HashSet<char> chars = new();

        int max = 0, left = 0, right = 0;

        while (right < s.Length)
        {
            if (!chars.Contains(s[right]))
            {
                chars.Add(s[right]);
                right++;
                max = Math.Max(max, chars.Count);
            }
            else
            {
                chars.Remove(s[left]);
                left++;
            }
        }

        return max;
    }
}

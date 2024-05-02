namespace LeetCodeProblems.SlidingWindow;
public class LongestSubstringWithoutRepeatingCharacters
{
    // intuition
    // this is effectively the two buckets sliding window problem, except that one of the buckets is size limited
    // we move our right pointer through the list until the end
    // for each iteration 
    //      we add to the count in our hashtable for that character
    //      we add to the total
    //      while we have more than two items in our hashtable or neither item has a count less than k
    //              move our left pointer, decrement the count/remove from the hashtable, and decrement the total
    //      if total is greater than max set max to the total
    // return max

    // this should be O(n) time complexity because we see each char in the string a maximum of twice O(2n) which simplyfies to O(n)
    // this should be O(1) or constant space complexity because our hashtable will never have more than three values

    public int CharacterReplacement(string s, int k)
    {
        Dictionary<char, int> counts = new(); // character, count

        int max = 0, maxCount = 0, left = 0, right = 0;

        while(right < s.Length)
        {
            if (!counts.ContainsKey(s[right]))
            {
                counts[s[right]] = 1;
            }
            else
            {
                counts[s[right]]++;
            }

            maxCount = Math.Max(maxCount, counts[s[right]]);

            // the total number of elements less the larger element is the smaller element
            // while the smaller element and therefore both elements is larger than k 
            while (right - left + 1 - maxCount > k) 
            {
                counts[s[left]]--;

                if (counts[s[left]] == 0) 
                {
                    counts.Remove(s[left]);
                }

                left++;
            }

            max = Math.Max(max, right - left + 1);

            right++;
        }

        return max;
    }

    // try it with an array
    // the array version is quicker
    public int CharacterReplacementB(string s, int k)
    {
        int[] counts = new int[26]; // character, count // 26 because we are only using uppercase characters

        int max = 0, maxCount = 0, left = 0, right = 0;

        while(right < s.Length)
        {
            counts[s[right] - 'A']++;
            maxCount = Math.Max(maxCount, counts[s[right] - 'A']);

            while(right - left + 1 - maxCount > k)
            {
                counts[s[left] - 'A']--;
                left++;
            }

            max = Math.Max(max, right - left + 1);
            right++;
        }

        return max;
    }
}

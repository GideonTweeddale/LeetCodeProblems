namespace LeetCodeProblems.SlidingWindow;
public class MaximumNumberOfVowelsInASubstringOfGivenLength
{
    // intuition 
    // this is a sliding window problem
    // we want to either find a substring that has the same number of vowels as k or as close as possible
    // we should be able to complete this in O(n) time and O(1) space

    // we can use a hashset to keep track of the vowels
    // note initialising the hashset here rather than in the method takes this from a 24th percentile to a 60th percentile solution
    // this is kinda obvious because the tests run many times in the class once it has been init
    // and creating the hashset in the method means it is being re-init with every run
    private HashSet<char> vowels = ['a', 'e', 'i', 'o', 'u'];

    public int MaxVowels(string s, int k)
    {
        if (s == null || s.Length == 0) return 0;

        int count = 0;
        int left = 0;
        int right = 0;

        // init right by counting the vowels in the first k length substring
        while (right < k)
        {
            if (vowels.Contains(s[right])) // is vowel
            {
                count++;
            }

            right++;
        }

        int maxVowels = count;

        // move the sliding window across the length of the string 
        // keep track of the number of vowels
        // return early if the maxVowels equals k
        while (right < s.Length)
        {
            if (maxVowels == k)
            {
                return maxVowels; // return early
            }

            // if our left pointer value is a vowel, decrement our count
            if (vowels.Contains(s[left]))
            {
                count--;
            }

            // if the new char is a vowel, increment our count 
            if (vowels.Contains(s[right]))
            {
                count++;
            }

            // move our left and rights pointer one place right
            left++;
            right++;

            maxVowels = Math.Max(maxVowels, count);
        }

        return maxVowels;
    }

    public int MaxVowelsConcise(string s, int k)
    {
        if (s == null || s.Length == 0) return 0;

        int count = 0, left = 0, right = 0;

        // init right by counting the vowels in the first k length substring
        while (right < k)
        {
            if (vowels.Contains(s[right])) // is vowel
                count++; 

            right++;
        }

        int maxVowels = count;

        // move the sliding window across the length of the string 
        // keep track of the number of vowels
        // return early if the maxVowels equals k
        while (right < s.Length)
        {
            if (maxVowels == k) return maxVowels; // return early

            // if our left pointer value is a vowel, decrement our count
            if (vowels.Contains(s[left])) 
                count--; 

            // if the new char is a vowel, increment our count 
            if (vowels.Contains(s[right])) 
                count++; 

            // move our left and rights pointer one place right
            left++; right++;

            maxVowels = Math.Max(maxVowels, count);
        }

        return maxVowels;
    }
}

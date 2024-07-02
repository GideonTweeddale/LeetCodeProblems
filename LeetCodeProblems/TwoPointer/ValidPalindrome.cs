namespace LeetCodeProblems.TwoPointer;
public class ValidPalindrome
{
    // intuition
    // we can solve this problem with two pointers
    // we start at the outer indexes and work our way to the middle
    // if we find opposite indexes that don't match we return early
    // if we find invalid characters, we skip them - this is why we start at the outside
    // this is a version of the two pointer algorithm

    // this will complete in O(n/2) or just O(n) time and O(1) space

    // the speed difference between these two version is kinda wild
    // version one completes in 48ms and 43.4mb of memory (obviously this is only one run each, so very unreliable)
    // version two completes in 458ms and 128.8mb of memory
    // maybe this could be a bit less with a stringbuilder
    // but it's still fascinating to see the difference

    // another note, the IsLetterOrDigit and ToLower calls could be replaced with lookups to predefined HashTables\

    public bool IsPalindrome(string s)
    {
        int left = 0;
        int right = s.Length - 1;

        while (left < right)
        {
            // skip any invalid chars
            while (!char.IsLetterOrDigit(s[left]) && left < right)
            {
                left++;
            }

            while (!char.IsLetterOrDigit(s[right]) && left < right)
            {
                right--;
            }

            // exit early
            if (char.ToLower(s[left]) != char.ToLower(s[right]))
            {
                return false;
            }

            left++;
            right--;
        }

        return true;
    }

    // this version is obviously slower and less elegant
    // but it technically has the same time complexity
    // and is maybe easier to read

    // it does string concatenation however, so it will be really slow, I think
    public bool IsPalindromeB(string s)
    {
        string validS = string.Empty;

        // filter out the invalid characters
        foreach (char c in s)
        {
            if (char.IsLetterOrDigit(c))
            {
                validS += c;
            }
        }

        int left = 0;
        int right = validS.Length - 1;

        while (left < right)
        {
            // exit early
            if (validS[left].ToString().ToLower() != validS[right].ToString().ToLower())
            {
                return false;
            }

            left++;
            right--;
        }

        return true; // if we get to the end without finding a mismatch.
    }
}

namespace LeetCodeProblems.DP;
public class LongestPalindromicSubstring
{
    public string LongestPalindrome(string s)
    {
        // intuition
        // we can start from the middle of the string and expand outwards - what happens when our string is no longer a palindrome?
        // we need to store the longest palindrome and the length of the longest
        // if a new palindrome is longer than the previous longest update both variables
        string longest = string.Empty;
        int lengthOfLongest = 0;

        for (int i = 0; i < s.Length; i++)
        {
            // check for odd length palindromes
            ExpandFromCenter(i, i);

            // check for even length palindromes
            ExpandFromCenter(i, i + 1); 
        }

        return longest;

        // helper function
        void ExpandFromCenter(int left, int right)
        {
            // while we have characters to check and the next left and right characters are the same
            // expand from the center until we no longer have a palindrome
            while (left >= 0 && right < s.Length && s[left] == s[right])
            {
                // if the current palindrome is longer than the previous longest
                if (right - left + 1 > lengthOfLongest)
                {
                    longest = s.Substring(left, right - left + 1);
                    lengthOfLongest = right - left + 1;
                }

                left--;
                right++;
            }
        }
    }
}


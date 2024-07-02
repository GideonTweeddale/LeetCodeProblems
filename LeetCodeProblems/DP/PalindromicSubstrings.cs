namespace LeetCodeProblems.DP;
public class PalindromicSubstrings
{
    // intuition
    // there will always be at least as many palindromic substrings as there are characters in the string
    // expand from center immediately comes to mind
    // but a dp solution should also be possible
    public int CountSubstrings(string s)
    {
        // using expand outwards from the center simplifies checking for palindromes
        // but will it count duplicates? I don't think so

        // for example, "aaa" the odd expand will only return "a" becuase there is no previous character for a second expand and the even expand will return "aa" because it's first check 
        // the second "a" will return "a" and "aaa" for the odd expand and "aa" for the even expand
        // the third "a" will return "a" for the odd expand and nothing for the even expand because there is no following character
        // this will give us a result set of "a", "aa", "aaa", "a", "aa", "a" - which is what we want

        // this has a worst case time complexity of O(n^2) and space complexity of O(1)

        int count = 0;

        // for each index in the string
        for (int i = 0; i < s.Length; i++)
        {
            // count the odd length palindromes
            ExpandFromCenter(i, i);

            // count the odd even length palindromes
            ExpandFromCenter(i, i + 1);
        }

        return count;

        // helper function
        void ExpandFromCenter(int left, int right)
        {
            while (left >= 0 & right < s.Length && s[left] == s[right])
            {
                count++;
                left--;
                right++;
            }
        }
    }

    public int CountSubstringsB(string s)
    {
        int count = s.Length;

        bool[,] dp = new bool[s.Length, s.Length];

        // initialize the dp array with all single character palindromes
        for (int i = 0; i < s.Length; i++)
        {
            dp[i, i] = true;
        }

        // find all the palindromes of length 2
        for (int i = 0; i < s.Length - 1; i++)
        {
            if (s[i] == s[i + 1])
            {
                dp[i, i + 1] = true;
                count++;
            }
        }

        // find all the palindromes of length 3 or more
        for (int len = 3; len <= s.Length; len++)
        {
            for (int i = 0, j = i + len - 1; j < s.Length; ++i, ++j)
            {
                if (dp[i + 1, j - 1] && (s[i] == s[j]))
                {
                    dp[i, j] = true;
                    count++;
                }
            }
        }

        return count;
    }
}


namespace LeetCodeProblems.DP;
public class WordBreak139
{
    public static bool WordBreak(string s, IList<string> wordDict)
    {
        // intuition
        // for each index in the string, we iterate over all previous indexes
        // and return true if the index is set to true (meaning that there was a combination of words that could be formed from the previous indexes)
        // and if the substring from the previous index to the current index is in the word dictionary
        // this will fill the dp array with true every time there is an inde we can reach with a combination of words
        // when we get to the final index, we will then know if there are any valid combinations of words that can form the string

        // this would be O(N^3) in the worst case
        // because we are iterating over the indexes
        // and then for each index we are iterating over the previous indexes
        // and then we are performing a substring operation which is O(N) for each index 

        // create a hashset of the word dictionary for O(1) lookups
        HashSet<string> words = new (wordDict);

        // create a dp array to store if we can reach the current index with a combination of words
        bool[] dp = new bool[s.Length + 1];

        // this isn't needed because the C# default value for bool is false
        // Array.Fill(dp, false);

        // the first index is always true because we can reach it with an empty string
        dp[0] = true;

        // iterate over the indexes in the string
        for (int i = 1; i <= s.Length; i++)
        {
            // iterate over the previous indexes
            for (int j = 0; j < i; j++)
            {
                // if the previous index is true and the substring from the previous index to the current index is in the word dictionary
                if (dp[j] && words.Contains(s.Substring(j, i - j)))
                {
                    dp[i] = true;
                    break;
                }
            }
        }

        // return the final index
        return dp[s.Length];
    }
}


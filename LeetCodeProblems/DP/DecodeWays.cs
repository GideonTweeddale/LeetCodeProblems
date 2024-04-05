namespace LeetCodeProblems.DP;
public class DecodeWays
{
    public int NumDecodings(string s)
    {
        // if the string starts with 0, it is not possible to decode
        if (s[0] == '0') return 0;

        // intution 
        // we need to track the number of ways we can decode the string
        // for each index in the string, we can either decode the current index by itself or with the previous index
        // if the current index is 0, we can only decode it with the previous index if the previous index is 1 or 2

        // if we store the number of ways to decode the string up to the current index in a dp array
        // for each index, if it can be decoded by iteself we add the number of ways to decode the string from the previous index
        // and if it can be decoded with the previous index, we add the number of ways to decode the string from the index 2 places back

        // this iterates over each index in the string only once, making it O(n) time complexity
        // and it uses a dp array of size n (where n is the length of the input string), making it O(n) space complexity
        int[] dp = new int[s.Length + 1];
        dp[0] = 1;
        dp[1] = 1;

        for (int i = 2; i <= s.Length; i++)
        {
            int oneDigit = s[i - 1] - '0';
            int twoDigits = int.Parse(s.Substring(i - 2, 2));

            if (oneDigit != 0) 
                dp[i] += dp[i - 1];

            if (10 <= twoDigits && twoDigits <= 26)
                dp[i] += dp[i - 2];
        }

        return dp[s.Length];
    }
}


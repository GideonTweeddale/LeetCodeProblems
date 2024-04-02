namespace LeetCodeProblems.DP;
public class CoinChange322
{
    public int CoinChange(int[] coins, int amount)
    {
        // this intuition is wrong becuase
        // there are many cases where subtracting the larger coin
        // will take down us a path that without a solution when using a smaller coin wouldn't

        // intuition - greedy
        // by sorting the coins array we can start with the largest coin and work our way down
        // we can keep subtracting the largest coin that is smaller than the remaining amount
        // as long as the remaining amount after that subtraction is greater than the smallest coin after

        Array.Sort(coins);
        int currentCoin = coins.Length - 1;
        int count = 0;

        while(amount > 0)
        {
            if (currentCoin == 0 || amount - coins[currentCoin] >= coins[0] || amount - coins[currentCoin] == 0)
            {
                amount -= coins[currentCoin];
                count++;
            }
            else
            {
                currentCoin--;
            }
        }

        if (amount < 0) return -1;

        return count;
    }

    // dp solution
    public int CoinChangeB(int[] coins, int amount) 
    {
        // from the bottom up compute the minimum number of coins needed to make the value until we reach the amount
        // at each value use the previously computed values

        int[] dp = new int[amount + 1];
        Array.Fill(dp, amount + 1);
        dp[0] = 0;

        for (int i = 1; i < amount + 1; i++)
        {
            foreach(int coin in coins)
            {
                if (i - coin >= 0)
                {
                    dp[i] = Math.Min(dp[i], dp[i - coin] + 1);
                }
            }
        }

        if (dp[amount] != amount + 1) return dp[amount];

        return -1;
    }

    // memoisation solution
    // TODO
}


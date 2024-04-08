namespace LeetCodeProblems.DP;
public class BestTimeToBuyAndSellStocksWithCooldown
{
    // 1. we are looking for the maximum cummulative difference between stock prices 
    // 2. for each day there are really only two possible choices (cooldown is just skipping): to buy or sell
    // 3. if we buy, we subtract the price from the total profit, and if we sell, we add the price to the total profit
    // this would be O(n^2) time complexity, but if we cache the result for each day, we can reduce it to O(n)
    public int MaxProfit(int[] prices)
    {
        // key=day and bought or sold, value=profit
        Dictionary<(int, bool), int> cache = new();

        return dfs(0, true);

        int dfs(int i, bool lookingToBuy)
        {
            // if we are out of bounds, return 0
            if (i >= prices.Length) return 0;

            // if we have already calculated the result, return it
            if (cache.ContainsKey((i, lookingToBuy))) return cache[(i, lookingToBuy)];

            // we can always skip a day
            int cooldown = dfs(i + 1, lookingToBuy);

            // otherwise buy or sell
            if (lookingToBuy)
            {
                int buy = dfs(i + 1, false) - prices[i];
                cache[(i, lookingToBuy)] = Math.Max(buy, cooldown);
            }
            else
            {
                int sell = dfs(i + 2, true) + prices[i];
                cache[(i, lookingToBuy)] = Math.Max(sell, cooldown);
            }

            return cache[(i, lookingToBuy)];
        }
    }
}


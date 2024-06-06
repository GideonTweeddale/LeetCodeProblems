namespace LeetCodeProblems.ArraysAndStrings;
public class BestTimeToBuyAndSellStock
{
    public int MaxProfitB(int[] prices)
    {
        int maxProfit = 0;
        int cheapestPrice = prices[0];

        foreach (int price in prices)
        {
            if (price < cheapestPrice)
            {
                cheapestPrice = price;
            }
            else
            {
                int profit = price - cheapestPrice;
                if (profit > maxProfit)
                {
                    maxProfit = profit;
                }
            }
        }

        return maxProfit;
    }

    public int MaxProfitC(int[] prices)
    {
        int maxProfit = 0;
        int cheapestPrice = prices[0];

        // A for loop with i = 1 could skip the first comparison
        // The tradeoff is either a variable to store the current price lookup
        // or two current price lookups
        foreach (int price in prices)
        {
            maxProfit = Math.Max(maxProfit, price - cheapestPrice);
            cheapestPrice = Math.Min(cheapestPrice, price);
        }

        return maxProfit;
    }
}

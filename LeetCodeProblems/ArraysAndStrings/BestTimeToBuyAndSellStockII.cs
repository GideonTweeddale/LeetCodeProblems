namespace LeetCodeProblems.ArraysAndStrings;
public class BestTimeToBuyAndSellStockII
{
    public int MaxProfit(int[] prices)
    {
        int maxProfit = 0;
        int lastPrice = prices[0];

        foreach (int price in prices)
        {
            if (price > lastPrice)
            {
                maxProfit += price - lastPrice;
            }
            lastPrice = price;
        }

        return maxProfit;
    }

    public int MaxProfitB(int[] prices)
    {
        int maxProfit = 0;

        for (int i = 1; i < prices.Length; i++)
        {
            if (prices[i] > prices[i - 1])
            {
                maxProfit += prices[i] - prices[i - 1];
            }
        }

        return maxProfit;
    }
}

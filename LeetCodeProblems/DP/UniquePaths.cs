namespace LeetCodeProblems.DP;
public class UniquePaths62
{
    public int UniquePaths(int m, int n)
    {
        // intuition
        // we can only reach a cell from the cell above or to the left
        // so the number of ways to reach a cell is the sum of the number of ways to reach the cells above and to the left

        // create a 2D array to store the number of ways to reach each cell
        int[,] dp = new int[m, n];

        // fill the first row and column with 1 because there can only be one way to reach them
        for (int i = 0; i < m; i++) dp[i, 0] = 1;
        for (int i = 0; i < n; i++) dp[0, i] = 1;

        for (int i = 1; i < m; i++)
        {
            for (int j = 1; j < n; j++)
            {
                dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
            }
        }

        return dp[m - 1, n - 1];

        // this has a time complexity of O(m * n) and space complexity of O(m * n)
    }

    public int UniquePathsB(int m, int n)
    {
        // intuition
        // we only need to know the values of the previous row and the current row to calculate the number of ways to reach a cell
        // so we don't need to store the entire 2D array
        // we can just use two 1D arrays

        int[] prev = new int[n];
        int[] curr = new int[n];

        Array.Fill(prev, 1);
        Array.Fill(curr, 1);

        for (int i = 1; i < m; i++)
        {
            for (int j = 1; j < n; j++)
            {
                curr[j] = prev[j] + curr[j - 1];
            }

            (curr, prev) = (prev, curr);
        }

        return prev[n - 1];

        // has a time complexity of O(m * n) and space complexity of O(n)
    }

    public int UniquePathsC(int m, int n)
    {
        // intuition
        // this is a mathematical problem - we must make m - 1 moves down and n - 1 moves right
        // so the total number of moves is the number of ways to combine those moves

        long ans = 1;

        for (int i = 1; i <= m - 1; i++)
        {
            ans = ans * (n - 1 + i) / i;
        }

        return (int)ans;
    }
}


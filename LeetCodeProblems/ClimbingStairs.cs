namespace LeetCodeProblems;
public class ClimbingStairs70
{
    public int ClimbStairs(int n)
    {
        // this should basically be a fibonacci sequence where the number of unique approaches to a step should be the sum of the approaches to the last two steps
        if (n <= 2) return n;

        int fibOne = 1;
        int fibTwo = 2;
        int fibSum = 0;

        for (int i = 2; i < n; i++)
        {
            fibSum = fibOne + fibTwo;
            fibOne = fibTwo;
            fibTwo = fibSum;
        }

        return fibSum;
    }
}


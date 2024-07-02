namespace LeetCodeProblems.MapsAndSets;
public class HappyNumber
{
    // intuition
    // this problem is weird

    // but we know we've entered an infinite loop if we've already come across a number 
    // we can solve this by performing the square and sum operation in a loop until the value equals 1
    // or our number is already in the set of numbers we've already seen
    // and we can track that using a HashSet

    // the space and time complexity of this solutiion are really hard to calculate
    // in theory this squaring process could carry on for a long time before it reaches an infinite loop
    // but the question does assure us that it will reach an infinite loop at some point and not continue to grow infinitely
    public static bool IsHappy(int n)
    {
        HashSet<int> visited = [];

        while (!visited.Contains(n))
        {
            visited.Add(n);
            n = SumOfSquares(n);

            if (n == 1)
            {
                return true; // it's happy!!!
            }
        }

        return false; // we found a loop
    }

    private static int SumOfSquares(int n)
    {
        int sum = 0;

        while (n != 0)
        {
            int digit = n % 10;
            digit *= digit;
            sum += digit;
            n /= 10;
        }

        return sum;
    }
}


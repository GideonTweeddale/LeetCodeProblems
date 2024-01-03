namespace LeetCodeProblems;
public class GasStation
{
    public int CanCompleteCircuit(int[] gas, int[] cost)
    {
        // The total sum of fuel most be greater than the total sum of fuel costs

        // We are told that there is only one possible solution in each circut
        // We can assume this means that the correct starting index is the first index for which the tank doesn't go negative before reaching the end of the array
        // becuase this index will carry over the most fuel to get arround any of the initial part of the array where there wasn't enough fuel

        int sum = 0;
        int[] net = new int[gas.Length];
        int fuel = 0;
        int start = 0;

        for (int i = 0; i < gas.Length; i++)
        {
            net[i] = gas[i] - cost[i];
            sum += net[i];
        }

        if (sum < 0) return -1;

        for (int i = 0; i < gas.Length; i++)
        {
            if (fuel < 0)
            {
                fuel = 0;
                start = i;
            }

            fuel += net[i];
        }

        return start;
    }


    public int CanCompleteCircuitB(int[] gas, int[] cost)
    {
        int sum = 0;
        int maxIndex = -1;
        int maxSum = int.MinValue;

        for (int i = gas.Length - 1; i >= 0; i--)
        {
            sum += gas[i] - cost[i];

            if (sum > maxSum)
            {
                maxIndex = i;
                maxSum = sum;
            }
        }

        return sum < 0 ? -1 : maxIndex;
    }
}

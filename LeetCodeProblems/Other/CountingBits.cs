namespace LeetCodeProblems.Other;
public class CountingBits
{
    public int[] CountBits(int n)
    {
        // if we shift the number one place to the right we drop the right-most bit
        // we can lookup this new number (half of the original) in our array of already calculated answers to get the number of 1s in it
        // and then add 1 if the rightmost number was a 1
        int[] oneCounts = new int[n + 1];

        for (int i = 1; i <= n; i++)
        {
            oneCounts[i] = oneCounts[i >> 1] + (i & 1);
        }

        return oneCounts;
    }
    public int[] CountBitsB(int n)
    {
        // the number of 1s in a given integer is equal the number of ones in the closest power of two plus one
        // we can find this by keeping track of where we stored each power of two we find as we iterate through the number using an offset
        // 
        int[] oneCounts = new int[n + 1];
        int lastPowerOfTwo = 1;

        for (int i = 1; i <= n; i++)
        {
            if (lastPowerOfTwo * 2 == i)
            {
                lastPowerOfTwo *= 2;
            }

            oneCounts[i] = oneCounts[i - lastPowerOfTwo] + 1;
        }

        return oneCounts;
    }
}


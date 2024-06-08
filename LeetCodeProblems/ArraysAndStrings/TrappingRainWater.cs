namespace LeetCodeProblems.ArraysAndStrings;
public class TrappingRainWater
{
    // intuition
    // for each height in the array
    // we can trap the amount of water equal to the local maximum heights either side of it minus its own height

    // one way to solve this problem is with two passes and an array of units of water
    // on the first pass we save to the array of units of water that equals the left max - the current height
    // on the second pass, we trim our units of water to a max of the right max - the current height
    // this should give us the total units of water possible in the area
    // then we iterate over the unitsOfWater array and count the total units and return the count
    // this will run in O(3n) time and O(n) space because it will iterate over the original array twice 
    // and will create a extra array the length of the original array and iterate over it once

    public int TrapA(int[] height)
    {
        int[] unitsOfWater = new int[height.Length];
        int max = height[0];

        for(int i = 1; i < height.Length; i++)
        {
            if (height[i] < max)
                unitsOfWater[i] = max - height[i];
            else
                max = height[i];

            // Console.WriteLine($"Index {i} Max {max} height {height[i]} units {unitsOfWater[i]}");
        }

        max = height[height.Length - 1];

        for (int i = height.Length - 1; i >= 0; i--)
        {
            // Console.WriteLine($"Index {i}");
            // Console.WriteLine($"Max {max} height {height[i]} units {unitsOfWater[i]}");

            if (unitsOfWater[i] + height[i] > max)
                unitsOfWater[i] = Math.Max(max - height[i], 0);

            if (height[i] > max)
                max = height[i];

            // Console.WriteLine($"Max {max} height {height[i]} units {unitsOfWater[i]}");
        }

        int total = 0;

        foreach(int units in unitsOfWater)
            total += units;

        return total;
    }

    // I just saw a genius solution that I am going to try and code up here that solves this in O(n) time and O(1) constant space
    // It basically does this in the same way I did
    // except instead of tracking the units of water in the first pass, it finds the highest point in the array, or the peak/watershed
    // then it iterates through the array from the left and right separatly until that point tracking the outer max
    // and adding outer max - the current height to the total for each index

    public int Trap(int[] height)
    {
        int maxI = 0;

        // find the watershed peak
        for (int i = 0; i < height.Length; i++)
        {
            if (height[maxI] < height[i])
            {
                maxI = i;
            }
        }

        int total = 0;
        int max = height[0];

        // get all the water to the left of the watershed
        for (int i = 0; i < maxI; i++)
        {
            max = Math.Max(max, height[i]);

            total += max - height[i];
        }

        max = 0;

        // get all the water to the right of the watershed
        for (int i = height.Length - 1; i >= maxI; i--)
        {
            max = Math.Max(max, height[i]);

            total += max - height[i];
        }

        return total;
    }
}

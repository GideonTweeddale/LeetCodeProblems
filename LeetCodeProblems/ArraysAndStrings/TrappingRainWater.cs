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

    public int Trap(int[] height)
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
}

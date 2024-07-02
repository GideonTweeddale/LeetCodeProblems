namespace LeetCodeProblems.ArraysAndStrings;
public class Candy135
{
    // intuition
    // ignore the one candy per child and just add the length of the ratings array to the final number
    // as I understand it, if an item in the array is larger than either of its neighbours it should get an extra candy
    // if it is the same or less, then only one candy is fine
    // this means the max number of candies would be ratings.length + ratings.length - 1 in the case that we have a continously ascending or descending array

    // to solve this in O(n) time and O(1) space, all that we need to do is iterate through the array once
    // for each value, look at the value before and the value after, if they exist
    // and add one to our output if the current value is greater than either of them

    // this doesn't work - I've misunderstood the question somehow
    // is it possible that we are supposed to treat the empty space either side of the beginning and end as 0
    // and add a candy if the first and last value are greater than one?

    // or is it this case that we are supposed to assign one extra candy for each neighbour that our child is rated higher than?
    // for example [1,2,1] would get [1,3,1] candies or five candies in total
    // let's add that test case to answer the question
    // nope. The expected output for [1,2,1] on leetcode is 4. I am officially confused. I think this invalidates both of my guesses. 

    // why does this test case [1,2,87,87,87,2,1] result in an output of 13 not 11?

    // ooooooooooh, I get it. A child must have more than its immediate neighbours that it is larger than
    // which means that if a child gets an extra candy and it's neighbour is greater than it
    // that neighbour must get two extra candies
    // shit. That totally invalidates my solution

    public int CandyWrong(int[] ratings)
    {
        int candiesRequired = ratings.Length;

        for (int i = 0; i < ratings.Length; i++) 
        {
            if (i != 0 && ratings[i] > ratings[i - 1])
            {
                candiesRequired++;
            }
            else if (i < ratings.Length - 1 && ratings[i] > ratings[i + 1])
            {
                candiesRequired++;
            }
        }

        return candiesRequired;
    }

    // To solve this, we are going to need to track the number of candies assigned to each child.
    // I think we can pass over the array in one direction and if our rating is higher than our left neighbour
    // setting the value in the tracking array to the value for our left neighbour plus one
    // then we pass through the array in the reverse direction and if our rating is higher than our right neighbour
    // setting our rating to the max of the current value and 1 + the value for the right neighbour

    // this means that this solution will be O(3n) or O(n) time and O(n) extra space 
    
    public int CandyTwoPass(int[] ratings)
    {
        if (ratings.Length == 0)
        {
            return 0;
        }

        int[] candiesAssigned = new int[ratings.Length];

        // left pass
        for (int i = 1; i < ratings.Length; i++)
        {
            if (ratings[i] > ratings[i-1])
            {
                candiesAssigned[i] = candiesAssigned[i - 1] + 1;
            }
        }

        // right pass
        for (int i = ratings.Length - 2; i >= 0; i--)
        {
            if (ratings[i] > ratings[i+1])
            {
                candiesAssigned[i] = Math.Max(candiesAssigned[i], candiesAssigned[i+1] + 1);
            }
        }

        int candiesRequired = ratings.Length;

        foreach (int candies in candiesAssigned)
        {
            candiesRequired += candies;
        }

        return candiesRequired;
    }
}

namespace LeetCodeProblems.TwoPointer;
public class ContainerWithMostWater
{
    // intuition
    // assuming the the volume of the container is 1 wide, then this is effectively an area problem
    // the area between any two lines will be the product of the shorter line and the distance between them
    // the naive/brute force solution would be to iterate through the array checking all combinations keeping track of the largest area and returning the result

    // however, we can complete this in O(n) time using left and right pointers
    // init our pointers to the outermost values of the array
    // move the poiter than points to the shorter line inwards
    // until they meet
    // with each iteration, check the area, and save the largest

    // we start at the outside because this gives us the largest value for the distance between pointers
    // we move the pointer with the shorter height because this preserves the larger height
    // this means that will always check all the largest possible combinations of those two values
    // guaranteeing us the largest possible area

    // this will run in O(n) time because we will iterate a maximum of n times before the two pointers meet
    // and it will use constant extra space because we won't be using any additional data structures

    public static int MaxArea(int[] height)
    {
        int maxArea = 0;

        int left = 0;
        int right = height.Length - 1;

        while(left < right) 
        { 
            // we don't need to break the calcuation down like this, but I find it easier to read and explain this way
            int shorterHeight = Math.Min(height[left], height[right]);
            int distanceBetween = right - left;
            int area = shorterHeight * distanceBetween;

            maxArea = Math.Max(maxArea, area);

            if (height[left] > height[right])
            {
                right--;
            }
            else
            {
                left++;
            }
        }

        return maxArea;
    }
}


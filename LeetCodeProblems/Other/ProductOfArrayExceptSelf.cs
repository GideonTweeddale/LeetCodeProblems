namespace LeetCodeProblems.Other;
public class ProductOfArrayExceptSelf
{
    public int[] ProductExceptSelf(int[] nums)
    {
        int[] answer = new int[nums.Length];
        int curr = 1;
        
        Array.Fill(answer, 1);

        for (int i = 0; i < nums.Length; i++)
        {
            answer[i] *= curr;
            curr *= nums[i];
        }

        curr = 1;

        for (int i = nums.Length - 1; i >= 0; i--)
        {
            answer[i] *= curr;
            curr *= nums[i];
        }

        return answer;
    }
}

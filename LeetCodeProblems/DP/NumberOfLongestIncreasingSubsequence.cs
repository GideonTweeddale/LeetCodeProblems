namespace LeetCodeProblems.DP;
public class NumberOfLongestIncreasingSubsequence
{
    // intuition
    // if we track the length of the longest subsequence and the number found
    // we can increment the number if we find another equal subsequence or reset it and update the length if we find a longer one
    // or we could simply store the maximum and count the elements with the maximum length in the findal dp array

    // we need to work backwards from the end of the array and work out the maximum length of the subsequence for each index
    // then the maximum length of the subssequemce for the current index will be either 1 or the maximum length of the subsequence of the previous index + 1

    public int FindNumberOfLIS(int[] nums)
    {
        int maxLength = 0;
        int maxCount = 0;

        Dictionary<int, int[]> dp = new();

        for (int i = nums.Length - 1; i >= 0; i--)
        {
            int localLength = 1;
            int localCount = 1;

            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[j] > nums[i])
                {
                    int length = dp[j][0];
                    int count = dp[j][1];

                    if (length + 1 > localLength)
                    {
                        localLength = length + 1;
                        localCount = count;
                    }
                    else if (length + 1 == localLength)
                    {
                        localCount += count;
                    }
                }
            }

            if (localLength > maxLength)
            {
                maxLength = localLength;
                maxCount = localCount;
            }
            else if (localLength == maxLength)
            {
                maxCount += localCount;
            }

            dp[i] = [localLength, localCount];
        }

        return maxCount;
    }
}


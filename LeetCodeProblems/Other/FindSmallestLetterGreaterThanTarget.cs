namespace LeetCodeProblems.Other;
public class FindSmallestLetterGreaterThanTarget
{

    public char NextGreatestLetter(char[] letters, char target)
    {
        // iterating through the array should be O(n) time and O(1) space

        for (int i = 0; i < letters.Length; i++)
        {
            if (letters[i] > target)
            {
                return letters[i];
            }
        }

        return letters[0];
    }

    public char NextGreatestLetterBinary(char[] letters, char target)
    {
        // using binary search should be O(log N) time complexity
        // in practice this is actually slower in the leetcode tests - it should be faster on larger datasets though 
        int left = 0;
        int right = letters.Length - 1;

        if (letters[letters.Length - 1] <= target)
            return letters[0];

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (letters[mid] > target)
                right = mid - 1;
            else
                left = mid + 1;
        }

        return letters[left];
    }
}


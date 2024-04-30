namespace LeetCodeProblems.BinarySearch;
public class SearchA2DMatrix
{
    // intuition
    // given the O(log N) requirement where N is m*n or the number of cells in the matrix
    // the solution to this must be binary search
    // because the matrix is effectively a sorted array
    // the easiest way to solve this would be to iterate through it and add all the elements to a sorted array
    // that would be an O(n) operation, so we need a way to treat our matrix like an array
    // and we can do that by making our row the number of times we can divide our midpoint by the number of columns in our matrix
    // and our column the remainder of the number of times we can divide our midpoint by the number of columns

    public bool SearchMatrix(int[][] matrix, int target)
    {
        int left = 0;
        int cols = matrix[0].Length;
        int rows = matrix.Length;
        int right = cols * rows - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            int row = mid / cols;
            int col = mid % cols;
            int value = matrix[row][col];

            if (value == target) // we have found our value
            {
                return true;
            }

            if (value > target) // go left
            {
                right = mid - 1;
            }
            else if (value < target) // go right
            {
                left = mid + 1;
            }
        }

        return false; // if we reach this, we didn't find the target
    }

    // damn. I solved this first try in just under 15 minutes beating 65.73% in speed and 72.63% in memory.
    // It is a really easy problem - generally binary search problems are. But that is still progress.
}


namespace LeetCodeProblems.BinarySearch;
public class SearchA2DMatrixII
{
    // intuition
    // we could do this in O(n log n) time by adding the values to an array, sorting it, and then performing a binary search
    // but I think we can do better. 
    // if we can apply binary search directly to the matrix we could solve this in O(log n) time
    // the tricky bit will be working out if we need to move right or left
    // we can't use the left sorted array vs the right sorted array trick because our sequences either side of the midpount are not sorted

    // because the rows are sorted we know that the lowest value in a row will be the first one
    // and because the values are also sorted in descending order in each column, we know that the highest value in a column will always be the last one
    // if we start with the last row and the first column (or the last column and the first row) we can elininate an entire row or column with each comparison

    // for example, if we start with
    // target = 5 and matrix:
    // [[1,4,7,11,15]
    // ,[2,5,8,12,19]
    // ,[3,6,9,16,22]
    // ,[10,13,14,17,24]
    // ,[18,21,23,26,30]]
    // 5 < 18, so we know that the value cannot be in the last row, so we decrement our row and check again
    // 5 < 10, so we do the same again
    // 5 > 3, so we increment our column
    // 5 < 6, so we decrement our row
    // 5 = 5, and we have found the answer
    // in the worst case, this solution would be O(m + n) where the target wasn't in the matrix or was one of the bottom right or top left values
    // and we needed to check a value for everyrow and column 

    // this solution beats 95.38% on time and 94.12% on memory

    public static bool SearchMatrix(int[][] matrix, int target)
    {
        int n = matrix.Length;
        int m = matrix[0].Length;

        int row = n - 1;
        int col = 0;

        while (row >= 0 && col < m)
        {
            if (matrix[row][col] == target)
            {
                return true;
            }

            if (matrix[row][col] < target)
            {
                col += 1;
            }
            else
            {
                row -= 1;
            }
        }

        return false; // if we make it here, we didn't find the target
    }

    // we can also do this starting from the bottom right/last column and first row

    // for example, if we start with
    // target = 5 and matrix:
    // [[1,4,7,11,15]
    // ,[2,5,8,12,19]
    // ,[3,6,9,16,22]
    // ,[10,13,14,17,24]
    // ,[18,21,23,26,30]]
    // 5 < 15, so we decrement our column
    // 5 < 11, so we decrement our column
    // 5 < 7, so we decrement our column
    // 5 > 4, so we increment our row
    // 5 = 5, so we have found the target
    public static bool SearchMatrixB(int[][] matrix, int target)
    {
        int n = matrix.Length;
        int m = matrix[0].Length;

        int row = 0;
        int col = m - 1;

        while (row < n && col >= 0)
        {
            if (matrix[row][col] == target)
            {
                return true;
            }

            if (matrix[row][col] > target)
            {
                col -= 1;
            }
            else
            {
                row += 1;
            }
        }

        return false; // if we make it here, we didn't find the target
    }
}


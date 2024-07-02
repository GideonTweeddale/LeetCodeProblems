namespace LeetCodeProblems.Matrix;
public class RotateImage
{
    public void Rotate(int[][] matrix)
    {
        // for each row we iterate through the columns
        // starting at the column that matches the number of rows we've already iterated through
        // and ending at the column less the number of rows we've already iterated through
        // for example, in a 4x4 matrix, when we iterate on the second row, we start at index/column 0 + 1 = 1 and end at column 3 - 1 = 2

        // for each column, we make three swaps to put each of the items in the correct places
        // we swap the first item all the way around the array backwards to put it in the correct place, shuffling each of the other items 90 degrees around at the same time

        // this should only iterate over the complete first row, and then for each subsequent row until half way through the depth of the array
        // only the width of the row - the number of rows already seen * 2
        // it also operates in place

        // this means that this should complete in O(1) space and something like O(log N) time

        int rows = matrix.Length;

        if (rows < 2)
        {
            return;
        }

        for (int row = 0; row < rows / 2; row++)
        {
            int lastRowIndex = matrix.Length - 1 - row;
            int lastColumnIndex = matrix[0].Length - 1 - row;

            for (int column = row; column < rows - row - 1; column++)
            {
                // swap the first row and first column for the last row first column
                (matrix[row][column], matrix[lastRowIndex - column][row]) = (matrix[lastRowIndex - column][row], matrix[row][column]);

                // swap the last row first column for the last column last row
                (matrix[lastRowIndex - column][row], matrix[lastRowIndex - row][lastColumnIndex - column]) = (matrix[lastRowIndex - row][lastColumnIndex - column], matrix[lastRowIndex - column][row]);

                // swap the last column last row for the last column first row
                (matrix[lastRowIndex - row][lastColumnIndex - column], matrix[column][lastColumnIndex]) = (matrix[column][lastColumnIndex], matrix[lastRowIndex - row][lastColumnIndex - column]);
            }
        }
    }


    public void RotateB(int[][] matrix)
    {
        int width = matrix.Length;
        int last = matrix.Length - 1;

        if (width < 2)
        {
            return;
        }

        for (int row = 0; row < width / 2; row++)
        {
            for (int col = row; col < width - row - 1; col++)
            {
                int tmp = matrix[col][last - row];
                matrix[col][last - row] = matrix[row][col];
                matrix[row][col] = matrix[last - col][row];
                matrix[last - col][row] = matrix[last - row][last - col];
                matrix[last - row][last - col] = tmp;
            }
        }
    }
}

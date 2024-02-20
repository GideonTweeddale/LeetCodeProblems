namespace LeetCodeProblems.Matrix;
public class SetMatrixZeroes
{
    public void SetZeroes(int[][] matrix)
    {
        // iterate over the matrix by row and column
        // if we find a zero, we set the first item in the row and column to 0.
        // we will have already iterated over these values, so we won't set any other values as a consequence

        // then we iterate over the matrix a second time, setting any value in a row or column that starts with a zero, to zero

        // this should excecute in O(2N) time and O(1) space

        // we need to track these independantly of the other rows and columns because the values in them are overwritten
        bool zeroFirstRow = false;
        bool zeroFirstColumn = false;

        for (int row = 0; row < matrix.Length; row++)
        {
            for (int column = 0; column < matrix[0].Length; column++)
            {
                int value = matrix[row][column];

                if (value == 0)
                {
                    if (row == 0) { zeroFirstRow = true; }
                    if (column == 0) { zeroFirstColumn = true; }

                    matrix[row][0] = 0;
                    matrix[0][column] = 0;
                }
            }
        }

        // iterate through the matrix backward, so as to avoid conflicting the markers
        for (int row = matrix.Length - 1; row >= 0; row--)
        {
            for (int column = matrix[0].Length - 1; column >= 0; column--)
            {
                // this if is super complicated
                // we only care about the start of the row or column being zero, unless we are in the first row or column
                // then the zero flag for the row or column must also be set to true
                if (matrix[row][0] == 0 && (row != 0 || zeroFirstRow) || matrix[0][column] == 0 && (column != 0 || zeroFirstColumn))
                {
                    matrix[row][column] = 0;
                }
            }
        }
    }
}

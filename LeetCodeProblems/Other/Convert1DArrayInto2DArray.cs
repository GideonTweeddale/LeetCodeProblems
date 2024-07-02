namespace LeetCodeProblems.Other;
public class Convert1DArrayInto2DArray

{
    public int[][] Construct2DArray(int[] original, int rows, int columns)
    {
        // if the orignal array length is equal to the rows * the columns we can convert it into a 2d array
        // by looping over the number of rows and assiging the next columns number of elements to a sub array at the row index 
        // this should run in O(N) time and O(N) space - and for the time complexity it will be N / rows 
        if (original == null || rows == 0 || columns == 0)
        {
            return [];
        }

        if (original.Length != rows * columns)
        {
            return [];
        }

        int[][] array2d = new int[rows][];
        int i = 0;

        for (int row = 0; row < rows; row++)
        {
            array2d[row] = original[i..(i += columns)];
        }

        return array2d;
    }
}


namespace LeetCodeProblems.Matrix;
public class SpiralMatrix
{
    // TODO: retry this problem

    public static IList<int> SpiralOrder(int[][] matrix)
    {
        // we need to traverse the length, then the depth, then the length in reverse,then the height minus one, 
        // and then the above again minus one
        // and again until the index is zero

        // So long as we only visit each index once (required by the problem description) then this should be O(N) time and O(1) space, minus the result list

        // we can do this by iterating over the width and depth of the matrix starting with the largest values and decrementing one each iteration
        // within that loop, we need four smaller loops, one for each of width, depth, reverse width, and reverse depth minus one

        IList<int> result = new List<int>();

        int m = matrix.Length, n = matrix[0].Length;

        for (int width = n, depth = m, offset = 0; width > n / 2 && depth > m / 2; width--, depth--, offset++)
        {
            // width
            for (int i = 0; i < width; i++)
            {
                Console.WriteLine($"Widthwise {matrix[offset][i]}");
                result.Add(matrix[offset][i]);
            }

            // depth
            for (int i = offset + 1; i < depth; i++)
            {
                Console.WriteLine($"Depthwise {matrix[i][width - 1]}");
                result.Add(matrix[i][width - 1]);
            }

            // reverse width
            for (int i = width - (2 + offset); i >= 0; i--)
            {
                Console.WriteLine($"Reverse widthwise {i} {matrix[depth - 1][i]}");
                result.Add(matrix[depth - 1][i]);
            }

            // reverse depth
            for (int i = depth - 2; i > offset + 1; --i)
            {
                Console.WriteLine($"Reverse depthwise {matrix[i][offset]}");
                result.Add(matrix[i][offset]);
            }
        }

        return result;
    }

    public static IList<int> SpiralOrderB(int[][] matrix)
    {
        // this was a hard one - I'll need to come back and try it again sometime
        // this is the functional solution
        // I was kind of on the right track except that I used a single offset instead of a rowStart, colStart value
        // the while loop and manual incrementing is also cleaner and more controlled

        // Time - O(N) Space - O(N)
        IList<int> records = new List<int>();

        //We need 4 pointers and we use 2 pointers each time we traverse a row or column.
        // 1 for starting point and 1 for ending
        int rowStart = 0; // for where the row traversal starts and reverse row traversal ends
        int colStart = 0; // from where the column traversal start and reverse column traversal ends
        int rowEnd = matrix[0].Length - 1; // where the row traversal ends and from where reverse row traversal starts
        int colEnd = matrix.Length - 1; // where the  column traversal ends and reverse columns traversal starts

        while (colStart <= colEnd && rowStart <= rowEnd)
        {
            // Row traversal
            for (int i = rowStart; i <= rowEnd; i++)
            {
                records.Add(matrix[colStart][i]);
            }
            colStart++;

            // Column traversal
            if (colStart > colEnd)
            {
                break;
            }

            for (int j = colStart; j <= colEnd; j++)
            {
                records.Add(matrix[j][rowEnd]);
            }
            rowEnd--;

            // Reverse row traversal
            if (rowStart > rowEnd)
            {
                break;
            }

            for (int k = rowEnd; k >= rowStart; k--)
            {
                records.Add(matrix[colEnd][k]);
            }
            colEnd--;

            // Reverse column traversal
            if (colStart > colEnd)
            {
                break;
            }

            for (int m = colEnd; m >= colStart; m--)
            {
                records.Add(matrix[m][rowStart]);
            }
            rowStart++;

            if (rowStart > rowEnd)
            {
                break;
            }
        }

        return records;
    }
}

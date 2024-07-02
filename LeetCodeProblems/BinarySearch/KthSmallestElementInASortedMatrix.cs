namespace LeetCodeProblems.BinarySearch;
public class KthSmallestElementInASortedMatrix
{
    // intuition
    // 1. we can use binary search to find the kth smallest element
    // we know that the largest element will be the last element in the matrix
    // and the smallest element will be the first element in the matrix
    // because all the rows and columns are sorted    

    public int KthSmallest(int[][] matrix, int k)
    {
        int n = matrix.Length;

        // find the largest and the smallest elements
        int min = matrix[0][0];
        int max = matrix[n - 1][n - 1];

        while (min != max)
        {
            int mid = min + (max - min) / 2;
            int count = CountLessOrEqual(mid);

            if (count < k)
            {
                min = mid + 1;
            }
            else
            {
                max = mid;
            }
        }

        return min;

        // helper functions
        // find the number of elements smaller than the mid
        // by starting from the top right corner
        // if the element is smaller than the mid, then all the elements in the same row will be smaller than the mid
        // so we can add the number of elements in the same row to the count
        // and move to the next row
        int CountLessOrEqual(int mid)
        {
            int count = 0;
            int column = n - 1;
            int row = 0;

            while (row < n && column >= 0)
            {
                if (matrix[row][column] <= mid)
                {
                    count += column + 1;
                    row++;
                }
                else
                {
                    column--;
                }
            }

            return count;
        }
    }

    // [[1,5,9],[2,6,13],[12,13,15]]
    // [[1,5,6],[2,9,13],[12,13,15]] - swap the 9 and 6

    // [1,5,9]
    // [10,11,13]
    // [12,13,15]
}


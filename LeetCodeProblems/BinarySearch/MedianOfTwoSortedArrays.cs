namespace LeetCodeProblems.BinarySearch;
public class MedianOfTwoSortedArrays
{    
    // a niave solution would be to merge the sorted arrays and take the median
    // this would be O(m + n) time 
    // the question asks for O(log (m+n))

    // my first thought here is that we are actually looking for the kth element
    // which is the nums1.Length + nums2.Length / 2 element

    // to solve this we can binary search over the smaller of the two arrays
    // making our current partition be half of the smaller array
    // and the first n elements in the second array
    // where n is half the total length of both arrays 
    // minus the number of elements in the left portion the smaller array
    // now that we have our left and right partitions
    // we can do binary search

    // we know that we have the correct left partition of our smaller array
    // if the smaller arrays largest item is smaller than the larger arrays largest
    // and the same in reverse
    
    // if this is not true we need to shift our search window in smaller array
    // if the largest value is larger than the smallest value we need to search left
    // by shifting our right pointer
    // if the smallest right value in the smaller array is too small

    // this will run in O(1) extra memory
    // and O(log k) time where k is the length of the shorter array

    public static double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        if (nums2.Length < nums1.Length)
        {
            (nums1, nums2) = (nums2, nums1);
        }

        int m = nums1.Length;
        int n = nums2.Length;
        int left = 0;
        int right = m;

        while (left <= right)
        {
            int midM = (left + right) / 2;
            int midN = (m + n + 1) / 2 - midM;

            int maxM = (midM == 0) ? int.MinValue : nums1[midM - 1];
            int maxN = (midN == 0) ? int.MinValue : nums2[midN - 1];

            int minM = (midM == m) ? int.MaxValue : nums1[midM];
            int minN = (midN == n) ? int.MaxValue : nums2[midN];

            if (maxM <= minN && maxN <= minM)
            {
                if ((m + n) % 2 == 0)
                {
                    return (Math.Max(maxM, maxN) + Math.Min(minM, minN)) / 2.0;
                }
                else
                {
                    return Math.Max(maxM, maxN);
                }
            }
            else if (maxM > minN)
            {
                right = midM - 1;
            }
            else 
            {
                left = midM + 1;
            }
        }
        
        throw new ArgumentException("Input arrays are not sorted.");
    }   
}


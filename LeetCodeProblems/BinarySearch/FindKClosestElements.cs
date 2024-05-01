namespace LeetCodeProblems.BinarySearch;
public class FindKClosestElements
{
    // intuition
    // we can find x in O(log n) time using binary search 
    // we can then find the k closest elements in sorted order by shrinking our window inwards from k elements either side of x until we have k elements
    // this will take O(k) time giving us a total time complexity of O(log n + k)
    // questions

    // is x guaranteed to be in the array? If it is not, what do we return?
    // it looks like we take the values closest to where the value would sit in the array regardless of its presence in the array.

    // what is meant by closest? closest by numerical value or by proximity? 
    // For example, with an x of 3 and a k of 2 and the array [1,2,3,7]
    // the two numerically closest values are 1 and 2, but the two most proximate values are 2 and 7
    // weird. In the expected outputs it seems that k treats the target values as one of the "closest integers". 
    // the example above needs k to be 3 and to also return 3 in both cases.
    // I really need to read the question more closely before running off on a tangent.
    // closest is numerically closest, with the smaller element being selected when there is a tie.

    // can the array contain dulicate elements?

    // edge cases

    // if x is outside the bounds of the array, we can just return the first k elements or the last k elements

    public IList<int> FindClosestElements(int[] arr, int k, int x)
    {
        if (x > arr[arr.Length - 1]) return arr.TakeLast(k).ToList(); 
        if (x < arr[0]) return arr.Take(k).ToList();

        int left = 0;
        int right = arr.Length - 1;
        int mid = 0;

        while (left <= right)
        {
            mid = left + (right - left) / 2;

            // we've found the taget value
            if (arr[mid] == x)
            {
                break;
            }
            else if (arr[mid] < x)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        // set the pointers to k elements either side of the target value
        left = Math.Max(0, mid - k);
        right = Math.Min(arr.Length - 1, mid + k);

        while (right - left >= k)
        {
            if (Math.Abs(arr[left] - x) <= Math.Abs(arr[right] - x))
            {
                right--;
            }
            else if (Math.Abs(arr[right] - x) < Math.Abs(arr[left] - x))
            {
                left++;
            }
        }
        return arr[left..(right + 1)];
    }
}


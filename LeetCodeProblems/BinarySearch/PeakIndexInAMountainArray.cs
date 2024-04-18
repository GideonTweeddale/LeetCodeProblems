namespace LeetCodeProblems.BinarySearch;
public class PeakIndexInAMountainArray
{
    // intuition
    // we need to find the index in the array that is both preceeded by and followed by a lower value
    // I think this can be solved using binary search
    // the array is guaranteed to rise in value until the index we are searching for and then it is guaranteed to fall in value
    // this means that if the index we have chosen is greater than the index after it and smaller than the index before it, we are ahead of the goal index
    // and it means that if the index we have chosen is less than the index after and greater than the index before it, we are behind the goal index

    public int PeakIndexInMountainArray(int[] arr)
    {
        int firstIndex = 0;
        int lastIndex = arr.Length - 1;

        while(firstIndex < lastIndex)
        {
            int midIndex = firstIndex + (lastIndex - firstIndex) / 2;
            int value = arr[midIndex];

            if (value > arr[midIndex + 1] && value > arr[midIndex - 1])
            {
                return midIndex; // we have found the peak
            }
            else if (value < arr[midIndex + 1])
            {
                firstIndex = midIndex; // we are behind the peak
            }
            else if (value > arr[midIndex + 1])
            {
                lastIndex = midIndex; // we are ahead of the peak
            }
        }

        return 0; // the question guarantees that the peak will be in the array so this should never be reached
    }
}


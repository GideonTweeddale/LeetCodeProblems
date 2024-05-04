namespace LeetCodeProblems.Heap;
public class TopKFrequentElements
{
    // intuition
    // the naive solution to this problem is to sort it
    // iterate through it counting the occurences of each element
    // and insert the elements into a heap once we counted the occurences of that element
    // this would be O(log n) + O(n) + O(log k) of which O(n) is by far the largest, so simplfied it is simply O(log n)

    public int[] TopKFrequent(int[] nums, int k)
    {
        int count = 0;
        PriorityQueue<int, int> heap = new();

        Array.Sort(nums);

        for (int i = 0; i < nums.Length; i++)
        {
            // increment the count
            count++;

            // if the next element is different or we are at the end of the array enqueue the element and reset the count
            if (i == nums.Length - 1 || nums[i] != nums[i + 1])
            {
                heap.Enqueue(nums[i], count);
                count = 0;
            }

            // keep the heap size at k
            if (heap.Count > k)
            {
                heap.Dequeue();
            }
        }

        List<int> result = new();

        for (int i = 0; i < k; i++)
        {            
            result.Add(heap.Dequeue());
        }

        return result.ToArray();
    }
}
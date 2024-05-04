namespace LeetCodeProblems.Heap;
public class TopKFrequentElements
{
    // intuition
    // the naive solution to this problem is to sort it
    // iterate through it counting the occurences of each element
    // and insert the elements into a heap once we counted the occurences of that element
    // this would be O(log n) + O(n log k), so simplfied it is simply O(n log k)

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

    // try using a hashtable to count the occurences of each element rather than sorting the array
    // the sorting version is kinda slow
    // this should be O(n) for the adding to the hashtable + O(n log k) for adding to the heap, so also O(n log k) overall
    // although the O(n) is technically slower than the O(log n) of the sorting version, it might be quicker in practice
    public int[] TopKFrequentB(int[] nums, int k)
    {
        // add the occurences of each element to a hashtable
        Dictionary<int, int> frequencies = new();

        foreach (int num in nums)
        {
            if (!frequencies.ContainsKey(num))
            {
                frequencies.Add(num, 1);
            }
            else
            {
                frequencies[num]++;
            }
        }

        // add the elements to a heap
        PriorityQueue<int, int> heap = new();

        foreach (KeyValuePair<int, int> frequency in frequencies)
        {
            heap.Enqueue(frequency.Key, frequency.Value);

            if (heap.Count > k)
            {
                heap.Dequeue();
            }
        }

        // return the k most frequent elements
        List<int> result = new();

        for (int i = 0; i < k; i++)
        {
            result.Add(heap.Dequeue());
        }

        return result.ToArray();
    }
}
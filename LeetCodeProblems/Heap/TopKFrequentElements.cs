namespace LeetCodeProblems.Heap;
public class TopKFrequentElements
{
    // intuition
    // the naive solution to this problem is to sort it
    // iterate through it counting the occurences of each element
    // and insert the elements into a heap once we counted the occurences of that element
    // this would be O(n log n) for the sort + O(n log k) for the adding to the heap, so simplfied it is O(n log n)

    public static int[] TopKFrequent(int[] nums, int k)
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

        List<int> result = [];

        for (int i = 0; i < k; i++)
        {            
            result.Add(heap.Dequeue());
        }

        return result.ToArray();
    }

    // try using a hashtable to count the occurences of each element rather than sorting the array
    // the sorting version is kinda slow
    // this should be O(n) for the adding to the hashtable + O(n log k) for adding to the heap, so O(n log k) overall
    // so this might be slightly quicker - it is actually slightly slower in practice
    public static int[] TopKFrequentHashtable(int[] nums, int k)
    {
        // add the occurences of each element to a hashtable
        Dictionary<int, int> frequencies = [];

        foreach (int num in nums)
        {
            if (!frequencies.ContainsKey(num))
            {
                frequencies.Add(num, 0);
            }

            frequencies[num]++;
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
        List<int> result = [];

        for (int i = 0; i < k; i++)
        {
            result.Add(heap.Dequeue());
        }

        return result.ToArray();
    }

    // this time lets try bucket sort (this is the first time I have come across this)
    // aparrently this is O(n) time complexity

    // the buckets approach is a little faster than the other two, but still surprisingly slow.
    // Also the C# code is a lot more verbose than the Python code.
    // I wonder if the extra overhead of the ToList and ToArray calls is slowing it down

    // let's try using an array of lists so we don't have to convert the arrays to lists and back again
    // and let's try and make the code a little more concise

    // that helped a little. It is 6ms faster than the previous version and uses 5 mb less memory. 
    // the margins are fine though and that improvement takes it to the 49th percentile for speed and 64th percentile for memory from a previous best of 27th and 5th respectively. Good enough for now.
    public static int[] TopKFrequentBuckets(int[] nums, int k)
    {
        Dictionary<int, int> frequencies = [];

        foreach (int num in nums)
        {
            if (!frequencies.ContainsKey(num))
            {
                frequencies.Add(num, 0);
            }

            frequencies[num]++;
        }
        
        // add the frquencies to the buckets
        List<int>[] buckets = new List<int>[nums.Length + 1];

        foreach (KeyValuePair<int, int> frequency in frequencies)
        {
            if (buckets[frequency.Value] == null)
            {
                buckets[frequency.Value] = [];
            }

            buckets[frequency.Value].Add(frequency.Key);
        }

        // add the elements to the result
        List<int> result = [];

        for (int i = buckets.Length - 1; i >= 0; i--)
        {
            if (buckets[i] != null)
            {
                foreach (int num in buckets[i])
                {
                    result.Add(num);

                    if (result.Count == k)
                    {
                        return result.ToArray();
                    }
                }
            }
        }

        return result.ToArray();
    }
}
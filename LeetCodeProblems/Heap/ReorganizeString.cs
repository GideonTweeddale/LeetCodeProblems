namespace LeetCodeProblems.Heap;
public class ReorganizeString
{
    // intuition 
    // we need to useup the more common characters as soon as possible, so that we don't get backed into a corner we can't get out off
    // so a greedy solution makes sense
    // we could count the frequencies into a hashtable, add the values to a heap, and then iterate through the heap
    // popping the top two values, decrementing the priority of whichever one we didn't last time or is larger, adding the character to the string, and requeing the values if they are greater than 0 count

    // or we could use bucket sort instead of the, and move the character down one place each iteration, keeping track of the last character added and the last max index
    
    // time complexity is O(n log n) because we are adding the values to a heap 
    // space complexity is O(26) or constant because the hashtable and heap will both be maximum 26 elements, one for each lowercase letter of the alphabet
    public string ReorganizeStringHeap(string s)
    {
        // count the frequencies of each character
        Dictionary<char, int> counts = new();

        foreach (char c in s)
        {
            counts[c] = counts.GetValueOrDefault(c, 0) - 1;
        }

        // add the values to a heap
        PriorityQueue<char, int> heap = new();

        for (int i = 0; i < 26; i++)
        {
            char c = (char)('a' + i);
            if (counts.ContainsKey(c))
            {
                heap.Enqueue(c, counts[c]); // convert this to a maz heap by negating the counts
            }
        }

        // if the most common character is greater than half the length of the string + 1, then it is impossible to reorganize the string
        if (-counts[heap.Peek()] > (s.Length + 1) / 2)
        {
            return "";
        }

        // build the new string
        char lastChar = char.MaxValue;
        System.Text.StringBuilder sb = new();

        // iterate through the heap
        while (heap.Count > 0)
        {
            // handle the last character
            if (heap.Count == 1)
            {
                sb.Append(heap.Dequeue());
                break;
            }            

            if(lastChar == heap.Peek())
            {
                char first = heap.Dequeue();
                char second = heap.Dequeue();

                sb.Append(second);
                counts[second]++;
                lastChar = second;

                if (counts[first] < 0)
                {
                    heap.Enqueue(first, counts[first]);
                }
                if (counts[second] < 0)
                {
                    heap.Enqueue(second, counts[second]);
                }
            }
            else
            {
                char first = heap.Dequeue();
                sb.Append(first);
                counts[first]++;
                lastChar = first;

                if (counts[first] < 0)
                {
                    heap.Enqueue(first, counts[first]);
                }
            } 
        }

        return sb.ToString();
    }

    // I think this is possible, it is just a little more complicated and I don't want to spend the time to implement it right now. 
    public string ReorganizeStringBucketSort(string s)
    {
        // count the frequencies of each character
        Dictionary<char, int> counts = new();

        foreach (char c in s)
        {
            counts[c] = counts.GetValueOrDefault(c, 0) - 1;
            if (counts[c] > (s.Length + 1) / 2)
            {
                return ""; // if the most common character is greater than half the length of the string + 1, then it is impossible to reorganize the string
            }
        }

        // add the items to the buckets
        List<char>[] buckets = new List<char>[s.Length + 1];

        for (int i = 0; i < 26; i++)
        {
            char c = (char)('a' + i);

            if (counts.ContainsKey(c))
            {
                if (buckets[counts[c]] == null)
                {
                    buckets[counts[c]] = [];
                }

                buckets[counts[c]].Add(c);
            }
        }

        // build the new string
        char lastChar = char.MaxValue;
        int maxIndex = s.Length;
        System.Text.StringBuilder sb = new();

        // despite the nested loops, this should run in O(n) time complexity
        for(int i = 0; i < s.Length; i++)
        {
            bool foundBucket = false;

            for (int j = maxIndex; j >= 0; j--)
            {
                foundBucket = foundBucket || buckets[j] != null && buckets[j].Count > 0;

                // update max index if we have an empty bucket not preceeded by a full bucket
                if (!foundBucket)
                {
                    maxIndex = j - 1;
                    continue;
                }

                // find the first none null bucket that either has two characters or has a character that is not the same as the last character
                if (buckets[j] != null && (buckets[j].Count > 1 || (buckets[j].Count == 1 && buckets[j][0] != lastChar)))
                {
                    // find the first character that is not the same as the last character in the bucket
                    char c = char.MaxValue;

                    foreach (char ch in buckets[j])
                    {
                        if (lastChar != ch)
                        {
                            c = ch;
                            break;
                        }
                    }

                    // add the character to the string
                    sb.Append(c);
                    lastChar = c;

                    if (j > 0)
                    {
                        if (buckets[j - 1] == null)
                        {
                            buckets[j - 1] = [];
                        }

                        buckets[j - 1].Add(c);
                    }

                    // remove the character from the old bucket
                    buckets[j].Remove(c);

                    break;
                }
            }
        }

        return sb.ToString();
    }
}
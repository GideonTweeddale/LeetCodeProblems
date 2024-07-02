namespace LeetCodeProblems.Heap;
public class SortCharactersByFrequency
{
    // intuition
    // we can use a hashtable to store the frequency of the characters 
    // and then bucket sort to sort them 
    // the simply run through the buckets appending the characters the number of times for the bucket they are in to a new string
    // return the string

    // adding the values to the hashtable will be O(n) because we interate through every index in the string and adding to the Hashtable is an O(1) operation
    // the bucket sort process will also be worst case O(n) where every character only appears once in the string
    // adding the characters from the buckets to the string will also be O(n)
    // so our time complexity will be O(3n) or O(n)

    // the hashtable will be worst case O(n) memory where every character only appears once in the string and the bucket array will be O(n) memory
    // giving us O(2n) or just O(n) memory

    public static string FrequencySort(string s)
    {
        // add the frequencies of each character to a hashtable
        Dictionary<char, int> frequencies = [];

        foreach (char c in s)
        {
            if (!frequencies.ContainsKey(c))
            {
                frequencies.Add(c, 0);
            }

            frequencies[c]++;
        }

        // add the characters to a bucket array
        List<char>[] buckets = new List<char>[s.Length + 1];

        foreach (KeyValuePair<char, int> frequency in frequencies)
        {
            if (buckets[frequency.Value] == null)
            {
                buckets[frequency.Value] = [];
            }

            buckets[frequency.Value].Add(frequency.Key);
        }

        // add the characters to a new string
        System.Text.StringBuilder result = new();

        // working backwards througn the buckets
        for (int i = buckets.Length - 1; i >= 0; i--)
        {
            if (buckets[i] != null)
            {
                // append the character the same number as the bucket index
                foreach (char c in buckets[i])
                {
                    for (int j = 0; j < i; j++)
                    {
                        result.Append(c);
                    }
                }
            }
        }

        return result.ToString();
    }

    // Damn. Solved this in 12:25 super jetlagged on 3.5 hours sleep two nights in a row. 
    // And the solution is in the 46th percentile for speed and 86th percentile for memory usage.
}
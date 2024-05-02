namespace LeetCodeProblems.SlidingWindow;
public class FruitIntoBaskets
{
    // intuition
    // we could maintain a hashtable with the total number of time we've seen a fruit and for each new tree update the table
    // and two pointers for our current baskets
    // if we have seen more than one of our current baskets, swap out the fruit in the basket
    // at the end return the number of fruit in the two baskets added together
    // this would have a time complexity of O(n) because we would iterate through the fruits array once and the hash table inserts and lookups should be O(1) (almost always true)

    // damn. I misunderstood the question. This is a sliding window problem, because once we start adding fruit we cannot skip a tree.
    // So we are looking for the longest subtree with only two types of fruit.

    public int TotalFruitOops(int[] fruits)
    {
        Dictionary<int, int> counts = new ();
        counts[-1] = 0;
        
        // our baskets
        int a = -1, b = -1;
        
        foreach (int fruit in fruits)
        {
            if (!counts.ContainsKey(fruit))
            {
                counts[fruit] = 1;
            } 
            else
            {
                counts[fruit]++;
            }

            if (fruit != a && counts[fruit] > counts[a])
            {
                b = a;
                a = fruit;
            } 
            else if (fruit != a && fruit != b && counts[fruit] > counts[b])
            {
                b = fruit;
            }
        }

        return counts[a] + counts[b];
    }

    // this is a sliding window problem
    // we can keep track of the counts of the fruits in a hash table
    // our right pointer iterates over the fruits array adding the fruit to the hash table or incrementing the count in the hash table
    // if the hash table has more than two keys at any point we iterate the left pointer through the table until we have two keys again
    // as we go, we increment a variable total for each iteration of the right pointer and decrement it for each iteration of the left pointer
    // at the end of each iteration, we set max to whichever is larger, max or total
    // finally we return max
    // this will be O(2n) or just O(n) time and I think it is actually O(1) space because the hash table will never have more than 3 keys

    public int TotalFruit(int[] fruits)
    {
        Dictionary<int, int> counts = new (); // fruit type, count
        int max = 0, total = 0, left = 0, right = 0;

        for (right = 0; right < fruits.Length; right++)
        {
            if (!counts.ContainsKey(fruits[right]))
            {
                counts[fruits[right]] = 1;
            }
            else
            {
                counts[fruits[right]]++;
            }

            total++;

            while (counts.Count > 2)
            {
                counts[fruits[left]]--;
                total--;

                if (counts[fruits[left]] == 0)
                {
                    counts.Remove(fruits[left]);
                }

                left++;
            }

            max = Math.Max(max, total);
        }

        return max;
    }
}

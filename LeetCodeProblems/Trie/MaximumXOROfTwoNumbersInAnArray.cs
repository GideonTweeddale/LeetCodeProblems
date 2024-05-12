namespace LeetCodeProblems.Trie;
public  class MaximumXOROfTwoNumbersInAnArray
{
    // intuition
    // we could brute force this in O(n^2) time by checking every combination

    // could we create a hashset out of our input nums whose key is the array of bits in the num
    // and then loop over our nums and for each num look in the hashset for the array of bits that would fill the gaps 
    // this would tell us if there is a perfect solution in O(n) time, but doesn't quite solve the problem

    // we could build a trie out of the bit arrays that represent the numbers
    // then loop over the bit array of numbers and see if there is another number in the set that compliments it
    // the time and space complexity of this problem will both be O(n * 32)
    // we loop over the array of nums twice, once to insert the nums into the trie and once to find the max xor
    // within each loop, we loop over the possible bit values of an int, of which there are 32
    // the trie will take up max O(n * 32) space also where n is the length of nums and 32 is the number of bits in a an int
    public int FindMaximumXOR(int[] nums)
    {
        TrieNode root = new();

        foreach (int num in nums)
        {
            TrieNode node = root;
            for (int i = 31; i >= 0; i--)
            {
                // the >> right shift operator moves the num i places to the right
                // then does an & ooperation on the rightmost bit
                // if both are one it returns 1 otherwise it returns 0
                // in otherwords, bit will be 1 when our bit value at position i = 1 and 0 otherwise
                int bit = (num >> i) & 1;

                if (node.children[bit] == null)
                {
                    node.children[bit] = new TrieNode();
                }
                node = node.children[bit];
            }
        }

        int max = int.MinValue;

        foreach (int num in nums)
        {
            TrieNode node = root;

            int XOR = 0;

            for (int i = 31; i >= 0; i--)
            {
                // the >> right shift operator moves the num i places to the right
                // then does an & ooperation on the rightmost bit
                // if both are one it returns 1 otherwise it returns 0
                // in otherwords, bit will be 1 when our bit value at position i = 1 and 0 otherwise
                int bit = (num >> i) & 1;

                // this flips the bit and checks if there is a complimentary child at this level
                if (node.children[bit ^ 1] != null)
                {
                    XOR += (1 << i); // if there is, set the bit in our XOR at the ith index to 1
                    node = node.children[bit ^ 1]; // move to the next level
                }
                else
                {
                    node = node.children[bit];
                }
            }

            max = Math.Max(max, XOR);
        }

        return max;
    }

    class TrieNode
    {
        public TrieNode[] children = new TrieNode[2]; // length two because there are only two possible values 0 or 1
    }

    // TODO - return and implement/understand this solution
    // https://www.youtube.com/watch?v=KgkOp17GzeY

    // TODO return and attempt to rewrite the trie answer from scratch
}



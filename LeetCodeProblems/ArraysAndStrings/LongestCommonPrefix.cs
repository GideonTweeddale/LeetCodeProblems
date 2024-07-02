namespace LeetCodeProblems.ArraysAndStrings;
public class LongestCommonPrefix14
{
    // intuition
    // a naive solution that would solve this in time O(t) time, where t is the combined number of characters in all of the elements in the array
    // could be achieved by looping through each index in the first element in the array and within that loop looping the same index in each of the other elements
    // we could return early if we find an index that isn't in any of the elements, or if we find a mismatch
    // this solution would be O(1) space because we don't require any additional data sctructures

    // a more advanced solution would be to build a trie with the elements and then return the longest substring
    // this would take the same O(t) time to preprocess and generate the trie, but all the lookups on the tie after that would be more efficient
    // TODO practice implementing a trie

    // naive solution
    public string LongestCommonPrefix(string[] strs)
    {
        if (strs is null || strs[0] is null || strs[0].Length < 1)
        {
            return string.Empty;
        }

        string prefix = string.Empty;

        // loop over the first string
        for (int i = 0; i < strs[0].Length; i++)
        {
            if (strs[0].Length <= i)
            {
                return prefix;
            }

            // loop over the other strings
            foreach (string str in strs)
            {
                if (str.Length <= i || str[i] != strs[0][i])
                {
                    return prefix;
                }
            }

            // if we found no mismatch or end of string append the char to the end of the string
            prefix += strs[0][i];
        }

        return prefix;
    }
}

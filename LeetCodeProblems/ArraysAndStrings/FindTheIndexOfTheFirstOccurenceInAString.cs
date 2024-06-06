namespace LeetCodeProblems.ArraysAndStrings;
public class FindTheIndexOfTheFirstOccurenceInAString
{
    // intution
    // the naive solution to this is to iterate through the haystack comparing the substring of all indexes not before our current index with the string of needle
    // any time we find a mismatch, we how out and increment the start index in haystack
    // this solution will be O(n * m) where n is the length of haystack and m is the length of needle
    // this solution will be O(1) space because we don't need any additional datastructures
    // in practice, this solution should be fine because the strings are unlikely to be very long 
    // and the first character of needle is unlikely to appear that often in haystack

    // naive solution - which is > 90% in both speed and memory on leetcode
    public int StrStr(string haystack, string needle)
    {
        for (int i = 0; i < haystack.Length + 1 - needle.Length; i++)
        {
            for (int j = 0; j < needle.Length; j++)
            {
                if (haystack[i + j] != needle[j]) break;

                if (j == needle.Length -1) return i;
            }
        }

        return -1;
    }
}

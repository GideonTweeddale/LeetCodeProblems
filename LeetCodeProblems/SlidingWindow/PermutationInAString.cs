namespace LeetCodeProblems.SlidingWindow;
public class PermutationInAString
{
    // intuition
    // each string can contain a maximum of 26 different characters 
    // if any substring of s2 contains the same counts of characters as s1 then it is a permutation
    // this means that we can treat this as a sliding window problem
    // we can use two hashtables to store the counts of the character frequencies in s2 and in the current substring of s2
    // the uggliest part of this approach is that we have to loop through the values of the two hashtables to see if they all match, when the counts are the same
    // this will still be O(n) time because the hashtables will never have more than 26 items in them (the number of lowercase letters in the dictionary)
    // and the two hashtables will be O(1) constant space for the same reason

    // we can make this slightly more efficient in some cases by keeping track of the total numbers of characters we have seen in the substring
    // and only check if we have a match when both the counts of in the hash tables match and the total number of characters match
    // we don't even actually need a total variable because the difference between left and right is the total

    public static bool CheckInclusion(string s1, string s2)
    {
        // create the hash tables
        Dictionary<char, int> s1Counts = new();
        Dictionary<char, int> s2Counts = new();

        // initailize the hash table for s1 - this will never have more than 26 items and doesn't need to be updated once it has been created
        foreach (char c in s1)
        {
            if (!s1Counts.ContainsKey(c))
            {
                s1Counts[c] = 1;
            }
            else
            {
                s1Counts[c]++;
            }
        }

        int left = 0, right = 0;

        while (right < s2.Length)
        {
            if (!s2Counts.ContainsKey(s2[right]))
            {
                s2Counts[s2[right]] = 1;
            }
            else
            {
                s2Counts[s2[right]]++;
            }

            // move the left pointer
            while (right - left + 1 > s1.Length)
            {
                s2Counts[s2[left]]--;

                if (s2Counts[s2[left]] == 0)
                {
                    s2Counts.Remove(s2[left]);
                }

                left++;
            }

            // check if we have a match
            if (right - left + 1 == s1.Length)
            {
                if (CheckEqual(s1Counts, s2Counts))
                {
                    return true;
                }
            }

            right++;
        }

        return false; // if we get here we didn't find a match

        // helper functions
        bool CheckEqual(Dictionary<char, int> a, Dictionary<char, int> b)
        {
            foreach (char c in a.Keys)
            {
                if (!b.ContainsKey(c))
                {
                    return false;
                }
                else if (a[c] != b[c])
                {
                    return false;
                }
            }

            return true;
        }
    }
    
    //public bool CheckInclusion(string s1, string s2)
    //{
    //    // create the hash tables
    //    Dictionary<char, int> s1Counts = new();
    //    Dictionary<char, int> s2Counts = new();

    //    // initailize the hash table for s1 - this will never have more than 26 items and doesn't need to be updated once it has been created
    //    foreach (char c in s1)
    //    {
    //        if (!s1Counts.ContainsKey(c))
    //        {
    //            s1Counts[c] = 1;
    //        }
    //        else
    //        {
    //            s1Counts[c]++;
    //        }
    //    }

    //    int left = 0, right = 0;

    //    while (right < s2.Length)
    //    {
    //        if (!s2Counts.ContainsKey(s2[right]))
    //        {
    //            s2Counts[s2[right]] = 1;
    //        }
    //        else
    //        {
    //            s2Counts[s2[right]]++;
    //        }

    //        // move the left pointer
    //        while (s2Counts.Count > s1Counts.Count)
    //        {
    //            s2Counts[s2[left]]--;

    //            if (s2Counts[s2[left]] == 0)
    //            {
    //                s2Counts.Remove(s2[left]);
    //            }

    //            left++;
    //        }

    //        // check if we have a match
    //        if (s2Counts.Count == s1Counts.Count)
    //        {
    //            bool match = true;

    //            foreach (char c in s1Counts.Keys)
    //            {
    //                if (!s2Counts.ContainsKey(c) || s2Counts[c] != s1Counts[c])
    //                {
    //                    match = false;
    //                    break;
    //                }
    //            }

    //            // if we have a match we can quit early
    //            if (match)
    //            {
    //                return true;
    //            }
    //        }

    //        right++;
    //    }

    //    return false; // if we get here we didn't find a match
    //}
}

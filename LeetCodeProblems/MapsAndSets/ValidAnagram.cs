namespace LeetCodeProblems.MapsAndSets;
public class ValidAnagram
{
    // intuition
    // so a s will be an anagagram of t if s has the same number of occurences of each char as t
    // we can find this by iterating through s and incrementing the occurences of each char in a map
    // and then iterating through t and decrementing the occurences of each char
    // if we find a char in t where there 0 remaining occurences in our map, it means that there is a mismatching number of that char in s and t
    // so we can return false
    // if we reach the end of t and we didn't find any mismatches, we can return true
    // we will also need startby checking that s and t are the same length
    // if they aren't they cannot be anagrams 

    // this will run in worst case O(2n) or O(n) time simplified, where n is the length of s and t and they are a valid anagram 
    // because we will iterate through all indexes in both strings
    // this will use in O(26) space for the map containing the occurences of all lowercase english characters

    // to adapt this code to work for all unicode characters, we would need to create our map in the method
    // and add each character in s as a key to it as well as counting the occurences
    // then as we iterate through t, we would need to check that the character exists as a key before checking the occurence count
    // and return false, if it didn't

    // init the map of lowercase english letters
    private Dictionary<char, int> counts = new Dictionary<char, int>
    {
        { 'a', 0 }, { 'b', 0 }, { 'c', 0 }, { 'd', 0 }, { 'e', 0 },
        { 'f', 0 }, { 'g', 0 }, { 'h', 0 }, { 'i', 0 }, { 'j', 0 },
        { 'k', 0 }, { 'l', 0 }, { 'm', 0 }, { 'n', 0 }, { 'o', 0 },
        { 'p', 0 }, { 'q', 0 }, { 'r', 0 }, { 's', 0 }, { 't', 0 },
        { 'u', 0 }, { 'v', 0 }, { 'w', 0 }, { 'x', 0 }, { 'y', 0 },
        { 'z', 0 }
    };


    public bool IsAnagram(string s, string t)
    {
        if(s.Length != t.Length) return false;

        // count the chars in s
        foreach (char c in s) counts[c]++;

        foreach (char c in t)
        {
            if (counts[c] <= 0) return false;
            counts[c]--;
        }

        return true;
    }

    // and here is the unicode compliant version
    public bool IsAnagramUnicode(string s, string t)
    {
        if (s.Length != t.Length) return false;

        Dictionary<char, int> cCounts = new();

        // count the chars in s
        foreach (char c in s)
        {
            if (!cCounts.ContainsKey(c))
                cCounts.Add(c, 0);

            cCounts[c]++;
        }

        foreach (char c in t)
        {
            if (!cCounts.ContainsKey(c) || counts[c] <= 0) return false;

            counts[c]--;
        }

        return true;
    }
}


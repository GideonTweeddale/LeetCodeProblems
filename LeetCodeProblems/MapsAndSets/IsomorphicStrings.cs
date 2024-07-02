namespace LeetCodeProblems.MapsAndSets;
public class IsomorphicStrings
{
    // I think I totally misunderstood this problem below
    // late night coding hazards, I guess
    // let's try again

    // intuition
    // huh, so an isopmorphic string will have equivalent occurences of characters at the same indexes
    // or in other words, at every index where the char a appears in one string some other char must always appear in the other string
    // this is a much tighter definition, which makes it a lot easier to prove that a given pair are not isomorphic

    // we can do this by iterating through the strings and saving the pair of characters into a pair of maps
    // so if we encounter a in string s at index 0 and b in string t at index zero, we add key a and value b into our map
    // and also in reverse
    // then at every follwing index where we find a in string s, we look it up in the map and make sure that the char in string t matches the value in the pairing in our map
    // and also in reverse
    // we do this for all characters in s and t
    // if we find any mismatches, we return false
    // otherwise we return true

    // this will run in O(n) time, where n is the length of s
    // and in the worst case, O(n) space where every character in our string occurs only once and they are isomorphic

    // note, I am assuming that we don't need to check if the lengths match because the question assures us that they always will

    public bool IsIsomorphic(string s, string t)
    {
        Dictionary<char, char> mapS = new();
        Dictionary<char, char> mapT = new();

        for (int i = 0; i < s.Length; i++)
        {
            // add the chars to our maps
            if (!mapS.ContainsKey(s[i]))
            {
                mapS[s[i]] = t[i];
            }

            if (!mapT.ContainsKey(t[i]))
            {
                mapT[t[i]] = s[i];
            }

            // check our char pairings
            if (mapS[s[i]] != t[i])
            {
                return false;
            }

            if (mapT[t[i]] != s[i])
            {
                return false;
            }
        }

        return true;
    }

    // old incorrect intuition
    // intuition
    // this is a weird occurences problem
    // if I understand it correctly the question is actually do the two strings have equal numbers of occurences of chars
    // in other words both have a char that occurs n times and a char that occurs x times, etc.
    // the first thing to note about this is that the strings must be the same length
    // otherwise at least one char will occur a different number of times

    // we can solve this by generating two maps, one for each string, with the number of chars that appear a given number of times

    // this would be O(n + m) time and O(n + m) space where n is the length of s and m is the length of t
    // because we iterate through both n and m to add the char counts to the maps 
    // and then iterate over those maps, to make sure that they are equivalent

    public bool IsIsomorphicIncorrect(string s, string t)
    {
        if (s.Length != t.Length)
        {
            return false;
        }

        // get the number of occurences of each char in each string
        Dictionary<char, int> mapS = MapCharCounts(s);
        Dictionary<char, int> mapT = MapCharCounts(t);

        // get the number of occurences of chars with a given number of occurences
        Dictionary<int, int> mapCounts = new();

        foreach (KeyValuePair<char, int> kvp in mapS)
        {
            if (!mapCounts.ContainsKey(kvp.Value))
            {
                mapCounts.Add(kvp.Value, 0);
            }

            mapCounts[kvp.Value]++;
        }
        
        // check the the occurences of t against s
        // if we find a mismatch return false
        foreach(KeyValuePair<char, int> kvp in mapT)
        {
            if (!mapCounts.ContainsKey(kvp.Value) || mapCounts[kvp.Value] <= 0)
            {
                return false;
            }

            mapCounts[kvp.Value]--;
        }

        return true;
    }

    private Dictionary<char, int> MapCharCounts(string s)
    {
        Dictionary<char, int> mapS = new();

        foreach(char c in s)
        {
            if (!mapS.ContainsKey(c))
            {
                mapS.Add(c, 0);
            }

            mapS[c]++;
        }

        return mapS;
    }
}


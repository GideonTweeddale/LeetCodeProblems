namespace LeetCodeProblems.MapsAndSets;
public class RansomNote
{
    // intuition
    // we can create a map/hash table/dictionary with the letter as the key and the number of occurences as the value
    // we can create this by iterating over every char in the magazine string and adding the values to the map
    // then we can iterate through the ransom note, checking each char against the map
    // if the char is in the map, decrement the count
    // if the char is not in the map/the count is 0
    // return false
    // if we reach the end of the ransom note, return true

    // this will be O(n + m) time where n is the number of chars in the ransomNote and and m is the number of chars in the magazine
    // this will be O(t) worst case space where t is the number unique chars allowed (for example all alphanumerics, etc)
    // in this case O(26) which is the set of all lowercase english letters

    // this is a general solution that would work for any char input set 

    public bool CanConstruct(string ransomNote, string magazine)
    {
        Dictionary<char, int> map = new();
        
        // add the chars to the map
        // this operation could be done once and then many ransom notes checked against it
        foreach(char c in magazine)
        {
            if (map.ContainsKey(c))
            {
                map[c]++;
            }
            else
            {
                map.Add(c, 1);
            }
        }

        // check the ransom note
        foreach(char c in ransomNote)
        {
            if (map.ContainsKey(c) && map[c] > 0)
            {
                map[c]--;
            }
            else
            {
                return false;
            }
        }

        return true;
    }

    // we could optimise this down because we know that the input set is only lowercase english letters
    // we could use a prebuilt map or even an array of length 26 where the index is the is the characters index in the alphabet
    // which we can get by subtracting 'a' from the char

    // I think that this is smellier than normal code
    // but it is so much faster that, if we can be sure of the size of the input, maybe it is worth it

    public bool CanConstructB(string ransomNote, string magazine)
    {
        int[] counts = new int[26];

        // add the chars to the array
        foreach (char c in magazine)
        {
            counts[c - 'a']++;
        }

        // check the ransom note
        foreach (char c in ransomNote)
        {
            counts[c - 'a']--;

            if (counts[c - 'a'] < 0)
            {
                return false;
            }
        }

        return true;
    }
}


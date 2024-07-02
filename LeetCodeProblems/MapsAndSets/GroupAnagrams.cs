namespace LeetCodeProblems.MapsAndSets;
public class GroupAnagrams49
{
    // intuition
    // we can solve this by use thing counts of the occurences of each character in a string as the key in a map
    // with a collection of strings holding all the strings with those counts
    // then we iterate through the string in the collection, count their occurences of the 26 lowercase letters of the english alphabet
    // and add them to the map
    // then extract the list of values in the map and return it

    // this would run in O(n * m) time where n is the number of strings and m is the average length of the string 
    // another way to think about this is that it would run in O(n) time where n is the sum of all the chars in all the strings in strs
    // this would take O(n * m * 26) space because we generate an array of length 26 for every string in str

    // this doesn't work because .Net treats both Tuple and a List<int> as unique objects and so every key in our dictionary ends up being "unique"
    // we can get arround this by turning our string into a char array
    // sorting that char array to remove order as a variable
    // then combining the char array back into a string and using it as the key in our map

    public static IList<IList<string>> GroupAnagrams(string[] strs)
    {
        Dictionary<string, IList<string>> map = new();

        foreach (string s in strs)
        {
            char[] charArray = s.ToCharArray();
            Array.Sort(charArray);
            string sortedString = new string(charArray);

            if (!map.ContainsKey(sortedString))
            {
                map[sortedString] = [];
            }

            map[sortedString].Add(s);
        }

        return map.Values.ToList();
    }
}


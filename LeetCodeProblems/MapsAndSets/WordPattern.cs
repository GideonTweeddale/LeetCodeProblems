namespace LeetCodeProblems.MapsAndSets;
public class WordPattern290
{
    // intuition
    // we can solve this in O(n) time and space by iterating through our pattern string
    // and inserting the word we find in s into a map with the key being the letter in the patter
    // if our pattern letter is already in the map for a given index, the word we find in s must match the word in the map
    // we find the word in s by iterating from the current index to the next space char (we could also pre split s on spaces, but this would consume slightly more memory)
    // if we reach the end of our pattern, but chars remain in our string, it cannot be a match, or if we pre split and the count of our words != the length of our pattern
    // note, this also needs the mapping to go both ways, so we need two maps

    // implement the simple version with the pre split
    public static bool WordPattern(string pattern, string s)
    {
        string[] words = s.Split(' ');

        if (words.Length != pattern.Length)
        {
            return false;
        }

        Dictionary<char, string> patternToWord = new();
        Dictionary<string, char> wordToPattern = new();

        for (int i = 0; i < pattern.Length; i++)
        {
            if (!patternToWord.ContainsKey(pattern[i]))
            {
                patternToWord.Add(pattern[i], words[i]);
            }

            if (!wordToPattern.ContainsKey(words[i]))
            {
                wordToPattern.Add(words[i], pattern[i]);
            }

            if (patternToWord[pattern[i]] != words[i])
            {
                return false;
            }

            if (wordToPattern[words[i]] != pattern[i])
            {
                return false;
            }

            //if (!patternToWord.ContainsKey(pattern[i]))
            //{
            //    // if the pairing exists one way but not the other, it is clearly wrong
            //    if (wordToPattern.ContainsKey(words[i])) return false;

            //    patternToWord[pattern[i]] = words[i];
            //    wordToPattern[words[i]] = pattern[i];
            //}
            //else if (patternToWord[pattern[i]] != words[i]) return false;
        }

        return true;
    }
}


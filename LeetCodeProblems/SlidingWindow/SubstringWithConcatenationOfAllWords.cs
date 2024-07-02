namespace LeetCodeProblems.SlidingWindow;
public class SubstringWithConcatenationOfAllWords
{
    // intuition
    // if s.length isn't a multiple of words[any].length - this doesn't matter because we don't need to use the entire string
    // return [] when no concatenated string
    // we can only use each word once and we must use all the words in the substring
    // there don't appear t be any limitations on the input string beyond that it will contain lowercase english letters
    // I guess we assume that it could be a jumble of random letters, with or without a matching substring in it somewhere

    // we need an output list of ints for the result index

    // we can solve this in O(n) time
    // we put words array into a map for fast lookup where the key is the word and the value is if we have used it or not
    // we iterate over the indexes in s until we reach the length of a word
    // we then check if our sustring is in the map and hasn't been used yet
    // if it isn't 

    public static IList<int> FindSubstring(string s, string[] words)
    {
        if (s.Length == 0 || words.Length == 0)
        {
            return [];
        }

        int wordLength = words[0].Length; 
        int totalWords = words.Length; 
        int substringLength = wordLength * totalWords;

        if (s.Length < substringLength)
        {
            return [];
        }

        Dictionary<string, int> wordCounts = [];

        foreach (string word in words)
        {
            if (!wordCounts.ContainsKey(word))
            {
                wordCounts.Add(word, 0);
            }

            wordCounts[word] += 1;
        }

        IList<int> validStarts = [];

        for (int i = 0; i < wordLength; i++)
        {
            Dictionary<string, int> currentWordCounts = [];
            int wordsFound = 0;
            int left = i;

            for (int j = i; j <= s.Length - wordLength; j += wordLength)
            {
                string currentWord = s.Substring(j, wordLength);

                // If the current word is in the wordCount dictionary, update the counts
                if (wordCounts.ContainsKey(currentWord))
                {
                    if (currentWordCounts.ContainsKey(currentWord))
                    {
                        currentWordCounts[currentWord]++;
                    }
                    else
                    {
                        currentWordCounts[currentWord] = 1;
                    }

                    wordsFound++;

                    // Adjust the left index of the window if any word count exceeds the required count
                    while (currentWordCounts[currentWord] > wordCounts[currentWord])
                    {
                        string leftWord = s.Substring(left, wordLength);
                        currentWordCounts[leftWord]--;
                        wordsFound--;
                        left += wordLength;
                    }

                    // If all words are found, add the left index to the result
                    if (wordsFound == totalWords)
                    {
                        validStarts.Add(left);
                        string leftWord = s.Substring(left, wordLength);
                        currentWordCounts[leftWord]--;
                        wordsFound--;
                        left += wordLength;
                    }
                }
                // If the current word is not in the wordCount dictionary, reset the counts and move the left index
                else
                {
                    currentWordCounts.Clear();
                    wordsFound = 0;
                    left = j + wordLength;
                }
            }
        }

        return validStarts;
    }
}


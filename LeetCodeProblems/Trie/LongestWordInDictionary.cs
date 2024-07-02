namespace LeetCodeProblems.Trie;
public  class LongestWordInDictionary
{
    // hashset solution copied from leetcode.
    // huh - this is pretty much what I had in my intuition below
    // it adds the words to a hashset and then loops through each prefix substring in each word, checking if they are in the hashset
    // this should be O(mn) where n is the length of words and m is the number of prefix strings in each word
    // Let's test this and see if it is quicker

    // so the hashset solution is a lot quicker. I wonder why.

    public static string LongestWord(string[] words)
    {
        HashSet<string> hs = [.. words];
        string result = string.Empty;

        foreach (string w in words)
        {
            bool found = true;

            for (int length = w.Length; length >= 1; length--)
            {
                if (!hs.Contains(w[..length]))
                {
                    found = false;
                    break;
                }
            }

            if (!found)
            {
                continue;
            }

            if (result.Length < w.Length)
            {
                result = w;
            }
            else if (result.Length == w.Length && StringComparer.Ordinal.Compare(w, result) < 0)
            {
                result = w;
            }
        }

        return result;
    }


    // intuition
    // does this mean that every character must be a final character in a word?
    // could we use a trie to solve this? 
    // if we added all the words to a trie, we could do a depth first search to find the longest word made up of smaller words
    // we could also turn our input dictionary into a set
    // but that solution would O(mn) because we'd have to check every possible prefix of every possible word to find the longest

    // based on example 2, if we have more than one possible answer of the same length, we need to return the one the is lexicographically the smallest

    public static string LongestWordTrie(string[] words)
    {
        Trie trie = new();

        // add the words to the trie
        foreach (string word in words)
        {
            trie.Insert(word);
        }

        // find the longest word that has all prefices in the trie
        string longestWord = string.Empty;

        foreach (string word in words)
        {
            if(trie.HasPrefixes(word))
            {
                if (word.Length == longestWord.Length && word.CompareTo(longestWord) == 1)
                {
                    longestWord = word;
                }

                if (word.Length > longestWord.Length)
                {
                    longestWord = word;
                }
            }
        }

        return longestWord;
    }

    private class Trie
    {
        public TrieNode root = new();

        public void Insert(string word)
        {
            TrieNode node = root;

            foreach (char c in word)
            {
                if (!node.children.ContainsKey(c))
                {
                    node.children.Add(c, new TrieNode());
                }
                node = node.children[c];
            }

            node.wordEnd = true;
        }

        public bool HasPrefixes(string word)
        {
            TrieNode node = root;

            foreach (char c in word)
            {
                if (!node.children.ContainsKey(c) || !node.children[c].wordEnd)
                {
                    return false;
                }

                node = node.children[c];
            }

            return true;
        }
    }

    private class TrieNode
    {
        public Dictionary<char, TrieNode> children = [];
        public bool wordEnd = false;
    }
}



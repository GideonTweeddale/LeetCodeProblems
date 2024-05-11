namespace LeetCodeProblems.Utils;

public class Trie // also known as a Prefix Tree
{
    // all operations on the Trie are O(n) time and O(n) space or better
    // where n is the number of chars in the, not the size of the dictionary
    // the performance of the individal operations is complexity independant of the size of the dictionary

    // the dictionary itself is technically O(mn) space complexity
    // where n is the number of words we want to include in our Trie
    // and m is the size of the alphabet we use
    // if we limit the alphabet to lowercase letters for example, then m=26 and our space complexity is O(26n) or just O(n)
    // note - this implementation allows any set of chars to be used for m

    private TrieNode root;

    public Trie()
    {
        root = new TrieNode();
    }

    // where n is the number of chars in the word
    // insert is worst case O(n) space where none of the chars in our word are already in the dictionary
    // insert is O(n) time because we will itereate through every char in the word every time
    // note that the hashmap search for the key is O(1)
    // even an array lookup could be O(1) here because it would be size limited to the alphabet and we could index based on the numeric value of the char
    public void Insert(string word)
    {
        TrieNode currentNode = root;

        foreach (char c in word)
        {
            if (!currentNode.children.ContainsKey(c))
            {
                currentNode.children.Add(c, new TrieNode());
            }
            currentNode = currentNode.children[c];
        }

        currentNode.wordEnd = true;
    }

    // where n is the number of chars in the word
    // Search is O(n) where the word or a prefix with the same characters as the word is in the trie
    // Search is O(1) space because we use no extra data structures
    public bool Search(string word)
    {
        TrieNode currentNode = root;

        foreach (char c in word)
        {
            if (!currentNode.children.ContainsKey(c))
            {
                return false; 
            }
            currentNode = currentNode.children[c];
        }

        return currentNode.wordEnd; // if our word has been added to the tree, this should be true. Otherwise we have found a prefix to another word.
    }

    // where n is the number of chars in the word
    // StartsWith is O(n) where the word or a prefix with the same characters as the word is in the trie
    // StartsWith is O(1) space because we use no extra data structures
    public bool StartsWith(string prefix)
    {
        TrieNode currentNode = root;

        foreach (char c in prefix)
        {
            if (!currentNode.children.ContainsKey(c))
            {
                return false;
            }
            currentNode = currentNode.children[c];
        }

        return true;
    }

    // where n is the number of chars in the word
    // HasPrefixes is O(n) where the all the prefixes of a word are in the trie
    // HasPrefixes is O(1) space because we use no extra data structures
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

public class TrieNode
{
    public Dictionary<char, TrieNode> children;
    public bool wordEnd;

    public TrieNode()
    {
        children = new Dictionary<char, TrieNode>();
    }
}
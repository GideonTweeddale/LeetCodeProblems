namespace LeetCodeProblems.Trie;

public class WordDictionary {
    // we can solve this using a trie
    // I like to implement trie's as a cascading set of maps

    // the difference from a classic trie, is that once we have a wildcard, we'll have to bruteforce search for any children that match
    Trie trie;

    public WordDictionary() {
        trie = new();
    }
    
    public void AddWord(string word) {
        Trie node = trie;

        foreach (char c in word)
        {
            if (!node.children.ContainsKey(c))
            {
                node.children[c] = new Trie();
            }

            node = node.children[c];
        }

        node.children['~'] = new Trie();
    }
    
    public bool Search(string word) {
        return Search(word, trie);
    }

    private bool Search(string chars, Trie node)
    {
        for (int i = 0; i < chars.Length; i++)
        {
            char c = chars[i];

            if (c == '.')
            {
                foreach(Trie letter in node.children.Values)
                {
                    if (Search(chars[(i+1)..], letter))
                    {
                        return true;
                    }
                }
            }

            if (!node.children.ContainsKey(c))
            {
                return false;
            }

            node = node.children[c];
        }

        return node.children.ContainsKey('~');
    }

    class Trie {
        public Dictionary<char, Trie> children = new();
    }
}
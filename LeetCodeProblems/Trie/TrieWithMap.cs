namespace LeetCodeProblems.Trie;

public class TrieMap
{
    private Dictionary<char, TrieMap> trieMap;
    
    public TrieMap()
    {
        trieMap = [];
    }

    public void Insert(string word) 
    {
        Dictionary<char, TrieMap> trieNode = trieMap;

        foreach (char c in word)
        {
            if (!trieNode.ContainsKey(c))
            {
                trieNode[c] = new TrieMap();
            }
            
            trieNode = trieNode[c].trieMap;
        }

        trieNode['.'] = new TrieMap();
    }

    public bool Search(string word) 
    {
        Dictionary<char, TrieMap> trieNode = trieMap;

        foreach (char c in word)
        {
            if (!trieNode.ContainsKey(c))
            {
                return false;
            }

            trieNode = trieNode[c].trieMap;
        }

        return trieNode.ContainsKey('.');
    }

    public bool StartsWith(string prefix) 
    {
        Dictionary<char, TrieMap> trieNode = trieMap;

        foreach (char c in prefix)
        {
            if (!trieNode.ContainsKey(c))
            {
                return false;
            }

            trieNode = trieNode[c].trieMap;
        }

        return true;
    }
}
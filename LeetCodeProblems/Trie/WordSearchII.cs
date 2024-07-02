namespace LeetCodeProblems.Trie;

public class WordSearchII
{
    // to solve this problem, we create a trie using the words 
    // and a map of the words with a boolean value for if they've been found

    // then we iterate over the board and for each row and column and search the trie for them

    public IList<string> FindWords(char[][] board, string[] words) {
        Trie root = new();

        foreach (string word in words)
        {
            AddWord(root, word);
        }

        int rows = board.Length;
        int columns = board[0].Length;
        
        HashSet<string> wordsFound = new();

        for (int row = 0; row < rows; row++)
        {
            for (int column = 0; column < columns; column++)
            {
                DFS(row, column, root, "");
            }
        }

        return wordsFound.ToList();

        // helper functions
        void DFS(int row, int column, Trie node, string word)
        {
            if(row < 0 || column < 0 || row == rows || column == columns)
            {
                return;
            }

            char c = board[row][column];

            if (c == '/' || !node.children.ContainsKey(c))
            {
                return;
            }

            Trie parentNode = node;
            node = node.children[board[row][column]];
            word += board[row][column];

            if (node.children.ContainsKey('.'))
            {
                wordsFound.Add(word);

                if (node.children.Count == 1)
                {
                    parentNode.children.Remove(c);
                }
                else 
                {
                    node.children.Remove('.');
                }
            }

            board[row][column] = '/';

            DFS(row + 1, column, node, word); // up
            DFS(row - 1, column, node, word); // down
            DFS(row, column + 1, node, word); // right
            DFS(row, column - 1, node, word); // left

            board[row][column] = c;
        }
    }

    private static void AddWord(Trie node, string word)
    {
        foreach (char c in word)
        {
            if (!node.children.ContainsKey(c))
            {
                node.children[c] = new Trie();
            }

            node = node.children[c];
        }

        node.children['.'] = new Trie();
    }

    class Trie {
        public Dictionary<char, Trie> children = new();
    }
}
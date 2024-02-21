namespace LeetCodeProblems.Backtracking;
public class WordSearch
{
    public bool Exist(char[][] board, string word)
    {
        // if we find the first character of our word, check each non-diagonally adjacent character for the next character of the word,
        // do the same recursively if we find the next character or backtrack if we don't, until we reach the end of the search space
        // or we find a match in the grid

        // this is not very efficient - in the worst case around O(N^2) time and space

        for (int row  = 0; row < board.Length; row++)
        {
            for (int col = 0; col < board[row].Length; col++)
            {
                char c = board[row][col];

                if (c == word[0]) // begin our backtracking search
                {
                    if (MatchWord(board, word, row, col, 0))
                        return true;
                }
            }
        }

        return false;
    }

    private bool MatchWord(char[][] board, string word, int row, int col, int wordIndex)
    {
        if (wordIndex == word.Length) // we've found the whole word
            return true;

        // check that this is a valid index to seach and then if the char matches
        if (row < 0 || row >= board.Length || col < 0 || col >= board[0].Length || board[row][col] != word[wordIndex])
            return false;

        // save the char
        char c = board[row][col];

        // temporarily override it so that we don't match it twice
        board[row][col] = '~';

        // search each of the four possible adjacent squares recursively
        bool result = MatchWord(board, word,row + 1, col, wordIndex + 1) || MatchWord(board, word,row - 1, col, wordIndex + 1)
                   || MatchWord(board, word,row, col + 1, wordIndex + 1) || MatchWord(board, word,row, col - 1, wordIndex + 1);

        // put the char back
        board[row][col] = c;

        // return the result
        return result;
    }
}

namespace LeetCodeProblems.Graph.Matrix;

public static class SurroundedRegions
{
    // we need to build a set of graphs and then do a union find on it
    // if none of the nodes in a graph is adjacent to the edge of the board, we capture it
    // another way to think of this is to to track if any of the nodes we add to a graph is adjacent to the edge

    // so we can iterate over all of the outer cells and dfs from any O's 
    // to do this inplace without using extra memory, we can mark the cells as S for safe
    // this will be an O(m + n) time operation

    // then we can iterate through our board in O(m * n) time 
    // and change the O's to X's and the S's back to O's

    // this means that we have a simplified overall time complexity of O(m * n)

    public static void Solve(char[][] board) {
        int rows = board.Length;
        int columns = board[0].Length;

        for (int row = 0; row < rows; row++)
        {
            DFS(row, 0); // leftmost column
            DFS(row, columns - 1); // rightmost column
        }

        for (int column = 0; column < columns; column++)
        {
            DFS(0, column); // top row
            DFS(rows - 1, column); // bottom row
        }

        for (int row = 0; row < rows; row++)
        {
            for (int column = 0; column < columns; column++)
            {
                if (board[row][column] == 'O')
                {
                    board[row][column] = 'X';
                }

                else if (board[row][column] == 'S')
                {
                    board[row][column] = 'O';
                }
            }
        }

        // helper function to DFS from the outer cells
        void DFS(int row, int column)
        {
            if(row < 0 || column < 0 || row == rows || column == columns || board[row][column] != 'O')
            {
                return;
            }

            board[row][column] = 'S';

            DFS(row - 1, column); // top
            DFS(row, column + 1); // right
            DFS(row + 1, column); // bottom
            DFS(row, column - 1); // left
        }
    }
}
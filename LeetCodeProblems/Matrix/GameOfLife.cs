namespace LeetCodeProblems.Matrix;
public class GameOfLife289
{    
    // intuition
    // where n = columns * rows
    // we could solve this in roughly O(8n) time if we checked each of the eight neighbours for each cell
    // this simplifies to O(n)

    // we can't do row by row, left to right, using the first row and column to store the live or dead, because each cell interacts with all adjecent cells
    // and we aren't setting the entire row or column

    // the only way I can see to do this in O(n) time in place/without additional memory, is to use two passes and additional values
    // so, if a live cell 1 should be dead 0, we set it to 3, and if a dead cell 0, should be live, we set it to two
    // then when we check adjacent cells, we can treat 1 and 3 as live and 0 and 2 as dead
    // but once we have iterated over the entire grid, we have effectively imbedded the instructions for our next iteration
    // which will roll through and set all the 2s to 0s and 3s to 1s

    // this will have a time complexity of roughly O(8n + n) or just O(n) and a space complexity of O(1)

    // legend
    // 0 = dead
    // 1 = live
    // 2 = dead/pregnant
    // 3 = live/dying

    // private enum CellState 
    // {
    //     dead = 0,
    //     live = 1,
    //     pregnant = 2,
    //     dying = 3,
    // }

    public static void GameOfLife(int[][] board) {
        if (board == null || board.Length < 1 || board[0].Length < 1)
        {
            return;
        }

        int rows = board.Length;
        int columns = board[0].Length;

        // find the pregnant and the dying
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < columns; c++)
            {
                int living = 0;
                living += Alive(r-1, c-1); // top left
                living += Alive(r-1, c); // top middle
                living += Alive(r-1, c+1); // top right
                living += Alive(r, c-1); // middle left
                living += Alive(r, c+1); // middle right
                living += Alive(r+1, c-1); // bottom left
                living += Alive(r+1, c); // bottom middle
                living += Alive(r+1, c+1); // bottom right

                int value = board[r][c];

                // if dead with three living neighbours make baby
                if (value == 0 && living == 3)
                {
                    board[r][c] = 2; // pregnant
                }

                // if alive and under or over populated then unalive
                else if (value == 1 && (living < 2 || 3 < living))
                {
                    board[r][c] = 3; // dying
                }
            }
        }

        // update the board with the newly alive or dead
        for (int r = 0; r < board.Length; r++)
        {
            for (int c = 0; c < board[0].Length; c++)
            {
                if(board[r][c] == 2)
                {
                    board[r][c] = 1; // alive!
                }

                else if(board[r][c] == 3)
                {
                    board[r][c] = 0; // dead
                }                
            }
        }

        // helper functions
        // alive
        int Alive(int row, int column)
        {
            if (row < 0 || row >= rows)
            {
                return 0;
            }

            if (column < 0 || column >= columns)
            {
                return 0;
            }

            int value = board[row][column];

            if (value == 1 || value == 3)
            {
                return 1;
            }

            return 0;
        }
    }

    // the problem with approaching the edge of a theoretically infinite array is that we don't know the values that should exist beyond the array
    // this means that we may be setting our values incorrectly
    // we could assume that all cells beyond the edge of the array are dead or alive depending on other requirements
    // and we could choose to extend the array to fill those values based on our current values
    // the only thing we cannot do, is know what the values are
    // which could be important if we are modelling a real system where those values actually matter
    // at which stage, we might need to go and gather more information
}

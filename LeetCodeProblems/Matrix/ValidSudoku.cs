namespace LeetCodeProblems.Matrix;
public class ValidSudoku
{
    // intuition

    // m = 9 and n = 9 so mn = 81
    // we know the size of the input, which will always be the same
    // so all our solutions are actually constant time 
    // and we can actaully work out exactly how many iterations they would need

    // we could create three hashsets, one for each of row, column, and 3x3 grid
    // then iterate through the entire matrix adding each cell to all three hashsets
    // using the value and the row or column or 3x3 grid index as the key
    // if we come across any duplciates, return false becuase the sudoku is invalid
    // otherwise return true

    // that would complete in O(mn) time where m is the number of rows and n is the number of columns
    // and in O(3mn) space because we would store each filled cell value in our dictionaries 
    
    // we could do a O(3mn^2) solution by iterating through the cells and for each iterating through the row, column, and local grid

    // we could solve this with one hashset of size 9 and three passes
    // on the first pass, we iterate through all of the rows adding the values to the hashset
    // if we find no duplicates, the row is valid
    // we reset our hashset and do the next row, until the end
    // then we do the same thing column by column
    // and then again grid by grid
    // if at any point we find an inconsistent value, we return early
    // this solution requires more iterations but much less memory than the first solution
    public bool IsValidSudoku(char[][] board) {
        HashSet<(int, int)> rows = new(); // row, val
        HashSet<(int, int)> columns = new(); // col, val
        HashSet<(int, int, int)> grids = new(); // row / 3, col / 3, val
        
        for (int r = 0; r < 9; r++)
        {
            for (int c = 0; c < 9; c++)
            {
                int v = board[r][c];
                if(v == '.') continue;
                if (rows.Contains((r, v)) || columns.Contains((c, v)) || grids.Contains((r / 3, c / 3, v))) return false; // duplicate found

                rows.Add((r, v));
                columns.Add((c, v));
                grids.Add((r / 3, c / 3, v));
            }
        }

        return true;
    }
}

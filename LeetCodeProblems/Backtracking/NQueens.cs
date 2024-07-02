using System.Runtime.InteropServices;
using System.Text;

namespace LeetCodeProblems.Backtracking;
public class NQueens
{
    // intuition
    // because we need to return all the combinations, I'm pretty sure that there is no way to cheat this
    // and we will need to do backtracking on it
    // ignoring the fact that there are only nine possible inputs, of course

    // in order to do an exhaustive search with backtracking
    // we can iterate over all possible inputs for the next row for each input of the current row, all the way until we reach n rows
    // this means that the time complexity will be n * n or O(n^2)

    // to decide if a given cell is a valid place to put a queen, we need to keep track of the rows, columns, and diagonals that already have queens
    // the row will be implicit because we will be backtracking row by row
    // and we can track the column in a set
    // for the diagonals we will need a pair of sets
    // the trick here is that the diagonals will always be going down because we are going row by row
    // and diagonals that go down and to the right will always return the same value when we subtract one index from the other
    // because we are always incrementing both indexes by 1
    // and the diagonals that go down and to the left will always sum to the same value
    // because we are always incrementing one index and decrementing the other by 1
    
    public static IList<IList<string>> SolveNQueens(int n) {
        HashSet<int> columns = new();
        HashSet<int> sumDiagonal = new();
        HashSet<int> differenceDiagonal = new();

        IList<IList<string>> output = [];

        List<StringBuilder> board = new();

        for (int i = 0; i < n; i++)
        {
            board.Add(new());
            board[i].Append('.', n);
        }

        Backtrack(0);

        return output;

        // backtrack function
        void Backtrack(int row)
        {
            // if we reach the nth row, this is a valid config
            if (row == n)
            {
                output.Add(board.Select(x => x.ToString()).ToList());
                return;
            }

            for (int column = 0; column < n; column++)
            {
                if (columns.Contains(column) || sumDiagonal.Contains(row + column) || differenceDiagonal.Contains(row - column))
                {
                    continue;
                }

                columns.Add(column);
                sumDiagonal.Add(row + column);
                differenceDiagonal.Add(row - column);
                board[row][column] = 'Q';

                Backtrack(row + 1);
                
                board[row][column] = '.';
                differenceDiagonal.Remove(row - column);
                sumDiagonal.Remove(row + column);
                columns.Remove(column);
            }
        }
    }
}

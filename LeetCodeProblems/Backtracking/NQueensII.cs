namespace LeetCodeProblems.Backtracking;
public class NQueensII
{
    // intuition
    // we need to generate the entire board for each possible starting position
    // the starting positions need to be as far away from each other as possible
    // because the gaps between the diagonal and direct atacks from a queen grow larger the further away you get
    // this means that only the outer rows can be optimal starting positions
    // and because the grid is n x n it is effectively reversible in any direction
    // so we can pick a single outer row or column and we will get a valid solution

    // we don't actually need to return the solutions themselves, just the count of distinct solutions

    // each queen excludes and entire row
    // and an entire column
    // and two diagonals
    // so we cannot place more than n queens ever
    // and the number of queens we can place increases slower than the problem space

    // we can always place a queen at a two-one offset from the current queen, without obstructing it (including wrapping around)
    
    // we can know if a placement is currently valid, if our row, column, and diagonal aren't arleady filled

    // the number of possible solutions is linked to the number of possible rotations somehow

    // 7x7 chessoard 
    // [ ][ ][ ][ ][ ][ ][Q]
    // [ ][Q][ ][ ][ ][ ][ ]
    // [ ][ ][ ][Q][ ][ ][ ]
    // [ ][ ][ ][ ][ ][Q][ ]
    // [Q][ ][ ][ ][ ][ ][ ]
    // [ ][ ][Q][ ][ ][ ][ ]
    // [ ][ ][ ][ ][Q][ ][ ]

    // [Q][ ][ ][ ]
    // [ ][ ][Q][ ]
    // [ ][Q][ ][ ]
    // [ ][ ][ ][Q]

    // for n = 2..3 there are no solutions
    // [Q][ ][ ]
    // [ ][ ][Q]
    // [ ][ ][ ]

    // for n = 1 there is obviously only 1 solution

    // for n = 4 there are 2 solutions

    // for n >= 5 there are at least n solutions becuase we must place one queen on each row 
    // and it is possible to start on any index in the row and get a valid answer
    // the question is: is it possible to get more than one answer from a given index in the first row
    // yes it is. Damn. This is definitely a backtracking problem
    // [Q][ ][ ][ ][ ]
    // [ ][ ][ ][Q][ ]
    // [ ][Q][ ][ ][ ]
    // [ ][ ][ ][ ][Q]
    // [ ][ ][Q][ ][ ]

    // if the answer had been no, this could have been the solution
    // public int TotalNQueens(int n) {
    //     if (n == 2 || n == 3) return 0;
    //     if (n == 4) return 2;
    //     return n;
    // }

    // the backtracking solution will be O(n^2) where n is n
    // and the space complexity will be O(n)

    // let's try the backtracking solution
    public int TotalNQueens(int n) {
        if (n == 1) return 1;
        if (n == 2 || n == 3) return 0;
        if (n == 4) return 2;

        HashSet<int> columns = new();
        HashSet<int> positiveDiagonal = new();
        HashSet<int> negativeDiagonal = new();

        int result = 0;

        Backtrack(0);

        return result;

        // backtrack function
        void Backtrack(int row)
        {
            if (row == n)
            {
                result++;
                return;
            }

            for (int column = 0; column < n; column++)
            {
                if (columns.Contains(column) || positiveDiagonal.Contains(row + column) || negativeDiagonal.Contains(row - column))
                {
                    continue;
                }

                columns.Add(column);
                positiveDiagonal.Add(row + column);
                negativeDiagonal.Add(row - column);
                Backtrack(row + 1);
                columns.Remove(column);
                positiveDiagonal.Remove(row + column);
                negativeDiagonal.Remove(row - column);
            }
        }
    }
    
    // 1=1, 2,3=0, 4=2, 5=10, 6=4, 7=40, 8=92,9=352
    // hardcoded solution    
    public int TotalNQueensHardCoded(int n) 
    {
        switch(n)
        {
            case 1:
                return 1;
            default: // 2 and 3
                return 0;
            case 4:
                return 2;
            case 5:
                return 10;
            case 6:
                return 4;
            case 7:
                return 40;
            case 8:
                return 92;
            case 9:
                return 352;
        }
    }
    
    static int[] arr = new int[10]
    {
        0,
        1,
        0,
        0,
        2,
        10,
        4,
        40,
        92,
        352,
    };
    public int TotalNQueensHardCodedTwo(int n)
    {
        return arr[n];
    }
}

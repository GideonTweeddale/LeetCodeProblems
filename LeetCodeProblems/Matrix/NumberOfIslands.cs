namespace LeetCodeProblems.Matrix;
public class NumberOfIslands
{
    // intuition
    // if we depth first search from every position until we reach a cell that is surroundedby water or by cells we've already visited
    // we will find all the cells in the island, if any, that the current cell is part of
    // if we record which cells we've visited and skip the depth first search for those cells, it should be relatively efficient
    // we will also skip dfs on any cells that are water

    public static int NumIslands(char[][] grid)
    {
        int rows = grid.Length;
        int cols = grid[0].Length;
        int islands = 0;

        HashSet<(int,int)> visited = [];

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                // for every land cell, that isn't part of an existing island
                if (grid[row][col] == '1' && !visited.Contains((row,col)))
                {
                    // mark all the cells that this cell is part of
                    FindIsland(row, col);
                    // increment the number of islands
                    islands++;
                }
            }
        }

        return islands;

        void FindIsland(int row, int col)
        {
            // if we have already seen this cell or it is out of bounds/water
            if (visited.Contains((row,col)) || row < 0 || col < 0 || row == rows || col == cols || grid[row][col] == '0')
            {
                return;
            }

            // mark this cell as visited so that we don't double count islands
            visited.Add((row,col));

            FindIsland(row + 1, col);
            FindIsland(row - 1, col);
            FindIsland(row, col + 1);
            FindIsland(row, col - 1);
        }
    }
}
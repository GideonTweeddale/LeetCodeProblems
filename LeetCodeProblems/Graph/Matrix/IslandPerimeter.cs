namespace LeetCodeProblems.Graph.Matrix;

public static class IslandPerimeter463
{    
    // we can solve this by doing a depth or breadth first search of each cell skipping any that we've search already
    // in practice we will only DFS once because there is exactly one island
    // and we only DFS if we find a land cell
    // this means that we'll visit each land cell once and complete in O(n) time in the worst case where all cells are land
    // storing the cells we've visited will take O(n) space

    // each cell has a perimeter value of 0-4 depending on how many adjacent cells are water, out of bounds, or land

    public static int IslandPerimeter(int[][] grid) {
        int rows = grid.Length;
        int columns = grid[0].Length;

        HashSet<(int, int)> visited = [];

        for (int row = 0; row < rows; row++) 
        {
            for (int column = 0; column < columns; column++) 
            {
                if (grid[row][column] == 1) // 1 is land
                {
                    return DFS(row, column); // we can return here because the question guarantees that there will only be one island
                }
            }
        }  

        return -1; // this should never happen and in real code we should handle this with something like an exception

        // dfs helper
        int DFS(int row, int column)
        {
            if (row < 0 || column < 0 || row == rows || column == columns || grid[row][column] == 0)
            {
                return 1; // we have found water or gone out of bounds
            }

            if (visited.Contains((row, column)))
            {
                return 0; 
            }

            visited.Add((row, column));

            return DFS(row - 1, column) // top
                 + DFS(row, column + 1) // right
                 + DFS(row + 1, column) // bottom
                 + DFS(row, column - 1); // left
        }     
    }
}
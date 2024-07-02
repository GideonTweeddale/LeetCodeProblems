namespace LeetCodeProblems.Matrix;
public class PacificAtlanticWaterFlow
{
    // intuition
    // this is a dfs dp problem
    // each cell can flow into the pacific and atlantic ocean if 
    // any of the neighbouring cells are lower than it and can also flow into the ocean or it borders the ocean itself
    // so for each cell, we do a depth first seach of all it's neighbours - saving the answer when we find it

    public IList<IList<int>> PacificAtlantic(int[][] heights)
    {
        int rows = heights.Length;
        int cols = heights[0].Length;

        HashSet<(int, int)> pacific = new();
        HashSet<(int, int)> atlantic = new();

        // fill the coasts
        for (int col = 0; col < cols; col++)
        {
            DFS(0, col, pacific, heights[0][col]);
            DFS(rows - 1, col, atlantic, heights[rows - 1][col]);
        }

        for (int row = 0; row < rows; row++)
        {
            DFS(row, 0, pacific, heights[row][0]);
            DFS(row, cols - 1, atlantic, heights[row][cols - 1]);
        }

        List<IList<int>> result = [];

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                if (pacific.Contains((row, col)) && atlantic.Contains((row, col)))
                {
                    result.Add([row, col]);
                }
            }
        }

        return result;
        
        void DFS(int row, int col, HashSet<(int, int)> visited, int prevHeight)
        {
            if (visited.Contains((row, col)) || row < 0 || col < 0 || row == rows || col == cols || heights[row][col] < prevHeight)
            {
                return;
            }

            visited.Add((row, col));

            DFS(row + 1, col, visited, heights[row][col]);
            DFS(row - 1, col, visited, heights[row][col]);
            DFS(row, col + 1, visited, heights[row][col]);
            DFS(row, col - 1, visited, heights[row][col]);
        }   
    }           
}
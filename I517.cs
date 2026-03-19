public class Solution {
    public int NumberOfSubmatrices(char[][] grid)
    {
        var total = 0;

        var gridX = new int[grid.Length, grid[0].Length];
        var gridY = new int[grid.Length, grid[0].Length];
        
        for (int row = 0; row < grid.Length; row++)
        {
            var colXCount = 0;
            var colYCount = 0;
            for (int col = 0; col < grid[0].Length; col++)
            {
                if (grid[row][col] == 'X')
                {
                    colXCount++;
                }else if (grid[row][col] == 'Y')
                {
                    colYCount++;
                }

                if (row - 1 >= 0)
                {
                    gridX[row, col] = gridX[row - 1, col] + colXCount;
                    gridY[row, col] = gridY[row - 1, col] + colYCount;
                }
                else
                {
                    gridX[row, col] = colXCount;
                    gridY[row, col] = colYCount;
                }

                if (gridX[row, col] == gridY[row, col] && gridX[row, col] != 0)
                {
                    total++;
                }
            }
        }

        return total;
    }
}

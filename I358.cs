public class Solution{
    public int CountUnguarded(int m, int n, int[][] guards, int[][] walls){
        int[,] grid = new int[m, n];

        for (int i = 0; i < walls.Length; i++)
            grid[walls[i][0], walls[i][1]] = 1;
        
        for (int i = 0; i < guards.Length; i++)
            grid[guards[i][0], guards[i][1]] = 1;
        
        for (int i = 0; i < guards.Length; i++)
        {
            int row = guards[i][0];
            int col = guards[i][1];

            for (int j = row - 1; j >= 0; j--)
            {
                if (grid[j, col] == 1)
                    break;
                grid[j, col] = -1;
            }

            for (int j = row + 1; j < m; j++)
            {
                if (grid[j, col] == 1)
                    break;
                grid[j, col] = -1;
            }

            for (int j = col - 1; j >= 0; j--)
            {
                if (grid[row, j] == 1)
                    break;
                grid[row, j] = -1;
            }

            for (int j = col + 1; j < n; j++)
            {
                if (grid[row, j] == 1)
                    break;
                grid[row, j] = -1;
            }
        }

        int unguarded = 0;
        for (int i = 0; i < m; i++)
            for (int j = 0; j < n; j++)
                if (grid[i, j] == 0)
                    unguarded++;
            
        return unguarded;
    }
}

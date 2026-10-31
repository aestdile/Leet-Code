public class Solution {
    private int mod = (int)Math.Pow(10, 9)+7;
    private int[,,] dp;
    private int m, n;
    private int BackTracking(int[][] grid, int i, int j, int dir)
    {
        if(i == m-1 && j == n-1)
            return 1;

        if(i >= m || j >= n)
            return 0;

        if(dp[i,j,dir] != -1)
            return dp[i,j,dir];

        long steps = 0;

        int val = grid[i][j];

        if(val == 1)
        {
            if(dir == 0) // right : 0, down : 1
                steps += BackTracking(grid, i+1, j, 1);
            else
                steps += BackTracking(grid, i, j+1, 0);
        }
        else
        {
            steps += BackTracking(grid, i+1, j, 1);
            steps += BackTracking(grid, i, j+1, 0);
        }

        steps %= mod;
        dp[i,j,dir] = (int)steps;
        return dp[i,j,dir];
    }
    public int UniquePaths(int[][] grid) {
        m = grid.Length;
        n = grid[0].Length;

        // Declare and define dp:
        dp = new int[m,n,2];
        for(int i = 0; i < m; i++)
        {
            for(int j = 0; j < n; j++)
            {
                for(int d = 0; d < 2; d++)
                {
                    dp[i,j,d] = -1;
                }
            }
        }

        return BackTracking(grid, 0, 0, 0);
    }
}

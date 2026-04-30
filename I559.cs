public class Solution {

    public int MaxPathScore(int[][] grid, int k) {
        int m = grid.Length;
        int n = grid[0].Length;

        int[,,] dp = new int[m, n, k + 1];

        for (int i = 0; i < m; i++)
            for (int j = 0; j < n; j++)
                for (int c = 0; c <= k; c++)
                    dp[i, j, c] = -1;

        dp[0, 0, grid[0][0] == 2 ? 1 : 0] = grid[0][0];

        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {

                if (i == 0 && j == 0) continue;

                for (int c = 0; c <= k; c++) {

                    int val = grid[i][j];
                    int addCost = (val == 0) ? 0 : 1;
                    int addScore = val;

                    int best = -1;

                    if (i > 0 && c - addCost >= 0)
                        best = Math.Max(best, dp[i - 1, j, c - addCost]);

                    if (j > 0 && c - addCost >= 0)
                        best = Math.Max(best, dp[i, j - 1, c - addCost]);

                    if (best != -1)
                        dp[i, j, c] = best + addScore;
                }
            }
        }

        int res = -1;
        for (int c = 0; c <= k; c++)
            res = Math.Max(res, dp[m - 1, n - 1, c]);

        return res;
    }
}

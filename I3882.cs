public class Solution {
    public int MinCost(int[][] grid) {
        int m = grid.Length;
        int n = grid[0].Length;

        bool[][] dp = new bool[n][];
        for (int j = 0; j < n; j++) {
            dp[j] = new bool[1024];
        }
        bool[] next = new bool[1024];

        dp[0][grid[0][0]] = true;

        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (i == 0 && j == 0) {
                    continue;
                }

                int value = grid[i][j];
                Array.Clear(next, 0, next.Length);

                for (int k = 0; k < 1024; k++) {
                    if (dp[j][k] || (j > 0 && dp[j - 1][k])) {
                        next[k ^ value] = true;
                    }
                }

                Array.Copy(next, dp[j], 1024);
            }
        }

        return Array.IndexOf(dp[n - 1], true);
    }
}

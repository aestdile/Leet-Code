public class Solution {
    public int NumberOfPaths(int[][] g, int k) {
        const int MOD = 1_000_000_007;
        int m = g.Length, n = g[0].Length;
        var dp = new int[n][];
        var ndp = new int[n][];
        for (int i = 0; i < n; i++) {
            dp[i] = new int[k];
            ndp[i] = new int[k];
        }

        int s = 0;
        for (int j = 0; j < n; j++) {
            s = (s + g[0][j]) % k;
            dp[j][s] = 1;
        }

        s = g[0][0] % k;

        for (int i = 1; i < m; i++) {
            s = (s + g[i][0]) % k;
            Array.Clear(ndp[0], 0, k);
            ndp[0][s] = 1;

            for (int j = 1; j < n; j++) {
                Array.Clear(ndp[j], 0, k);
                int v = g[i][j];
                for (int r = 0; r < k; r++) {
                    int nr = (r + v) % k;
                    ndp[j][nr] = (dp[j][r] + ndp[j - 1][r]) % MOD;
                }
            }
            var tmp = dp; dp = ndp; ndp = tmp;
        }
        return dp[n - 1][0];
    }
}
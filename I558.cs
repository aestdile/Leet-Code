public class Solution {
    public long MaximumScore(int[][] grid) {
        int n = grid[0].Length;
        if (n == 1) {
            return 0;
        }

        long[,,] dp = new long[n, n + 1, n + 1];
        long[,] prevMax = new long[n + 1, n + 1];
        long[,] prevSuffixMax = new long[n + 1, n + 1];
        long[,] colSum = new long[n, n + 1];

        for (int c = 0; c < n; c++) {
            for (int r = 1; r <= n; r++) {
                colSum[c, r] = colSum[c, r - 1] + grid[r - 1][c];
            }
        }

        for (int i = 1; i < n; i++) {
            for (int currH = 0; currH <= n; currH++) {
                for (int prevH = 0; prevH <= n; prevH++) {
                    if (currH <= prevH) {
                        long extraScore = colSum[i, prevH] - colSum[i, currH];
                        dp[i, currH, prevH] =
                            Math.Max(dp[i, currH, prevH],
                                     prevSuffixMax[prevH, 0] + extraScore);
                    } else {
                        long extraScore =
                            colSum[i - 1, currH] - colSum[i - 1, prevH];
                        dp[i, currH, prevH] = Math.Max(
                            dp[i, currH, prevH],
                            Math.Max(prevSuffixMax[prevH, currH],
                                     prevMax[prevH, currH] + extraScore));
                    }
                }
            }

            for (int currH = 0; currH <= n; currH++) {
                prevMax[currH, 0] = dp[i, currH, 0];
                for (int prevH = 1; prevH <= n; prevH++) {
                    long penalty = (prevH > currH)
                                       ? (colSum[i, prevH] - colSum[i, currH])
                                       : 0;
                    prevMax[currH, prevH] =
                        Math.Max(prevMax[currH, prevH - 1],
                                 dp[i, currH, prevH] - penalty);
                }

                prevSuffixMax[currH, n] = dp[i, currH, n];
                for (int prevH = n - 1; prevH >= 0; prevH--) {
                    prevSuffixMax[currH, prevH] = Math.Max(
                        prevSuffixMax[currH, prevH + 1], dp[i, currH, prevH]);
                }
            }
        }

        long ans = 0;
        for (int k = 0; k <= n; k++) {
            ans = Math.Max(ans, Math.Max(dp[n - 1, n, k], dp[n - 1, 0, k]));
        }

        return ans;
    }
}

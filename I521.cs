public class Solution {
    public int MaxProductPath(int[][] grid) {
                    var row = grid.Length;
            var col = grid[0].Length;
            var dp = new (long max, long min)[row, col];

            for (var r = 0; r < row; r++)
            {
                for (var c = 0; c < col; c++)
                {
                    var target = grid[r][c];

                    if (r == 0 && c == 0)
                    {
                        dp[r, c].min = target;
                        dp[r, c].max = target;
                        continue;
                    }

                    var min = long.MaxValue;
                    var max = long.MinValue;

                    if (r > 0)
                    {
                        min = Math.Min(min, Math.Min(dp[r - 1, c].min * target, dp[r - 1, c].max * target));
                        max = Math.Max(max, Math.Max(dp[r - 1, c].min * target, dp[r - 1, c].max * target));
                    }

                    if (c > 0)
                    {
                        min = Math.Min(min, Math.Min(dp[r, c - 1].min * target, dp[r, c - 1].max * target));
                        max = Math.Max(max, Math.Max(dp[r, c - 1].min * target, dp[r, c - 1].max * target));
                    }

                    dp[r, c].min = min;
                    dp[r, c].max = max;
                }
            }

            return dp[row - 1, col - 1].max < 0 ? -1 : (int)(dp[row - 1, col - 1].max % 1000000007);
    }
}

public class Solution {
    public int MaxCollectedFruits(int[][] fruits) {
        int n = fruits.Length;
        int ans = 0;
        for (int i = 0; i < n; ++i) ans += fruits[i][i];

        int dp()
        {
            int[] prev = Enumerable.Repeat(int.MinValue, n).ToArray();
            int[] curr = new int[n];
            prev[n - 1] = fruits[0][n - 1];
            for (int i = 1; i < n - 1; ++i)
            {
                Array.Fill(curr, int.MinValue);
                for (int j = Math.Max(n - 1 - i, i + 1); j < n; ++j)
                {
                    int best = prev[j];
                    if (j - 1 >= 0)
                    {
                        best = Math.Max(best, prev[j - 1]);
                    }
                    if (j + 1 < n)
                    {
                        best = Math.Max(best, prev[j + 1]);
                    }
                    curr[j] = best + fruits[i][j];
                }
                var temp = prev;
                prev = curr;
                curr = temp;
            }
            return prev[n - 1];
        }

        ans += dp();

        for (int i = 0; i < n; ++i)
        {
            for (int j = 0; j < i; ++j)
            {
                var temp = fruits[j][i];
                fruits[j][i] = fruits[i][j];
                fruits[i][j] = temp;
            }
        }

        ans += dp();
        return ans;
    }
}

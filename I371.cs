public class Solution {
    private (int, int) Aux(string s) {
        int nb0 = 0, nb1 = 0;
        foreach (char c in s) {
            if (c == '0') nb0++;
            else nb1++;
        }
        return (nb0, nb1);
    }

    public int FindMaxForm(string[] strs, int m, int n) {
        int[,] dp = new int[m + 1, n + 1];

        foreach (string s in strs) {
            var (nb0, nb1) = Aux(s);
            for (int i = m; i >= nb0; i--) {
                for (int j = n; j >= nb1; j--) {
                    dp[i, j] = Math.Max(dp[i, j], dp[i - nb0, j - nb1] + 1);
                }
            }
        }

        return dp[m, n];
    }
}
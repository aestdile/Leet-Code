public class Solution {
    const int MOD = 1000000007;
    public int LengthAfterTransformations(string s, int t) {
        int[,] dp = new int[26, t + 1];
        for (int c = 0; c < 26; c++) {
            dp[c, 0] = 1;
        }
        for (int i = 1; i <= t; i++) {
            for (int c = 0; c < 26; c++) {
                if (c == 25) { // 'z'
                    dp[c, i] = (dp[0, i - 1] + dp[1, i - 1]) % MOD;
                } else {
                    dp[c, i] = dp[c + 1, i - 1]; 
                }
            }
        }
        long total = 0;
        foreach (char ch in s) {
            total = (total + dp[ch - 'a', t]) % MOD;
        }
        return (int)total;
    }
}

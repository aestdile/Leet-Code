public class Solution {
    public bool IsMatch(string s, string p) {
        var dp = new bool[s.Length + 1, p.Length + 1];
        dp[0, 0] = true;

        for (int j = 2; j <= p.Length; j++)
            if (p[j - 1] == '*')
                dp[0, j] = dp[0, j - 2];

        for (int i = 1; i <= s.Length; i++) {
            for (int j = 1; j <= p.Length; j++) {
                if (p[j - 1] == '.' || p[j - 1] == s[i - 1])
                    dp[i, j] = dp[i - 1, j - 1];
                else if (p[j - 1] == '*') {
                    dp[i, j] = dp[i, j - 2];
                    if (p[j - 2] == '.' || p[j - 2] == s[i - 1])
                        dp[i, j] |= dp[i - 1, j];
                }
            }
        }

        return dp[s.Length, p.Length];
    }
}

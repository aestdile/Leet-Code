public class Solution {
    private const int MOD = 1_000_000_007;
    public int[] ProductQueries(int n, int[][] queries) {
        List<int> powers = new List<int>();
        for (int bit = 0; bit < 31; bit++) {
            if ((n & (1 << bit)) != 0) {
                powers.Add(1 << bit);
            }
        }
        int m = powers.Count;
        long[] prefix = new long[m];
        prefix[0] = powers[0];
        for (int i = 1; i < m; i++) {
            prefix[i] = (prefix[i - 1] * powers[i]) % MOD;
        }
        int[] ans = new int[queries.Length];
        for (int i = 0; i < queries.Length; i++) {
            int l = queries[i][0];
            int r = queries[i][1];
            if (l == 0) {
                ans[i] = (int)prefix[r];
            } else {
                long numerator = prefix[r];
                long denominator = prefix[l - 1];
                long inv = ModPow(denominator, MOD - 2); 
                ans[i] = (int)((numerator * inv) % MOD);
            }
        }

        return ans;
    }
    private long ModPow(long baseValue, long exp) {
        long result = 1;
        baseValue %= MOD;
        while (exp > 0) {
            if ((exp & 1) == 1) {
                result = (result * baseValue) % MOD;
            }
            baseValue = (baseValue * baseValue) % MOD;
            exp >>= 1;
        }
        return result;
    }
}

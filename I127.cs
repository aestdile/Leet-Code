public class Solution {
    private const int MOD = 1000000007;
    private long[] factorial;
    private long[] invFactorial;
    private long PowMod(long a, long b) {
        long res = 1;
        while (b > 0) {
            if ((b & 1) == 1)
                res = res * a % MOD;
            a = a * a % MOD;
            b >>= 1;
        }
        return res;
    }
    private long C(int n, int k) {
        if (k > n || k < 0) return 0;
        return factorial[n] * invFactorial[k] % MOD * invFactorial[n - k] % MOD;
    }
    private void Precompute(int maxN) {
        factorial = new long[maxN + 1];
        invFactorial = new long[maxN + 1];
        factorial[0] = invFactorial[0] = 1;
        for (int i = 1; i <= maxN; i++) {
            factorial[i] = factorial[i - 1] * i % MOD;
            invFactorial[i] = PowMod(factorial[i], MOD - 2);
        }
    }
    public int CountGoodArrays(int n, int m, int k) {
        Precompute(n);
        long ans = C(n - 1, k) * m % MOD * PowMod(m - 1, n - 1 - k) % MOD;
        return (int)ans;
    }
}

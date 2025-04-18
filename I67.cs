public class Solution {
    const int MOD = 1337;
    public int SuperPow(int a, int[] b) {
        return Pow(a, b, b.Length);
    }
    private int Pow(int a, int[] b, int len) {
        if (len == 0) return 1;
        int last = b[len - 1];
        int part1 = ModPow(a, last);
        int part2 = ModPow(Pow(a, b, len - 1), 10);
        return (part1 * part2) % MOD;
    }
    private int ModPow(int a, int k) {
        int res = 1;
        a %= MOD;
        for (int i = 0; i < k; i++) {
            res = (res * a) % MOD;
        }
        return res;
    }
}

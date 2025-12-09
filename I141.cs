public class Solution {
    public int SpecialTriplets(int[] nums) {
        const int MOD = 1_000_000_007;
        const int MAXV = 100001;
        int[] memo = new int[MAXV];
        int[] duplets = new int[MAXV];

        int res = 0;
        foreach (int number in nums) {
            res = (res + duplets[number]) % MOD;
            int twon = number * 2;
            if (twon < MAXV) {
                duplets[twon] = (duplets[twon] + memo[twon]) % MOD;
            }
            memo[number]++;
        }
        return res;
    }
}

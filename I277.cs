public class Solution {
    public int PeopleAwareOfSecret(int n, int delay, int forget) {
        const int MOD = 1000000007;

        int[] f = new int[n + 1];
        f[1] = 1;
        long activeSharers = 0;

        for (int day = 2; day <= n; day++) {
            if (day - delay >= 1)
                activeSharers = (activeSharers + f[day - delay]) % MOD;

            if (day - forget >= 1)
                activeSharers = (activeSharers - f[day - forget] + MOD) % MOD;

            f[day] = (int)activeSharers;
        }

        long total = 0;
        for (int day = n - forget + 1; day <= n; day++) {
            if (day >= 1)
                total = (total + f[day]) % MOD;
        }

        return (int)total;
    }
}

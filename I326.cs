public class Solution {
      public int MagicalSum(int m, int k, int[] nums){
        int n = nums.Length;
        const long mod = 1000000007;

        long[] fac = new long[m + 1];
        fac[0] = 1;
        
        for (int i = 1; i <= m; i++){
            fac[i] = fac[i - 1] * i % mod;
        }

        long[] ifac = new long[m + 1];
        ifac[0] = 1;
        ifac[1] = 1;
        for (int i = 2; i <= m; i++){
            ifac[i] = QuickMul(i, mod - 2, mod);
        }

        for (int i = 2; i <= m; i++){
            ifac[i] = ifac[i - 1] * ifac[i] % mod;
        }

        long[][] numsPower = new long[n][];
        for (int i = 0; i < n; i++){
            numsPower[i] = new long[m + 1];
            numsPower[i][0] = 1;
            for (int j = 1; j <= m; j++){
                numsPower[i][j] = numsPower[i][j - 1] * nums[i] % mod;
            }
        }

        long[][][][] f = new long[n][][][];
        for (int i = 0; i < n; i++){
            f[i] = new long[m + 1][][];
            for (int j = 0; j <= m; j++){
                f[i][j] = new long[m * 2 + 1][];
                for (int p = 0; p <= m * 2; p++){
                    f[i][j][p] = new long[k + 1];
                }
            }
        }

        for (int j = 0; j <= m; j++){
            f[0][j][j][0] = numsPower[0][j] * ifac[j] % mod;
        }

        for (int i = 0; i + 1 < n; i++){
            for (int j = 0; j <= m; j++){
                for (int p = 0; p <= m * 2; p++){
                    for (int q = 0; q <= k; q++){
                        int q2 = (p % 2) + q;
                        if (q2 > k){
                            break;
                        }
                        for (int r = 0; r + j <= m; r++){
                            int p2 = p / 2 + r;
                            f[i + 1][j + r][p2][q2] += f[i][j][p][q] *
                                                        numsPower[i + 1][r] %
                                                        mod * ifac[r] % mod;
                            f[i + 1][j + r][p2][q2] %= mod;
                        }
                    }
                }
            }
        }

        long res = 0;
        for (int p = 0; p <= m * 2; p++){
            for (int q = 0; q <= k; q++){
                if (BitOperations.PopCount((uint)p) + q == k){
                    res = (res + f[n - 1][m][p][q] * fac[m] % mod) % mod;
                }
            }
        }
        return (int)res;
    }

    private long QuickMul(long x, long y, long mod){
        long res = 1, cur = x % mod;
        while (y > 0){
            if ((y & 1) == 1){
                res = res * cur % mod;
            }
            y >>= 1;
            cur = cur * cur % mod;
        }
        return res;
    }
}

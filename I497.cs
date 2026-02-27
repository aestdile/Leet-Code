public class Solution {
    public int MinOperations(string s, int k) {
        int n = s.Length, z = 0;
        
        for (int i = 0; i < n; i++) {
            z += s[i] ^ 49;
        }

        if (z == 0) return 0;
        if (n == k) return z == n ? 1 : -1;

        int b = n - k, k1 = (z + k - 1) / k, res = int.MaxValue;
        
        /* Case 1: x is Odd */
        if ((k & 1) == (z & 1)) {
            int t = (n - z + b - 1) / b;
            res = (k1 > t ? k1 : t) | 1;
        }

        /* Case 2: x is Even */
        if ((z & 1) == 0) {
            int t = (z + b - 1) / b;
            int e = k1 > t ? k1 : t;
            e += e & 1;
            if (e < res) res = e;
        }

        return res == int.MaxValue ? -1 : res;
    }
}

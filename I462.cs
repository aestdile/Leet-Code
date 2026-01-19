public class Solution {
    public int MaxSideLength(int[][] mat, int threshold) {
        int m = mat.Length, n = mat[0].Length;
        int[,] p = new int[m+1, n+1];

        for (int i = 0; i < m; i++)
            for (int j = 0; j < n; j++)
                p[i+1, j+1] = p[i, j+1] + p[i+1, j] - p[i, j] + mat[i][j];

        int lo = 0, hi = Math.Min(m, n);
        while (lo < hi) {
            int mid = (lo + hi + 1) / 2;
            if (Exists(p, m, n, mid, threshold)) lo = mid;
            else hi = mid - 1;
        }
        return lo;
    }

    bool Exists(int[,] p, int m, int n, int s, int t) {
        for (int i = 0; i <= m - s; i++)
            for (int j = 0; j <= n - s; j++) {
                int sum = p[i+s, j+s] - p[i, j+s] - p[i+s, j] + p[i, j];
                if (sum <= t) return true;
            }
        return false;
    }
}

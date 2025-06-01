public class Solution {
    public long DistributeCandies(int n, int limit) {
        long C(int x) {
            if (x < 0) return 0;
            return (long)(x + 1) * (x + 2) / 2;
        }
        long total = C(n);
        long minus1 = C(n - (limit + 1));
        long minus2 = C(n - 2 * (limit + 1));
        long minus3 = C(n - 3 * (limit + 1));
        return total - 3 * minus1 + 3 * minus2 - minus3;
    }
}

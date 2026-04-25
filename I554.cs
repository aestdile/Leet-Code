public class Solution {
    public int MaxDistance(int side, int[][] points, int k) {
        int n = points.Length;
        long[] pos = new long[n];
        for (int i = 0; i < n; i++) {
            int x = points[i][0], y = points[i][1];
            long p;
            if (y == 0)
                p = x;
            else if (x == side)
                p = side + y;
            else if (y == side)
                p = 2L * side + (side - x);
            else
                p = 3L * side + (side - y);
            pos[i] = p;
        }
        Array.Sort(pos);
        long L = 4L * side;
        int total = n * 2;
        long[] ext = new long[total];
        for (int i = 0; i < n; i++) {
            ext[i] = pos[i];
            ext[i + n] = pos[i] + L;
        }
        
        long low = 0, high = 2L * side;
        while (low < high) {
            long mid = (low + high + 1) / 2;
            if (CanPlace(mid, k, n, ext, L))
                low = mid;
            else
                high = mid - 1;
        }
        return (int) low;
    }
    
    private bool CanPlace(long d, int k, int n, long[] ext, long L) {
        for (int start = 0; start < n; start++) {
            int cur = start;
            long last = ext[start];
            bool valid = true;
            int limit = start + n;
            for (int step = 1; step < k; step++) {
                long target = last + d;
                int lo = cur + 1, hi = limit;
                while (lo < hi) {
                    int mid = (lo + hi) / 2;
                    if (ext[mid] < target)
                        lo = mid + 1;
                    else
                        hi = mid;
                }
                if (lo == limit) {
                    valid = false;
                    break;
                }
                cur = lo;
                last = ext[cur];
            }
            if (valid && (ext[start] + L - last >= d))
                return true;
        }
        return false;
    }
}

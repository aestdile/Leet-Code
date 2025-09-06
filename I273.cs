public class Solution{
    public long MinOperations(int[][] queries){
        long ans = 0;
        foreach (var query in queries){
            long start = query[0], end = query[1];
            long ops = 0;
            long prev = 1;
            for (long d = 1; d < 21; d++){
                long cur = prev * 4;
                long l = Math.Max(start, prev);
                long r = Math.Min(end, cur - 1);
                if (r >= l)
                    ops += (r - l + 1) * d;
                prev = cur;
            }
            ans += (ops + 1) / 2;
        }
        return ans;
    }
}

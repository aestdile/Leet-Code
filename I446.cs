public class Solution {
    public int NumOfWays(int n) {
        long even = 6;
        long odd = 6;
        long mod = (long)Math.Pow(10,9)+7;
        for(int i = 1; i < n; i++){
            long t_even = even * 3 + odd * 2;
            long t_odd = even * 2 + odd * 2;
            even = t_even % mod;
            odd = t_odd % mod;
        }
        return (int)((even+odd) % mod);
    }
}

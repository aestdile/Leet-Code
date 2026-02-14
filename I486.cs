public class Solution {
    public double ChampagneTower(int poured, int query_row, int query_glass) {
        int size = query_row+2, limit = 0, t = 0;
        double[] dp_f = new double[size];
        double[] dp_s = new double[size];
        dp_f[0] = poured;

        while(limit < query_row){
            if(dp_f[t] > 1){
                dp_s[t] += (dp_f[t] - 1 ) / 2;
                dp_s[t + 1] += (dp_f[t] - 1 ) / 2;
            }

            t++;
            if(limit < t){
                t = 0;
                limit++;
                Array.Copy(dp_s, dp_f, dp_s.Length); 
                Array.Clear(dp_s, 0, dp_s.Length);
            }
        }

        return dp_f[query_glass] > 1.0 ? 1.0 : dp_f[query_glass] ;
    }
}

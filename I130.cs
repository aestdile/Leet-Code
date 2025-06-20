public class Solution {
    public int MaxDistance(string s, int K) {
        
        char[] ns = ['N', 'S'];
        char[] we = ['W', 'E'];
        List<char[][]> combinations = new List<char[][]>();
        
        for(int i = 0; i < 4; i++) {
            char[][] comb = new char[2][];
            for (int k = 0; k < 2; k++) {
                bool reverse = false;
                if ((i & (1 << k)) > 0) {
                    reverse = true;  
                }
                if (k == 0) {
                    char[] nscop = new char[2];
                    Array.Copy(ns, nscop, 2);
                    if (reverse) {
                        Array.Reverse(nscop);
                    }
                    comb[0] = nscop;
                } else {
                    char[] wecop = new char[2];
                    Array.Copy(we, wecop, 2);
                    
                    if (reverse) {
                        Array.Reverse(wecop);
                    }
                    comb[1] = wecop;
                }
            }
            combinations.Add(comb);
        }
        int result = 0;
        foreach(var comb in combinations) {
            result = Math.Max(result, CalculateMaxDistance(s, comb, K));
        }
        return result;
    }
    int CalculateMaxDistance(string s, char[][] positions, int k) {
        int n = s.Length;
        int[] v = new int[n];
        for (int i = 0; i < n; i++) {
            if (positions[0][0] == s[i] || positions[1][0] == s[i]) {
                v[i] = 1;
            } else {
                v[i] = -1;
            }
        }
        int result = 0, csum = 0, negative = 0;
        for (int i = 0; i < n; i++) {
            csum += v[i];
            negative += (v[i] == -1 ? 1 : 0);
            result = Math.Max(result, csum + 2 * Math.Min(negative, k));
        }
        return result;
    }
}

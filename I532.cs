using System;
using System.Collections.Generic;

public class Solution {
    public int MaxWalls(int[] robots, int[] distance, int[] walls) {
        int n = robots.Length;
        var r = new List<(int, int)>();
        var rs = new HashSet<int>();
        
        for(int i = 0; i < n; i++) {
            r.Add((robots[i], distance[i]));
            rs.Add(robots[i]);
        }
        r.Sort((a, b) => a.Item1.CompareTo(b.Item1));
        
        int bw = 0;
        var vw = new List<int>();
        
        foreach(int w in walls) {
            if(rs.Contains(w)) bw++;
            else vw.Add(w);
        }
        vw.Sort();
        
        int GetW(int x, int y) {
            if(x > y) return 0;
            int i1 = vw.BinarySearch(x);
            if(i1 < 0) i1 = ~i1;
            int i2 = vw.BinarySearch(y);
            if(i2 < 0) i2 = ~i2;
            else i2++;
            return i2 - i1;
        }
        
        int[,] dp = new int[n, 2];
        dp[0, 0] = GetW(r[0].Item1 - r[0].Item2, r[0].Item1 - 1);
        dp[0, 1] = 0;
        
        for(int i = 1; i < n; i++) {
            int L = r[i-1].Item1, R = r[i].Item1;
            int d1 = r[i-1].Item2, d2 = r[i].Item2;
            
            int eR = Math.Min(R - 1, L + d1);
            int sL = Math.Max(L + 1, R - d2);
            
            int wR = GetW(L + 1, eR);
            int wL = GetW(sL, R - 1);
            int wBoth = (eR >= sL) ? GetW(L + 1, R - 1) : wR + wL;
            
            dp[i, 0] = Math.Max(dp[i-1, 0] + wL, dp[i-1, 1] + wBoth);
            dp[i, 1] = Math.Max(dp[i-1, 0], dp[i-1, 1] + wR);
        }
        
        int wEnd = GetW(r[n-1].Item1 + 1, r[n-1].Item1 + r[n-1].Item2);
        int ans = Math.Max(dp[n-1, 0], dp[n-1, 1] + wEnd);
        
        return ans + bw;
    }
}

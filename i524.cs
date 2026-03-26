using System;
using System.Collections.Generic;

public class Solution {
    private bool CanRemove(int r1, int c1, int r2, int c2, int i, int j) {
        int rows = r2 - r1 + 1;
        int cols = c2 - c1 + 1;

        if (rows * cols <= 1) return false;

        
        if (rows == 1) return (j == c1 || j == c2);
        if (cols == 1) return (i == r1 || i == r2);

       
        return true;
    }

    public bool CanPartitionGrids(int[][] grid) {
        int n = grid.Length;
        int m = grid[0].Length;

        long[] prefRow = new long[n];
        long[] prefCol = new long[m];
        Dictionary<int, List<int[]>> mp = new Dictionary<int, List<int[]>>();

        
        for (int i = 0; i < n; i++) {
            long rowSum = 0;
            for (int j = 0; j < m; j++) {
                int val = grid[i][j];
                rowSum += val;
                if (!mp.ContainsKey(val)) mp[val] = new List<int[]>();
                mp[val].Add(new int[] { i, j });
            }
            prefRow[i] = rowSum + (i > 0 ? prefRow[i - 1] : 0);
        }

        
        for (int j = 0; j < m; j++) {
            long colSum = 0;
            for (int i = 0; i < n; i++) {
                colSum += grid[i][j];
            }
            prefCol[j] = colSum + (j > 0 ? prefCol[j - 1] : 0);
        }

        long total = prefRow[n - 1];

        
        for (int i = 0; i < n - 1; i++) {
            long top = prefRow[i];
            long bottom = total - top;
            if (top == bottom) return true;

            long diff = Math.Abs(top - bottom);
            if (diff <= int.MaxValue && mp.ContainsKey((int)diff)) {
                foreach (var p in mp[(int)diff]) {
                    int x = p[0], y = p[1];
                    if (top > bottom) {
                        if (x <= i && CanRemove(0, 0, i, m - 1, x, y)) return true;
                    } else {
                        if (x > i && CanRemove(i + 1, 0, n - 1, m - 1, x, y)) return true;
                    }
                }
            }
        }

        
        for (int j = 0; j < m - 1; j++) {
            long left = prefCol[j];
            long right = total - left;
            if (left == right) return true;

            long diff = Math.Abs(left - right);
            if (diff <= int.MaxValue && mp.ContainsKey((int)diff)) {
                foreach (var p in mp[(int)diff]) {
                    int x = p[0], y = p[1];
                    if (left > right) {
                        if (y <= j && CanRemove(0, 0, n - 1, j, x, y)) return true;
                    } else {
                        if (y > j && CanRemove(0, j + 1, n - 1, m - 1, x, y)) return true;
                    }
                }
            }
        }

        return false;
    }
}

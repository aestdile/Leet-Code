using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public double SeparateSquares(int[][] squares) {
        List<(int y, int type, int x1, int x2)> events = new List<(int y, int type, int x1, int x2)>();
        SortedSet<int> xCoords = new SortedSet<int>();

        foreach (var s in squares) {
            int x = s[0], y = s[1], l = s[2];
            events.Add((y, 1, x, x + l));    
            events.Add((y + l, -1, x, x + l));
            xCoords.Add(x);
            xCoords.Add(x + l);
        }

        events.Sort((a, b) => a.y.CompareTo(b.y));
        int[] sortedX = xCoords.ToArray();
        Dictionary<int, int> xMap = new Dictionary<int, int>();
        for (int i = 0; i < sortedX.Length; i++) xMap[sortedX[i]] = i;

        int n = sortedX.Length;
        long[] count = new long[4 * n];
        double[] len = new double[4 * n];

        void Update(int node, int start, int end, int L, int R, int val) {
            if (L >= sortedX[end] || R <= sortedX[start]) return;
            if (L <= sortedX[start] && R >= sortedX[end]) {
                count[node] += val;
            } else {
                int mid = (start + end) / 2;
                Update(2 * node, start, mid, L, R, val);
                Update(2 * node + 1, mid, end, L, R, val);
            }

            if (count[node] > 0) {
                len[node] = sortedX[end] - sortedX[start];
            } else if (end - start > 1) {
                len[node] = len[2 * node] + len[2 * node + 1];
            } else {
                len[node] = 0;
            }
        }

        double totalArea = 0;
        for (int i = 0; i < events.Count - 1; i++) {
            Update(1, 0, n - 1, events[i].x1, events[i].x2, events[i].type);
            totalArea += len[1] * (events[i + 1].y - events[i].y);
        }

        Array.Clear(count, 0, count.Length);
        Array.Clear(len, 0, len.Length);
        
        double currentArea = 0;
        double target = totalArea / 2.0;

        for (int i = 0; i < events.Count - 1; i++) {
            Update(1, 0, n - 1, events[i].x1, events[i].x2, events[i].type);
            double areaInStep = len[1] * (events[i + 1].y - events[i].y);
            
            if (currentArea + areaInStep >= target) {
                return events[i].y + (target - currentArea) / len[1];
            }
            currentArea += areaInStep;
        }

        return events.Last().y;
    }
}

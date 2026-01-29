public class Solution {
    private const int INF = int.MaxValue / 2; 
    public long MinimumCost(string source, string target, char[] original, char[] changed, int[] cost) {
        int n = source.Length;
        int numChars = 26;
        
        int[,] dist = new int[numChars, numChars];
        for (int i = 0; i < numChars; i++) {
            for (int j = 0; j < numChars; j++) {
                if (i == j) {
                    dist[i, j] = 0;
                } else {
                    dist[i, j] = INF;
                }
            }
        }

        for (int i = 0; i < original.Length; i++) {
            int u = original[i] - 'a';
            int v = changed[i] - 'a';
            dist[u, v] = Math.Min(dist[u, v], cost[i]);
        }

        for (int k = 0; k < numChars; k++) {
            for (int i = 0; i < numChars; i++) {
                for (int j = 0; j < numChars; j++) {
                    if (dist[i, k] < INF && dist[k, j] < INF) {
                        dist[i, j] = Math.Min(dist[i, j], dist[i, k] + dist[k, j]);
                    }
                }
            }
        }

        long totalCost = 0;
        for (int i = 0; i < n; i++) {
            int srcChar = source[i] - 'a';
            int tgtChar = target[i] - 'a';
            int minCost = dist[srcChar, tgtChar];
            if (minCost == INF) {
                return -1;
            }
            totalCost += minCost;
        }

        return totalCost;
    }
}

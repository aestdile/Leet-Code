public class Solution {
    public int MaxStability(int n, int[][] edges, int k) {
        int[] parent = new int[n];
        for (int i = 0; i < n; i++) parent[i] = i;

        int Find(int i) {
            while (i != parent[i]) {
                parent[i] = parent[parent[i]];
                i = parent[i];
            }
            return i;
        }

        int minM = int.MaxValue;
        int compCount = n;
        
        ulong[] opt = new ulong[edges.Length];
        int oIdx = 0;

        foreach (var e in edges) {
            if (e[3] == 1) {
                int ru = Find(e[0]);
                int rv = Find(e[1]);
                if (ru == rv) return -1;
                parent[ru] = rv;
                compCount--;
                if (e[2] < minM) minM = e[2];
            }
        }

        foreach (var e in edges) {
            if (e[3] == 0) {
                int ru = Find(e[0]);
                int rv = Find(e[1]);
                if (ru != rv) {
                    opt[oIdx++] = ((ulong)e[2] << 34) | ((ulong)ru << 17) | (uint)rv;
                }
            }
        }

        if (compCount == 1) return minM;

        if (oIdx > 1) {
            ulong[] temp = new ulong[oIdx];
            int[] count = new int[256];
            for (int shift = 34; shift < 64; shift += 8) {
                System.Array.Clear(count, 0, 256);
                for (int i = 0; i < oIdx; i++) count[(opt[i] >> shift) & 0xFF]++;
                for (int i = 1; i < 256; i++) count[i] += count[i - 1];
                for (int i = oIdx - 1; i >= 0; i--) temp[--count[(opt[i] >> shift) & 0xFF]] = opt[i];
                ulong[] swap = opt; 
                opt = temp; 
                temp = swap;
            }
        }

        int[] upg = new int[compCount - 1];
        int upgCount = 0;

        for (int i = oIdx - 1; i >= 0; i--) {
            ulong packed = opt[i];
            int ru = Find((int)((packed >> 17) & 0x1FFFF));
            int rv = Find((int)(packed & 0x1FFFF));
            
            if (ru != rv) {
                parent[ru] = rv;
                upg[upgCount++] = (int)(packed >> 34);
                if (--compCount == 1) break;
            }
        }

        if (compCount > 1) return -1;

        for (int i = upgCount - 1; i >= 0; i--) {
            if (k > 0) {
                k--;
                int upgraded = upg[i] << 1;
                if (upgraded < minM) minM = upgraded;
            } else {
                if (upg[i] < minM) minM = upg[i];
                break;
            }
        }

        return minM;
    }
}

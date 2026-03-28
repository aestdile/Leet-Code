public class Solution {
    public string FindTheString(int[][] lcp) {
        int n = lcp.Length;
        var uf = new UnionFind(n);

        // Step 1: Union indices with shared characters
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                if (lcp[i][j] > 0) {
                    uf.Union(i, j);
                }
            }
        }

        // Step 2: Assign characters to groups
        var rootToChar = new Dictionary<int, char>();
        char nextChar = 'a';
        var res = new char[n];

        for (int i = 0; i < n; i++) {
            int root = uf.Find(i);
            if (!rootToChar.ContainsKey(root)) {
                if (nextChar > 'z') return "";
                rootToChar[root] = nextChar++;
            }
            res[i] = rootToChar[root];
        }

        // Step 3: Validate using prefix DP
        var dp = new int[n, n];
        for (int i = n - 1; i >= 0; i--) {
            for (int j = n - 1; j >= 0; j--) {
                if (res[i] == res[j]) {
                    dp[i, j] = 1 + ((i + 1 < n && j + 1 < n) ? dp[i + 1, j + 1] : 0);
                }
            }
        }

        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                if (dp[i, j] != lcp[i][j]) return "";
            }
        }

        return new string(res);
    }

    class UnionFind {
        private int[] parent;
        public UnionFind(int n) {
            parent = new int[n];
            for (int i = 0; i < n; i++) parent[i] = i;
        }

        public int Find(int x) {
            if (parent[x] != x) parent[x] = Find(parent[x]);
            return parent[x];
        }

        public void Union(int x, int y) {
            int rx = Find(x), ry = Find(y);
            if (rx != ry) parent[rx] = ry;
        }
    }
}

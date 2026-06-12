public class LCA {
    private int n;
    private int m;
    private int[] d;
    private List<int>[] e;
    private int[][] f;

    public LCA(int[][] edges, int root = 1) {
        n = edges.Length + 1;
        m = (int)(Math.Log(n) / Math.Log(2)) + 1;
        e = new List<int>[n + 1];
        d = new int[n + 1];
        f = new int [n + 1][];

        for (int i = 0; i <= n; i++) {
            e[i] = new List<int>();
            f[i] = new int[m];
        }

        foreach (var edge in edges) {
            int u = edge[0];
            int v = edge[1];
            e[u].Add(v);
            e[v].Add(u);
        }

        Dfs(root, 0);

        for (int i = 1; i < m; i++) {
            for (int x = 1; x <= n; x++) {
                f[x][i] = f[f[x][i - 1]][i - 1];
            }
        }
    }

    private void Dfs(int x, int fa) {
        f[x][0] = fa;
        foreach (int y in e[x]) {
            if (y == fa) {
                continue;
            }
            d[y] = d[x] + 1;
            Dfs(y, x);
        }
    }

    public int Lca(int x, int y) {
        if (d[x] > d[y]) {
            int temp = x;
            x = y;
            y = temp;
        }

        for (int i = m - 1; i >= 0; i--) {
            if (d[x] <= d[f[y][i]]) {
                y = f[y][i];
            }
        }

        if (x == y) {
            return x;
        }

        for (int i = m - 1; i >= 0; i--) {
            if (f[y][i] != f[x][i]) {
                x = f[x][i];
                y = f[y][i];
            }
        }

        return f[x][0];
    }

    public int Dis(int x, int y) {
        return d[x] + d[y] - d[Lca(x, y)] * 2;
    }
}

public class Solution {
    private const int MOD = 1000000007;
    private const int N = 100010;
    private static int[] p2 = new int[N];

    static Solution() {
        p2[0] = 1;
        for (int i = 1; i < N; i++) {
            p2[i] = (int)((long)p2[i - 1] * 2 % MOD);
        }
    }

    public int[] AssignEdgeWeights(int[][] edges, int[][] queries) {
        LCA lca = new LCA(edges, 1);
        int m = queries.Length;
        int[] res = new int[m];

        for (int i = 0; i < m; i++) {
            int x = queries[i][0];
            int y = queries[i][1];
            if (x != y) {
                res[i] = p2[lca.Dis(x, y) - 1];
            }
        }

        return res;
    }
}

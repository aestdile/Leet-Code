public class Solution {
    public int MinimumScore(int[] nums, int[][] edges) {
        int n = nums.Length;
        List<int>[] graph = new List<int>[n];
        for (int i = 0; i < n; i++) graph[i] = new List<int>();
        foreach (var edge in edges) {
            graph[edge[0]].Add(edge[1]);
            graph[edge[1]].Add(edge[0]);
        }

        int[] xor = new int[n];
        int[] inTime = new int[n];
        int[] outTime = new int[n];
        int time = 0;

        void Dfs(int node, int parent) {
            xor[node] = nums[node];
            inTime[node] = time++;
            foreach (int nei in graph[node]) {
                if (nei == parent) continue;
                Dfs(nei, node);
                xor[node] ^= xor[nei];
            }
            outTime[node] = time++;
        }

        Dfs(0, -1);
        int totalXor = xor[0];
        int minScore = int.MaxValue;

        bool IsAncestor(int u, int v) {
            return inTime[u] < inTime[v] && outTime[v] < outTime[u];
        }

        for (int i = 1; i < n; i++) {
            for (int j = i + 1; j < n; j++) {
                int a = i, b = j;
                int x, y, z;
                if (IsAncestor(a, b)) {
                    x = xor[b];
                    y = xor[a] ^ xor[b];
                    z = totalXor ^ xor[a];
                }
                else if (IsAncestor(b, a)) {
                    x = xor[a];
                    y = xor[b] ^ xor[a];
                    z = totalXor ^ xor[b];
                }
                else {
                    x = xor[a];
                    y = xor[b];
                    z = totalXor ^ xor[a] ^ xor[b];
                }

                int maxXor = Math.Max(x, Math.Max(y, z));
                int minXor = Math.Min(x, Math.Min(y, z));
                minScore = Math.Min(minScore, maxXor - minXor);
            }
        }

        return minScore;
    }
}

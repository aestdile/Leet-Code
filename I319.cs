public class Solution {
    public int SwimInWater(int[][] grid) {
        int n = grid.Length;
        var visited = new bool[n, n];
        var pq = new PriorityQueue<(int r, int c), int>();
        pq.Enqueue((0, 0), grid[0][0]);

        int[][] dirs = new int[][] {
            new int[]{0, 1}, new int[]{1, 0},
            new int[]{0, -1}, new int[]{-1, 0}
        };

        int res = 0;

        while (pq.Count > 0) {
            var (r, c) = pq.Dequeue();
            if (visited[r, c]) continue;
            visited[r, c] = true;
            res = Math.Max(res, grid[r][c]);

            if (r == n - 1 && c == n - 1) return res;

            foreach (var d in dirs) {
                int nr = r + d[0], nc = c + d[1];
                if (nr >= 0 && nr < n && nc >= 0 && nc < n && !visited[nr, nc]) {
                    pq.Enqueue((nr, nc), grid[nr][nc]);
                }
            }
        }

        return -1; 
    }
}

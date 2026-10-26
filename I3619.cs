public class Solution {
    public int CountIslands(int[][] grid, int k) {
        int n = grid.Length;
        int m = grid[0].Length;
        int result = 0;
        bool[,] seen = new bool[n,m];
        int[][] directions = new int[4][]{
            new int[2] {1, 0},
            new int[2] {0, 1},
            new int[2] {-1, 0},
            new int[2] {0, -1}
        };
        for(int i = 0; i < n; i++){
            for(int j = 0; j < m; j++){
                if(grid[i][j] == 0 || seen[i,j]) continue;
                else {
                    result += BFS(k, grid, i, j, seen, directions, n, m);
                }
            }
        }
        return result;
    }

    public int BFS(int k, int[][] grid, int i, int j, bool[,] seen, int[][] directions, int n, int m){
        seen[i,j] = true;
        long total = 0;
        Queue<(int x, int y)> queue = new Queue<(int x, int y)>();
        queue.Enqueue((i, j));
        while(queue.Count > 0){
            (int x, int y) pos = queue.Dequeue();
            total += grid[pos.x][pos.y];
            foreach(int[] direction in directions){
                int cx = pos.x + direction[0];
                int cy = pos.y + direction[1];
                if(cx >= n || cx < 0 || cy >= m || cy < 0) continue;
                if(!seen[cx,cy]){
                    seen[cx,cy] = true;
                    if(grid[cx][cy] != 0) queue.Enqueue((cx, cy));
                }
            }
        }
        return total % k == 0 ? 1 : 0;
    }
}

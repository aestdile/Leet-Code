public class Solution {
    public IList<IList<int>> PacificAtlantic(int[][] heights) {
        int m = heights.Length;
        int n = heights[0].Length;

        bool[,] pacificVisited = new bool[m, n];
        bool[,] atlanticVisited = new bool[m, n];
        IList<IList<int>> result = new List<IList<int>>();

        for (int i = 0; i < m; i++) {
            DFS(heights, pacificVisited, i, 0, m, n, -1);
            DFS(heights, atlanticVisited, i, n - 1, m, n, -1);
        }

        for (int j = 0; j < n; j++) {
            DFS(heights, pacificVisited, 0, j, m, n, -1);
            DFS(heights, atlanticVisited, m - 1, j, m, n, -1);
        }

        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (pacificVisited[i, j] && atlanticVisited[i, j]) {
                    result.Add(new List<int>() { i, j });
                }
            }
        }

        return result;
    }

    private void DFS(int[][] heights, bool[,] visited, int i, int j, int m, int n, int previousHeight) {
        if (i < 0 || i >= m || j < 0 || j >= n || visited[i, j] || heights[i][j] < previousHeight) {
            return;
        }

        visited[i, j] = true;

        DFS(heights, visited, i + 1, j, m, n, heights[i][j]);
        DFS(heights, visited, i - 1, j, m, n, heights[i][j]);
        DFS(heights, visited, i, j + 1, m, n, heights[i][j]);
        DFS(heights, visited, i, j - 1, m, n, heights[i][j]);
    }
}

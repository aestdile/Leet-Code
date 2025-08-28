public class Solution {
    public int[][] SortMatrix(int[][] grid) {
        int n = grid.Length;
        var diagonals = new Dictionary<int, List<int>>();

        // Step 1: Collect elements of each diagonal
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                int key = i - j;
                if (!diagonals.ContainsKey(key)) {
                    diagonals[key] = new List<int>();
                }
                diagonals[key].Add(grid[i][j]);
            }
        }

        // Step 2: Sort each diagonal
        foreach (var key in diagonals.Keys) {
            if (key >= 0) {
                // Bottom-left triangle (including main diagonal) → sort in non-increasing order
                diagonals[key].Sort((a, b) => b.CompareTo(a));
            } else {
                // Top-right triangle → sort in non-decreasing order
                diagonals[key].Sort();
            }
        }

        // Step 3: Put back sorted values into the grid
        var indexMap = new Dictionary<int, int>();
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                int key = i - j;
                if (!indexMap.ContainsKey(key)) indexMap[key] = 0;
                int idx = indexMap[key];
                grid[i][j] = diagonals[key][idx];
                indexMap[key] = idx + 1;
            }
        }

        return grid;
    }
}
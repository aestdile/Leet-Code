public class Solution {
    private int[][] directions = new int[][] { new int[] { 1, 0 }, new int[] { -1, 0 }, new int[] { 0, 1 }, new int[] { 0, -1 } };
    
    public bool CanCross(int row, int col, int[][] cells, int day) {
        int[][] grid = new int[row][];
        for (int i = 0; i < row; i++) {
            grid[i] = new int[col];
        }
        
        for (int i = 0; i < day; i++) {
            int r = cells[i][0] - 1;
            int c = cells[i][1] - 1;
            grid[r][c] = 1;
        }
        
        for (int i = 0; i < col; i++) {
            if (grid[0][i] == 0 && DFS(grid, 0, i, row, col)) {
                return true;
            }
        }
        
        return false;
    }

    private bool DFS(int[][] grid, int r, int c, int row, int col) {
        if (r < 0 || r >= row || c < 0 || c >= col || grid[r][c] != 0) {
            return false;
        }
        
        if (r == row - 1) {
            return true;
        }
        
        grid[r][c] = -1;
        
        foreach (int[] dir in directions) {
            int newR = r + dir[0];
            int newC = c + dir[1];
            if (DFS(grid, newR, newC, row, col)) {
                return true;
            }
        }
        
        return false;
    }

    public int LatestDayToCross(int row, int col, int[][] cells) {
        int left = 1;
        int right = row * col;
        
        while (left < right) {
            int mid = right - (right - left) / 2;
            if (CanCross(row, col, cells, mid)) {
                left = mid;
            } else {
                right = mid - 1;
            }
        }
        
        return left;
    }
}

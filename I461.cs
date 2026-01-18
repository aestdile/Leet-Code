public class Solution {
    public int LargestMagicSquare(int[][] grid) 
    {
        int m = grid.Length, n = grid[0].Length;

        for (int side = Math.Min(m, n); side > 1; side--) 
            if (ExistMagicSquare(grid, m, n, side)) return side;

        return 1;
    }
    
    public bool ExistMagicSquare(int[][] grid, int m, int n, int side) 
    {
        int maxRow = m - side, maxColumn = n - side;

        for (int i = 0; i <= maxRow; i++) 
            for (int j = 0; j <= maxColumn; j++) 
                if (IsMagicSquare(grid, i, j, side)) return true;

        return false;
    }
    
    public bool IsMagicSquare(int[][] grid, int startRow, int startColumn, int side) {
        HashSet<int> set = new HashSet<int>();
        int[] rowSums = new int[side];
        int[] columnSums = new int[side];
        int diagonal1 = 0, diagonal2 = 0;

        for (int i = 0; i < side; i++) 
        {
            for (int j = 0; j < side; j++) 
            {
                rowSums[i] += grid[startRow + i][startColumn + j];
                columnSums[j] += grid[startRow + i][startColumn + j];
                if (i == j) diagonal1 += grid[startRow + i][startColumn + j];
                if (i + j == side - 1) diagonal2 += grid[startRow + i][startColumn + j];
            }
        }

        for (int i = 0; i < side; i++) 
        {
            set.Add(rowSums[i]);
            set.Add(columnSums[i]);
        }
        
        set.Add(diagonal1);
        set.Add(diagonal2);
        return set.Count == 1;
    }
}

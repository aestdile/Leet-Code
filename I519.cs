public class Solution {
    public int[][] ReverseSubmatrix(int[][] grid, int x, int y, int k) {
                    var top = x;
            var bottom = x + k - 1;

            while (top < bottom)
            {
                for (var i = y; i < y + k; i++)
                {
                    var temp = grid[top][i];
                    grid[top][i] = grid[bottom][i];
                    grid[bottom][i] = temp;
                }
                top++;
                bottom--;
            }

            return grid;
    }
}

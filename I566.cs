public class Solution {
    public int[][] RotateGrid(int[][] grid, int k) {
        int m = grid.Length, n = grid[0].Length;
        int top = 0, bottom = m-1, left = 0, right = n-1;

        while(top < bottom && left < right)
        {
            int perimeter = 2*(bottom-top+right-left);
            int restRot = k % perimeter;

            for(int rotate = 0; rotate < restRot; rotate++)
            {
                int topLeft = grid[top][left];
                for(int j = left; j < right; j++) // top row
                {
                    grid[top][j] = grid[top][j+1];
                }

                for(int i = top; i < bottom; i++) // right column
                {
                    grid[i][right] = grid[i+1][right];
                }

                for(int j = right; j > left; j--) // bottom row:
                {
                    grid[bottom][j] = grid[bottom][j-1];
                }

                for(int i = bottom; i > top; i--) // left column:
                {
                    grid[i][left] = grid[i-1][left];
                }

                grid[top+1][left] = topLeft;
            }

            top++;
            bottom--;
            left++;
            right--;
        }

        return grid;
    }
}

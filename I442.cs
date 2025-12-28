public class Solution {
    public int CountNegatives(int[][] grid) {
        int n = grid.Length;
        int m = grid[0].Length;

        int row = 0; 
        int col = m - 1;
        int count = 0;
        while(row<n && col >=0){
            if(grid[row][col] < 0){
                count = count + (n-row);
                col--;
            }
            else if(grid[row][col] >= 0){
                row++;
            }
        }
        return count;
    }
}

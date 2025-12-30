public class Solution {
    public int NumMagicSquaresInside(int[][] grid) {
        int rows = grid.Length;
        int cols = grid[0].Length;
        int res = 0;
        int Helper(int r, int c){
            var set = new HashSet<int>();
            for(int r1 = r; r1< r+3; r1++){
                for(int c1 = c; c1< c+3; c1++){
                    if(grid[r1][c1] == 0 || grid[r1][c1] > 9 || set.Contains(grid[r1][c1])){
                        return 0;
                    }
                    set.Add(grid[r1][c1]);
                }
            }
            //Row sum
            for(int i=0;i<3;i++){
                if(grid[r+i][c] + grid[r+i][c+1] + grid[r+i][c+2] != 15){
                    return 0;
                }
            }
            //Col sum
            for(int i=0;i<3;i++){
                if(grid[r][c+i] + grid[r+1][c+i] + grid[r+2][c+i] != 15){
                    return 0;
                }
            }
            //Diagonals sum
            if((grid[r][c] + grid[r+1][c+1] + grid[r+2][c+2]) != 15 || (grid[r][c+2] + grid[r+1][c+1] + grid[r+2][c]) != 15){
                return 0;
            }
            return 1;
        }
        
        for(int r=0;r<rows-2;r++){
            for(int c=0;c<cols-2;c++){
                res += Helper(r,c);
            }        
        }
        return res;
    }
}

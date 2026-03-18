public class Solution {
    public int CountSubmatrices(int[][] grid, int k) 
    {
        int rows=grid.Length;
        int cols=grid[0].Length;
        int count=0;
        int[][] ps=new int[rows][];
        
        for(int i=0;i<rows;i++)
        {
            ps[i]=new int[cols];
            for(int j=0;j<cols;j++)
            {
                
                ps[i][j]=grid[i][j];
                if(i>0)
                {
                    ps[i][j]+=ps[i-1][j];
                }
                if(j>0)
                {
                    ps[i][j]+=ps[i][j-1];
                }
                if(i>0 && j>0)
                {
                    ps[i][j]-=ps[i-1][j-1];
                }
                if(ps[i][j]<=k)
                {
                    count++;
                }
            }
        }
        return count;
    }
}

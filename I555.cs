public class Solution 
{
    public bool ContainsCycle(char[][] grid) 
    {
        int m = grid.Length;
        int n = grid[0].Length;
        int[,] visited = new int[m,n];
        
        for(int i=0;i<m;i++)
        {
            for(int j=0;j<n;j++)
            {
                if(visited[i,j]==0 && DetectCycle(grid,i,j,i,j,0,grid[i][j],visited))
                    return true;
            }
        }
        
        return false;
    }
    
    int[] dX = {-1,1,0,0};
    int[] dY = {0,0,-1,1};
    
    private bool DetectCycle(char[][] grid, int i, int j, int prevI,int prevJ, int len, char ch, int[,] visited)
    {
        if(visited[i,j]==1 && len>=4)
                return true;
            
        if(visited[i,j]==1)
            return false;
            
        visited[i,j]=1;
        
        bool hasCycle = false;
        
        for(int d=0; d<4; d++)
        {
            int x = i + dX[d];
            int y = j + dY[d];
            
            if(x<0 || x>=grid.Length || y<0 || y>=grid[0].Length || grid[x][y] != ch || (x==prevI && y==prevJ))
                continue;
            
            hasCycle = hasCycle || DetectCycle(grid,x,y,i,j,len+1,ch,visited);
        }
        
        return hasCycle;
    }
}

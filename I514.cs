public class Solution {
    private HashSet<int> visited = new();
    private int m, n;
    private List<int> maxVals = new();
        
    private void UpdateVals(int val)
    {
        int cur = val;
        if(maxVals.Count < 3 || cur > maxVals.First())
        {
            int idx = maxVals.BinarySearch(cur);
            if(idx < 0)
                idx = ~idx;

            maxVals.Insert(idx, cur);
            if(maxVals.Count > 3)
                maxVals.RemoveAt(0);
        }

        visited.Add(cur);
    }

    public int[] GetBiggestThree(int[][] grid) {
        m = grid.Length;
        n = grid[0].Length;
        int[,] diaglr = new int[m, n], diagrl = new int[m, n];
        
        for(int i = 0; i < m; i++)
        {
            for(int j = 0; j < n; j++)
            {
                int cur = grid[i][j];
                if((i == 0 || i == m-1 || j == 0 || j == n-1 ) && !visited.Contains(cur))
                {
                    UpdateVals(cur);
                }

                diaglr[i,j] = cur;
                diagrl[i,j] = cur;

                if(i > 0 && j > 0)
                    diaglr[i,j] += diaglr[i-1, j-1];

                if(i> 0 && j < n-1)
                    diagrl[i,j] += diagrl[i-1, j+1];
            }
        }

        for(int i = 1; i < m-1; i++)
        {
            for(int j = 1; j < n-1; j++)
            {
                int top = i-1, bottom = i+1, left = j-1, right = j+1;
                while(top >= 0 && bottom < m && left >= 0 && right < n)
                {
                    int sum = diagrl[i,left]-diagrl[top,j] + diagrl[bottom,j]-diagrl[i,right] + diaglr[bottom, j]-diaglr[i, left] + diaglr[i,right]-diaglr[top,j] + grid[top][j] - grid[bottom][j];
                    
                    if(!visited.Contains(sum))
                        UpdateVals(sum);

                    top--;
                    bottom++;
                    left--;
                    right++;
                }
            }
        }

        if(maxVals.Count > 1)
        {
            int tmp = maxVals[maxVals.Count-1];
            maxVals[maxVals.Count-1] = maxVals[0];
            maxVals[0] = tmp;
        }

        return maxVals.ToArray();
    }
}

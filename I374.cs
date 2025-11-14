public class Solution {
    public int[][] RangeAddQueries(int n, int[][] queries) {
        var res = new int[n][];
        for(int i=0;i<n;i++)
            res[i] = new int [n];
        
        foreach(var q in queries){
            var x1 = q[0];
            var y1 = q[1];
            var x2 = q[2];
            var y2 = q[3];

            for(int r = x1;r<=x2; r++){
                res[r][y1] += 1;
                if(y2+1<n)
                    res[r][y2+1] -= 1;
            }
        }

        for(int r=0;r<n;r++){
            for(int c = 01;c<n;c++){
                res[r][c] += res[r][c-1];
            }
        }
        return res;
    }
}
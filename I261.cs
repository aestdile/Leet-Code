public class Solution {
    public int[] FindDiagonalOrder(int[][] mat)
    {
        int m = mat.Length;
        int n = mat[0].Length;
        int[] res = new int[m*n];
        int i = 0;
        int nDiag = m+n;
        bool up = true;
        for (int d = 0; d <= nDiag; d++, up=!up)
        {
            int r = up? Math.Min(d,m-1) : d-Math.Min(d,n-1);
            int c = up? d-Math.Min(d,m-1) : Math.Min(d,n-1);

            while (up && r >= 0 && c<n)
                res[i++] = mat[r--][c++];

            while (!up && c >= 0 && r<m)
                res[i++] = mat[r++][c--];

        }

        return res;
    }
}
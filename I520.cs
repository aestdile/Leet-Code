public class Solution {
        public bool FindRotation(int[][] mat, int[][] target)
        {
            for (var i = 0; i < 4; i++)
            {
                if (ArrEqual(mat, target))
                {
                    return true;
                }
                Rotate(mat);
            }
            return false;
        }

        private bool ArrEqual(int[][] m1, int[][] m2)
        {
            var n = m1.Length;
            for (var r = 0; r < n; r++)
            {
                for (var c = 0; c < n; c++)
                {
                    if (m1[r][c] != m2[r][c]) return false;
                }
            }
            return true;
        }

        private void Rotate(int[][] mat)
        {
            var n = mat.Length;

            for (var i = 0; i < n; i++)
            {
                for (var j = i + 1; j < n; j++)
                {
                    var tmp = mat[i][j];
                    mat[i][j] = mat[j][i];
                    mat[j][i] = tmp;
                }
            }

            for (var i = 0; i < n; i++)
            {

                for (var j = 0; j < n / 2; j++)
                {
                    var tmp = mat[i][j];
                    mat[i][j] = mat[i][n - 1 - j];
                    mat[i][n - 1 - j] = tmp;
                }
            }
        }
}

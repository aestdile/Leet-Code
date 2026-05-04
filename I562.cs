public class Solution {
    public void Rotate(int[][] matrix) {
        var max = matrix.Length - 1;
        for(var i = 0; i < matrix.Length / 2; i++) 
            for(var j = i; j < max - i; j++)
                (matrix[i][j], matrix[max - j][i], matrix[max - i][max - j], matrix[j][max - i]) = (matrix[max - j][i], matrix[max - i][max - j], matrix[j][max - i], matrix[i][j]);
    }
}

public class Solution {
    public int NumSpecial(int[][] mat) {
        int m = mat.Length;
        int n = mat[0].Length;
        int[] rowOnes = new int[m];
        int[] colOnes = new int[n];
        int count = 0;

        // Counting the number of ones in each row and column
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                rowOnes[i] += mat[i][j];
                colOnes[j] += mat[i][j];
            }
        }

        // Checking for special positions
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (mat[i][j] == 1 && rowOnes[i] == 1 && colOnes[j] == 1) {
                    count++;
                }
            }
        }

        return count;
    }
}

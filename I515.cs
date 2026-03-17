public class Solution {
    public int LargestSubmatrix(int[][] matrix) {
        int m = matrix.Length;
        int n = matrix[0].Length;

        // Update the matrix to maintain the count of consecutive 1s vertically
        for (int i = 1; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (matrix[i][j] == 1) {
                    matrix[i][j] += matrix[i - 1][j];
                }
            }
        }

        // Sort each row to find the maximum area
        int maxArea = 0;
        for (int i = 0; i < m; i++) {
            Array.Sort(matrix[i]);
            for (int j = n - 1; j >= 0; j--) {
                maxArea = Math.Max(maxArea, matrix[i][j] * (n - j));
            }
        }

        return maxArea;
    }
}

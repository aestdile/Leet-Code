public class Solution {
    public long MaxMatrixSum(int[][] matrix) {
        long totalSum = 0; 
        int minAbsValue = int.MaxValue; 
        bool hasOddNegatives = false; 

        int n = matrix.Length;
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                int value = matrix[i][j];
                int absValue = Math.Abs(value);
                totalSum += absValue;
                if (absValue < minAbsValue) {
                    minAbsValue = absValue;
                }
                if (value < 0) {
                    hasOddNegatives = !hasOddNegatives;
                }
            }
        }
        if (hasOddNegatives) {
            totalSum -= 2 * minAbsValue;
        }

        return totalSum;
    }
}

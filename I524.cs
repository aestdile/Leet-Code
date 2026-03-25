public class Solution {
    public bool CanPartitionGrid(int[][] grid) {
        var sum = 0L;
        var rowSums = new int[grid.Length];
        var colSums = new int[grid[0].Length];
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[i].Length; j++)
            {
                rowSums[i] += grid[i][j];
                colSums[j] += grid[i][j];
                sum += grid[i][j];
            }
        }
        if (sum % 2 == 1) return false;
        var sum0 = 0L;
        for (int i = 0; i < rowSums.Length; i++)
        {
            sum0 += rowSums[i];
            if (sum0 * 2 == sum) return true;
        }
        sum0 = 0L;
        for (int i = 0; i < colSums.Length; i++)
        {
            sum0 += colSums[i];
            if (sum0 * 2 == sum) return true;
        }
        return false;
    }
}

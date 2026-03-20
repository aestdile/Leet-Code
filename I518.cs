public class Solution {
    public int[][] MinAbsDiff(int[][] grid, int k) {
            var row = grid.Length;
            var col = grid[0].Length;
            var result = new int[row - k + 1][];
            var arr = new int[k * k];

            for (var i = 0; i < result.Length; i++)
            {
                result[i] = new int[col - k + 1];
            }

            for (var i = 0; i <= row - k; i++)
            {
                for (var j = 0; j <= col - k; j++)
                {
                    var idx = 0;

                    for (var x = i; x < i + k; x++)
                    {
                        for (var y = j; y < j + k; y++)
                        {
                            arr[idx++] = grid[x][y];
                        }
                    }

                    Array.Sort(arr);

                    var minDiff = int.MaxValue;

                    for (var q = 0; q < arr.Length - 1; q++)
                    {
                        if (arr[q + 1] != arr[q])
                            minDiff = Math.Min(minDiff, arr[q + 1] - arr[q]);
                    }

                    if (minDiff < int.MaxValue)
                        result[i][j] = minDiff;
                }
            }

            return result;
    }
}

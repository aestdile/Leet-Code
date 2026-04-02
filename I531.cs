public class Solution {
    public int MaximumAmount(int[][] coins) {
			int rows = coins.Length, cols = coins[0].Length;
			var dp = new int[3, rows, cols];
			for (int k = 0; k < 3; k++)
			{
				for (int i = 0; i < rows; i++)
				{
					for (int j = 0; j < cols; j++)
					{
						dp[k, i, j] = int.MinValue / 2;
					}
				}
			}
			dp[0, 0, 0] = coins[0][0];
			dp[1, 0, 0] = 0;

			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < cols; j++)
				{
                    if(i == 0 && j == 0)
                        continue;

					int v = coins[i][j];
					for (int k = 0; k < 3; k++)
					{
						if (i > 0)
							dp[k,i,j] = Math.Max(dp[k,i,j], dp[k,i - 1,j] + v); // compare to top

						if (j > 0)
							dp[k,i,j] = Math.Max(dp[k,i,j], dp[k,i,j - 1] + v); // compare to left
					}

					if (v < 0)
					{
						for (int k = 1; k < 3; k++)
						{
							if (i > 0)
								dp[k,i,j] = Math.Max(dp[k,i,j], dp[k - 1,i - 1,j]); // compare to top & k-1

							if (j > 0)
								dp[k,i,j] = Math.Max(dp[k,i,j], dp[k - 1,i,j - 1]); // compare to left & k-1
						}
					}
				}
			}
            
			int res = int.MinValue;
			for (int k = 0; k < 3; k++)
				res = Math.Max(res, dp[k,rows - 1,cols - 1]);

			return res;
    }
}

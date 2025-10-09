public class Solution {
    public long MinTime(int[] skill, int[] mana) {
 			int wCnt = skill.Length;
			long[] dp = new long[wCnt];
			dp[0] = skill[0] * mana[0];
			for (int i = 0; i < wCnt; i++)
			{
				dp[i] = (skill[i] * mana[0]);
				if (i > 0)
					dp[i] += dp[i - 1];
			}

			for (int p = 1; p < mana.Length; p++)
			{
				long[] tmp = new long[wCnt];
				for (int j = 0; j < wCnt; j++)
				{
					long curTime = mana[p] * skill[j];
					tmp[j] = (j > 0 ? Math.Max(dp[j], tmp[j - 1]) : dp[j]) + curTime;
				}

				dp[wCnt - 1] = tmp[wCnt - 1];
				for (int j = wCnt - 2; j >= 0; j--)
				{
					dp[j] = dp[j + 1] - (long)mana[p] * skill[j+1];
				}
			}

			return dp[wCnt - 1];
    }
}

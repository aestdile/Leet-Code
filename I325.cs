public class Solution{
    public long MaximumTotalDamage(int[] power){
        Array.Sort(power);
        int n = power.Length;
        long[] dp = new long[n];
        long[] max = new long[n];
        dp[0] = power[0];
        max[0] = dp[0];
        for (int i = 1; i < n; i++)
        {
            if (power[i] == power[i - 1])
            {
                dp[i] = dp[i - 1] + power[i];
                max[i] = Math.Max(max[i - 1], dp[i]);
                continue;
            }
            int find = Find(power, power[i] - 2);
            if (find < 0) dp[i] = power[i];
            else dp[i] = max[find] + power[i];
            max[i] = Math.Max(max[i - 1], dp[i]);
        }

        return max[n - 1];
    }

    int Find(int[] power, int val)
    {
        int n = power.Length;
        int low = 0, high = n - 1;
        int ans = -1;
        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            if (power[mid] < val)
            {
                ans = mid;
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }

        return ans;
    }
}

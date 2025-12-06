public class Solution {
    public int CountPartitions(int[] nums, int k) {
        int n = nums.Length, MOD = 1000000007;
        long[] dp = new long[n + 1];
        dp[0] = 1;

        var mx = new System.Collections.Generic.LinkedList<int>();
        var mn = new System.Collections.Generic.LinkedList<int>();

        int l = 0;
        long sum = 0;

        for (int r = 0; r < n; r++) {
            while (mx.Count > 0 && nums[mx.Last.Value] <= nums[r]) mx.RemoveLast();
            while (mn.Count > 0 && nums[mn.Last.Value] >= nums[r]) mn.RemoveLast();
            mx.AddLast(r);
            mn.AddLast(r);

            while (nums[mx.First.Value] - nums[mn.First.Value] > k) {
                if (mx.First.Value == l) mx.RemoveFirst();
                if (mn.First.Value == l) mn.RemoveFirst();
                sum = (sum - dp[l] + MOD) % MOD;
                l++;
            }

            sum = (sum + dp[r]) % MOD;
            dp[r + 1] = sum;
        }

        return (int)dp[n];
    }
}

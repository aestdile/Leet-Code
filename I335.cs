public class Solution {
    public int MaxFrequency(int[] nums, int k, int numOperations) {
        int mx = nums.Max();
        int n = mx + k + 2;
        int[] f = new int[n];
        foreach (int x in nums) f[x]++;

        int[] pre = new int[n];
        pre[0] = f[0];
        for (int i = 1; i < n; i++) pre[i] = pre[i - 1] + f[i];

        int ans = 0;
        for (int t = 0; t < n; t++) {
            if (f[t] == 0 && numOperations == 0) continue;
            int l = Math.Max(0, t - k), r = Math.Min(n - 1, t + k);
            int tot = pre[r] - (l > 0 ? pre[l - 1] : 0);
            int adj = tot - f[t];
            int val = f[t] + Math.Min(numOperations, adj);
            ans = Math.Max(ans, val);
        }
        return ans;
    }
}

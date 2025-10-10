public class Solution {
    public int MaximumEnergy(int[] energy, int k) {
        int n = energy.Length;
        int[] dp = new int[n];
        int result = int.MinValue;
        for (int i = n - 1; i >= 0; i--) {
            dp[i] = energy[i] + ((i + k < n) ? dp[i + k] : 0);
            result = Math.Max(result, dp[i]);
        }
        return result;
    }
}

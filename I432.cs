public class Solution {
    public long MaxProfit(int[] prices, int[] strategy, int k) {
        int n = prices.Length;
        long[] prefProfit = new long[n + 1];
        long[] prefPrice = new long[n + 1];

        for (int i = 0; i < n; i++) {
            prefProfit[i + 1] = prefProfit[i] + (long)strategy[i] * prices[i];
            prefPrice[i + 1] = prefPrice[i] + prices[i];
        }

        long originalProfit = prefProfit[n];
        long maxGain = 0;

        int half = k / 2;
        for (int l = 0; l + k <= n; l++) {
            int mid = l + half;
            int r = l + k;
            long oldContribution = prefProfit[r] - prefProfit[l];
            long newContribution = prefPrice[r] - prefPrice[mid];
            long gain = newContribution - oldContribution;
            if (gain > maxGain) {
                maxGain = gain;
            }
        }
        return originalProfit + maxGain;
    }
}

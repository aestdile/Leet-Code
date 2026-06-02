public class Solution {
    public int EarliestFinishTime(int[] landStartTime, int[] landDuration, int[] waterStartTime, int[] waterDuration) =>
        Math.Min(
            landStartTime.Select((m, i) => waterStartTime.Select((n, j) => m + landDuration[i] <= n ? n + waterDuration[j] : m + landDuration[i] + waterDuration[j]).Min()).Min(),
            waterStartTime.Select((n, j) => landStartTime.Select((m, i) => n + waterDuration[j] <= m ? m + landDuration[i] : n + waterDuration[j] + landDuration[i]).Min()).Min()
        );
}

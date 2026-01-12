public class Solution {
    public int MinTimeToVisitAllPoints(int[][] p) {
        int ans = 0;
        for (int i = 1; i < p.Length; i++) {
            ans += Math.Max(
                Math.Abs(p[i][0] - p[i - 1][0]),
                Math.Abs(p[i][1] - p[i - 1][1])
            );
        }
        return ans;
    }
}

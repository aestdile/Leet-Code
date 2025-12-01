public class Solution {
    public long MaxRunTime(int n, int[] batteries) {
        Array.Sort(batteries);
        long totalEnergy = 0;
        foreach (int b in batteries) totalEnergy += b;

        long left = 1, right = totalEnergy / n;
        while (left < right) {
            long mid = (left + right + 1) / 2; // upper mid
            long usable = 0;

            foreach (int b in batteries) {
                usable += Math.Min((long)b, mid);
            }

            if (usable >= mid * n) {
                left = mid; // feasible -> try longer
            } else {
                right = mid - 1; // infeasible -> shorten
            }
        }

        return left;
    }
}
public class Solution {
    public long MinNumberOfSeconds(int mountainHeight, int[] workerTimes) {
        long minTime = 0;
        long maxTime = (long)9e18;

        while (minTime < maxTime) {
            long averageTime = (minTime + maxTime) / 2;

            if (CanReduceHeightInTime(averageTime, mountainHeight, workerTimes)) {
                maxTime = averageTime;
            } else {
                minTime = averageTime + 1;
            }
        }

        return minTime;
    }

    private bool CanReduceHeightInTime(long time, int mountainHeight, int[]workerTimes) {
        long totalReduceHeight = 0;

        foreach(var workerTime in workerTimes) {
            totalReduceHeight += 
                (-1 + (long)(Math.Sqrt(1 + 4 * 2 * time / workerTime))) / 2;

            if (totalReduceHeight >= mountainHeight)
                return true;
        }

        return totalReduceHeight >= mountainHeight;
    }
}

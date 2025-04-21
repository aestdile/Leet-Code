public class Solution {
    public int NumberOfArrays(int[] differences, int lower, int upper) {
        long sum = 0;
        long minPrefix = 0;
        long maxPrefix = 0;
        foreach (int diff in differences) {
            sum += diff;
            minPrefix = Math.Min(minPrefix, sum);
            maxPrefix = Math.Max(maxPrefix, sum);
        }
        long minStart = lower - minPrefix;
        long maxStart = upper - maxPrefix;
        return (int)Math.Max(0, maxStart - minStart + 1);
    }
}

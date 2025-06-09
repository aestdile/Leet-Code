public class Solution {
    public int FindKthNumber(int n, int k) {
        int current = 1;
        k--; 

        while (k > 0) {
            long count = CountSteps(n, current, current + 1);
            if (count <= k) {
                current++;
                k -= (int)count;
            } else {
                current *= 10;
                k--;
            }
        }
        return current;
    }

    private long CountSteps(int n, long first, long last) {
        long steps = 0;
        while (first <= n) {
            steps += Math.Min(n + 1, last) - first;
            first *= 10;
            last *= 10;
        }
        return steps;
    }
}

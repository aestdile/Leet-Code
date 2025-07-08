public class Solution{
    public int MaxValue(int[][] events, int k){
        Array.Sort(events, (a, b) => a[1].CompareTo(b[1]));
        int n = events.Length;

        int[] startDays = new int[n];
        for (int i = 0; i < n; i++)
            startDays[i] = events[i][0];

        int[,] dp = new int[n + 1, k + 1];

        for (int i = 1; i <= n; i++)
        {
            int start = events[i - 1][0];
            int end = events[i - 1][1];
            int value = events[i - 1][2];

            int prev = FindLastNonOverlappingEvent(events, i - 1, start);

            for (int j = 1; j <= k; j++)
            {
                dp[i, j] = Math.Max(dp[i, j], dp[i - 1, j]);

                dp[i, j] = Math.Max(dp[i, j], dp[prev + 1, j - 1] + value);
            }
        }

        return dp[n, k];
    }

    private int FindLastNonOverlappingEvent(int[][] events, int right, int currentStart)
    {
        int left = 0, res = -1;
        while (left <= right)
        {
            int mid = (left + right) / 2;
            if (events[mid][1] < currentStart)
            {
                res = mid;
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }
        return res;
    }
}

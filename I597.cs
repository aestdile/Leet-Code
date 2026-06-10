public class Solution
{
    private int[][] maxTable;
    private int[][] minTable;
    private int[] log;

    private long GetValue(int left, int right)
    {
        int length = right - left + 1;
        int power = log[length];

        int maximum = Math.Max(
            maxTable[power][left],
            maxTable[power][right - (1 << power) + 1]
        );

        int minimum = Math.Min(
            minTable[power][left],
            minTable[power][right - (1 << power) + 1]
        );

        return (long)maximum - minimum;
    }

    public long MaxTotalValue(int[] nums, int k)
    {
        int n = nums.Length;

        log = new int[n + 1];
        for (int i = 2; i <= n; i++)
        {
            log[i] = log[i / 2] + 1;
        }

        int levels = log[n] + 1;

        maxTable = new int[levels][];
        minTable = new int[levels][];

        for (int level = 0; level < levels; level++)
        {
            maxTable[level] = new int[n];
            minTable[level] = new int[n];
        }

        for (int i = 0; i < n; i++)
        {
            maxTable[0][i] = nums[i];
            minTable[0][i] = nums[i];
        }

        for (int level = 1; level < levels; level++)
        {
            int length = 1 << level;
            int half = length >> 1;

            for (int i = 0; i + length <= n; i++)
            {
                maxTable[level][i] = Math.Max(
                    maxTable[level - 1][i],
                    maxTable[level - 1][i + half]
                );

                minTable[level][i] = Math.Min(
                    minTable[level - 1][i],
                    minTable[level - 1][i + half]
                );
            }
        }

        var pq = new PriorityQueue<(int Left, int Right), long>();

        for (int left = 0; left < n; left++)
        {
            long value = GetValue(left, n - 1);
            pq.Enqueue((left, n - 1), -value);
        }

        long answer = 0;

        while (k-- > 0)
        {
            pq.TryDequeue(out var state, out long priority);

            long value = -priority;
            int left = state.Left;
            int right = state.Right;

            answer += value;

            if (right > left)
            {
                long nextValue = GetValue(left, right - 1);
                pq.Enqueue((left, right - 1), -nextValue);
            }
        }

        return answer;
    }
}

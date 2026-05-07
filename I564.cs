public class Solution
{
    public int[] MaxValue(int[] nums)
    {
        int n = nums.Length;
        int[] ans = new int[n];

        // Prefix maximum
        int maxSoFar = nums[0];
        for (int i = 0; i < n; i++)
        {
            maxSoFar = Math.Max(maxSoFar, nums[i]);
            ans[i] = maxSoFar;
        }

        // Store suffix minimums
        List<int[]> mins = new List<int[]>();
        int minSoFar = int.MaxValue;
        for (int i = n - 1; i >= 0; i--)
        {
            if (nums[i] < minSoFar)
            {
                minSoFar = nums[i];
                mins.Add(new int[] { minSoFar, i });
            }
        }
        // Expand reachable maximums
        for (int i = n - 1; i >= 0; i--)
        {
            int left = 0;
            int right = mins.Count - 1;
            int pos = -1;
            // Binary search
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (mins[mid][0] < ans[i])
                {
                    pos = mid;
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            if (pos != -1)
            {
                int idx = mins[pos][1];
                ans[i] = Math.Max(ans[i], ans[idx]);
            }
        }
        return ans;
    }
}

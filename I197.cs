public class Solution {
    public int MaximumLength(int[] nums, int k) {
            var result = 0;

            for (var i = 0; i < k; i++)
            {
                var dp = new int[k];
                foreach (var num in nums)
                {
                    var mod = num % k;
                    var pre = (i - mod + k) % k;
                    dp[mod] = dp[pre] + 1;
                    result = Math.Max(result, dp[mod]);
                }
            }

            return result;
    }
}

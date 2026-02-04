public class Solution {
    public long MaxSumTrionic(int[] nums) {
        int n = nums.Length;
        long NEG = (long)-1e18;

        long[] incEnd = new long[n];
        long[] incStart = new long[n];

        long ans = NEG;

        for (int i = 0; i < n; i++) {
            incEnd[i] = nums[i];
            if (i > 0 && nums[i] > nums[i - 1]) {
                incEnd[i] = Math.Max(
                    (long)nums[i - 1] + nums[i],
                    incEnd[i - 1] + nums[i]
                );
            }
        }

        for (int i = n - 1; i >= 0; i--) {
            incStart[i] = nums[i];
            if (i < n - 1 && nums[i] < nums[i + 1]) {
                incStart[i] = Math.Max(
                    (long)nums[i] + nums[i + 1],
                    incStart[i + 1] + nums[i]
                );
            }
        }

        for (int i = 1; i < n - 1; i++) {
            if (nums[i] > nums[i - 1] && nums[i] > nums[i + 1]) {
                int j = i;
                long sum = 0;

                while (j < n - 1 && nums[j] > nums[j + 1]) {
                    sum += nums[j];
                    j++;
                }

                if (j < n - 1 && nums[j] < nums[j + 1]) {
                    ans = Math.Max(ans,
                        incEnd[i] - nums[i] + sum + incStart[j]
                    );
                }

                i = j;
            }
        }

        return ans;
    }
}

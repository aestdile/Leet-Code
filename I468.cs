public class Solution {
    public int MinimumDifference(int[] nums, int k) {
        if (k < 2) return 0;

        Array.Sort(nums);
        int diff = nums[k - 1] - nums[0];
        for (int i = 1; i + k - 1 < nums.Length; i++) {
            diff = Math.Min(diff, nums[i + k - 1] - nums[i]);
        }
        return diff;
    }
}

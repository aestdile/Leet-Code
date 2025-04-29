public class Solution {
    public long CountSubarrays(int[] nums, int k) {
        int max = nums.Max(), cnt = 0, l = 0;
        long res = 0;
        for (int r = 0; r < nums.Length; r++) {
            if (nums[r] == max) cnt++;
            while (cnt >= k) {
                res += nums.Length - r;
                if (nums[l++] == max) cnt--;
            }
        }
        return res;
    }
}

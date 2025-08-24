public class Solution {
    public int LongestSubarray(int[] nums) {
        int left = 0, zeroCount = 0, maxLen = 0;

        for (int right = 0; right < nums.Length; right++) {
            if (nums[right] == 0) {
                zeroCount++;
            }

            // Shrink the window until we have at most 1 zero
            while (zeroCount > 1) {
                if (nums[left] == 0) {
                    zeroCount--;
                }
                left++;
            }

            // Update max length of valid window
            maxLen = Math.Max(maxLen, right - left + 1);
        }

        // We must delete one element, so subtract 1
        return maxLen - 1;
    }
}
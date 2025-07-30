public class Solution {
    public int LongestSubarray(int[] nums) {
        int max = nums.Max();
        int count = 0, maxLength = 0;

        foreach (int num in nums) {
            if (num == max) {
                count++;
                maxLength = Math.Max(maxLength, count);
            } else {
                count = 0;
            }
        }

        return maxLength;
    }
}

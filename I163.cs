public class Solution {
    public int[] SearchRange(int[] nums, int target) {
        int first = -1;
        int last = -1;
        for (int i = 0; i < nums.Length; i++) {
            if (nums[i] == target) {
                first = i;
                while (i < nums.Length && nums[i] == target) {
                    i++;
                }
                last = i - 1;
                return new int[] { first, last };
            }
        }
        return new int[] { first, last };
    }
}

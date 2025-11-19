public class Solution {
    public int FindFinalValue(int[] nums, int original) {
        while(nums.Contains(original)) {
            original *= 2;
        }
        return original;
    }
}
public class Solution {
    public int MinOperations(int[] nums, int k) {
        int sum = nums.Sum();
        return sum % k;
    }
}
public class Solution {
    public int TriangularSum(int[] nums) {
        int n = nums.Length;
        for (int i = n; i > 1; i--) {
            for (int j = 0; j < i - 1; j++) {
                nums[j] = (nums[j] + nums[j + 1]) % 10;
            }
        }
        return nums[0];
    }
}

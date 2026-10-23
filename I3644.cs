public class Solution {
    public int SortPermutation(int[] nums) {
        int n = nums.Length;
        int res = int.MaxValue;
        for (int i = 0; i < n; ++i) {
            if (nums[i] == i) {
                continue;
            }
            res &= nums[i];
        }
        return res == int.MaxValue ? 0 : res;
    }
}

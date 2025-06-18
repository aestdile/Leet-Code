public class Solution {
    public int[][] DivideArray(int[] nums, int k) {
        if(nums.Length % 3 != 0) {
            return [];
        }
        Array.Sort(nums);
        int[][] ans = new int[nums.Length / 3][];
        int index = 0;
        for (int i = 2; i < nums.Length; i += 3) {
            if (nums[i] - nums[i-2] > k) {
                return [];
            }
            ans[index] =[nums[i-2], nums[i-1], nums[i]];
            index++;
        }
        return ans;
    }
}

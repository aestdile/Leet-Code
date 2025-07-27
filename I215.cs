public class Solution {
    public int CountHillValley(int[] nums) {
        var res = 0;
        for (int i = 1, j = 0; i < nums.Length - 1; ++i)
        {
            if ((nums[j] < nums[i] && nums[i] > nums[i + 1]) || (nums[j] > nums[i] && nums[i] < nums[i + 1]))
            {
                ++res;
                j = i;
            }
        }
        return res;
    }
}

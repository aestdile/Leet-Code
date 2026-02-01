public class Solution {
    public int MinimumCost(int[] nums) {
        int min1 = nums[0];
        int min2 = int.MaxValue;
        int min3 = int.MaxValue;
        for(int i = 1; i < nums.Length; i++) 
        {
            if(nums[i] < min2) 
            {
                min3 = min2;
                min2 = nums[i];
            } 
            else if (nums[i] < min3) 
            {
                min3 = nums[i];
            }
        }
        return min1 + min2 + min3;
    }
}

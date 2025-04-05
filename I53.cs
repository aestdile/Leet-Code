public class Solution {
    public int FindClosestNumber(int[] nums) {
        int closest = nums[0];
        foreach (int num in nums) {
            if (Math.Abs(num) < Math.Abs(closest) || 
                (Math.Abs(num) == Math.Abs(closest) && num > closest)) {
                closest = num;
            }
        }
        return closest;
    }
}

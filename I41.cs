public class Solution {
    public int DominantIndex(int[] nums) {
        int maxIndex = 0;
        
        
        for (int i = 1; i < nums.Length; i++) {
            if (nums[i] > nums[maxIndex]) {
                maxIndex = i;
            }
        }
        
        
        for (int i = 0; i < nums.Length; i++) {
            if (i != maxIndex && nums[maxIndex] < 2 * nums[i]) {
                return -1;
            }
        }
        
        return maxIndex;
    }
}

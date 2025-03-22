public class Solution {
    public int RemoveElement(int[] nums, int val) {
        int n = nums.Length; 
        int i = 0; 
        
        while (i < n) {
            if (nums[i] == val) {
                nums[i] = nums[n - 1]; 
                n--; 
            } else {
                i++; 
            }
        }
        return n; 
    }
}

          

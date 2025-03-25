public class Solution {
    public int[] SortArrayByParity(int[] nums) {
        int left = 0, right = nums.Length - 1;

        while (left < right) {
            if (nums[left] % 2 == 0) {
                left++;  
            } else if (nums[right] % 2 == 1) {
                right--; 
            } else {
                
                (nums[left], nums[right]) = (nums[right], nums[left]);
                left++;
                right--;
            }
        }
        return nums;
    }
}

public class Solution {
    public bool IsTrionic(int[] nums) {
        int i = 1, n = nums.Length, match = 0;
        while(i < n && nums[i] > nums[i - 1]){
            i++;
            match|= 1;
        }
        while(i < n && nums[i] < nums[i - 1]){
            i++;
            match|= 2;
        }
        while(i < n && nums[i] > nums[i - 1]){
            i++;
            match|= 4;
        }
        return match == 7 && i == n;
    }
}

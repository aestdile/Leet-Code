public class Solution {
    public int MinimumOperations(int[] nums) {
        int operations = 0;

        for(int i = 0; i < nums.Length; i++){
            if(nums[i] % 3 == 1 || nums[i] % 3 == 2){
                operations += 1;
            }
        }
        return operations;
    }
}
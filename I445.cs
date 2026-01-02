public class Solution {
    public int RepeatedNTimes(int[] nums) {

        for( int i=0;i<nums.Length;i++){
            for(int j=i+1;j<nums.Length;j++){
                int num =0;
                if(nums[i]==nums[j]){
                    return num = nums[i];
                }
            }
        }
        return 0;
        
    }
}

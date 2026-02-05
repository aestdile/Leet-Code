public class Solution {
    public int[] ConstructTransformedArray(int[] nums) {
        var rs = new int [nums.Length];
        for (int i = 0; i < nums.Length; i++){
            if (nums[i] == 0){
                rs[i] = nums[i];
                continue;
            }
            if (nums[i] > 0){
                rs[i] = nums[(i + nums[i]) % nums.Length];
            }
            else{
                var index = (i + nums[i]) % nums.Length;
                if (index < 0) index = index + nums.Length;
                rs[i] = nums[index];
            }
        }
        return rs;
    }
}

public class Solution {
    public long MaxSubarraySum(int[] nums, int k) {
        long[] arrayK = new long[k];
        long sum = 0;
        long res = long.MinValue;
        for(int i = 0; i < nums.Length; i++){
            sum += nums[i];
            if (i + 1 >= k) {
                res = Math.Max(res, sum - arrayK[(i + 1) % k]);
                arrayK[(i + 1) % k] = Math.Min(arrayK[(i + 1) % k], sum);
            }
            else {
                arrayK[(i + 1) % k] = sum; 
            }
        }
        return res;
    }
}
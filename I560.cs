public class Solution {
    public int MaxRotateFunction(int[] nums) {
        int preSum = 0, total = 0, len = nums.Length;

        for(int i = 0; i < len; i++)
        {
            preSum += i*nums[i];
            total += nums[i];
        }

        int maxV = preSum;

        for(int i = len-1; i >= 0; i--)
        {
            preSum += total;
            preSum -= len*nums[i];

            maxV = Math.Max(maxV, preSum);
        }

        return maxV;
    }
}

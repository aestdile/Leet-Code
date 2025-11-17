public class Solution {
    public bool KLengthApart(int[] nums, int k) {
        int prev = -1;  

        for (int i = 0; i < nums.Length; i++) {
            if (nums[i] == 1) {
                if (prev != -1 && i - prev - 1 < k) {
                    return false;
                }
                prev = i;
            }
        }

        return true;
    }
}